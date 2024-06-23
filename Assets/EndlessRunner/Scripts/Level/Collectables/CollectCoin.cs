using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnScoreUpdate evt = new();
        evt.GoldIncrease = 1;
        EventManager.Broadcast(evt);
        gameObject.SetActive(false);
    }
}
