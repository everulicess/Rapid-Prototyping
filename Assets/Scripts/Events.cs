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
    public static OnScoreUpdate UpdateScoreEvent = new();
    public static OnSceneFinished FinishedSceneEvent = new();
    public static OnWeaponSelectedEvent WeaponSelectedEvent = new();
    public static OnShopBuy ShopBuyEvent = new();


    public static OnPlayerCollide PlayerCollideEvent = new();

    public static OnRestartGame RestartGameEvent = new();

}
public class GameEvent { }
public class OnScoreUpdate : GameEvent
{
    public int GoldIncrease;
}
public class OnSceneFinished : GameEvent
{
    public Minigames finishedScene;
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
public class OnShopBuy : GameEvent
{
    public int Price;
}
public class OnMiniGameFinished : GameEvent
{
    public bool IsFinished;
    public MyScenes Roulette;
}

public class OnPlayerCollide : GameEvent
{
}

public class OnPlayerInvencible : GameEvent
{
}
public class OnQuitGame : GameEvent
{
}
public class OnRestartGame : GameEvent
{

}
#region FLAPPYBIRD
public class OnObstacleArrived : GameEvent
{
    public GameObject Obstacle;
    public Vector3 InitialPosition;
}
#endregion