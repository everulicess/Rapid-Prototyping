using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    int goldMultiplier = 1;
    private void Start()
    {
        EventManager.AddListener<OnAbilityActivated>(DoubleGoldActivated);
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnAbilityActivated>(DoubleGoldActivated);
    }

    private void DoubleGoldActivated(OnAbilityActivated evt)
    {
        if (evt.abilityActive != Abilities.DoubleGold)
            return;
        goldMultiplier = evt.isActive ? 2 : 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnScoreUpdate evt = new();
        evt.GoldIncrease = goldMultiplier * 1;
        EventManager.Broadcast(evt);
        gameObject.SetActive(false);
    }
}
