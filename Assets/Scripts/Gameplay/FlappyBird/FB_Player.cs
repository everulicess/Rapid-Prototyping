using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Player : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnDestroy()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Gold")
        {
            GetGold();
        }
        else
        {
            HandleDeath();
        }
    }

    private static void HandleDeath()
    {
        OnMiniGameFinished evt = new();
        evt.IsFinished = true;
        evt.Roulette = MyScenes.Roulette;
        EventManager.Broadcast(evt);
    }

    private static void GetGold()
    {
        OnScoreUpdate evt = new();
        evt.GoldIncrease = 1;
        EventManager.Broadcast(evt);
    }
}
