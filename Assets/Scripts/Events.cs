using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static readonly Dictionary<Type, Action<GameEvent>> s_Events = new Dictionary<Type, Action<GameEvent>>();

    static readonly Dictionary<Delegate, Action<GameEvent>> s_EventLookups =
        new Dictionary<Delegate, Action<GameEvent>>();

    public static void AddListener<T>(Action<T> evt) where T : GameEvent
    {
        if (!s_EventLookups.ContainsKey(evt))
        {
            Action<GameEvent> newAction = (e) => evt((T)e);
            s_EventLookups[evt] = newAction;

            if (s_Events.TryGetValue(typeof(T), out Action<GameEvent> internalAction))
                s_Events[typeof(T)] = internalAction += newAction;
            else
                s_Events[typeof(T)] = newAction;
        }
    }

    public static void RemoveListener<T>(Action<T> evt) where T : GameEvent
    {
        if (s_EventLookups.TryGetValue(evt, out var action))
        {
            if (s_Events.TryGetValue(typeof(T), out var tempAction))
            {
                tempAction -= action;
                if (tempAction == null)
                    s_Events.Remove(typeof(T));
                else
                    s_Events[typeof(T)] = tempAction;
            }

            s_EventLookups.Remove(evt);
        }
    }

    public static void Broadcast(GameEvent evt)
    {
        if (s_Events.TryGetValue(evt.GetType(), out var action))
            action.Invoke(evt);
    }

    public static void Clear()
    {
        s_Events.Clear();
        s_EventLookups.Clear();
    }
}

public static class Events
{
    public static OnPlateBrokenEvent BrokenPlateEvent = new();
    public static OnSceneFinished finishedSceneEvent = new();
    public static OnWeaponSelectedEvent WeaponSelectedEvent = new();
}
public class GameEvent { }
public class OnPlateBrokenEvent:GameEvent
{
    public int amountToIncrease;
}
public class OnSceneFinished : GameEvent
{
    public ChoiceScenes finishedScene;
}
public class OnWeaponSelectedEvent : GameEvent
{
    public Options selectedWeapon;
    public GameObject WeaponPrefab 
    { 
        get 
        {
            return selectedWeapon switch
            {
                Options.Rifle => PlateGameplayManager.RiflePrefab,
                Options.Machinegun => PlateGameplayManager.MachinegunPrefab,
                Options.Sniper => PlateGameplayManager.SniperPrefab,
                _ => PlateGameplayManager.SniperPrefab,
            };
        } 
    }
}