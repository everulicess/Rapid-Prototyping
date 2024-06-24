using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    bool affectsPlayer = true;
    private void Start()
    {
        EventManager.AddListener<OnPlayerInvencible>(PlayerInvencible);
    }

    private void PlayerInvencible(OnPlayerInvencible evt)
    {
        //LevelManager.instance.isInvencible = evt.isShield;
        affectsPlayer = !evt.isShield;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (LevelManager.instance.isInvencible)
        //    return;
        if (!affectsPlayer)
            return;
        EventManager.Broadcast(Events.PlayerCollideEvent);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
