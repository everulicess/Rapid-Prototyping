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
        affectsPlayer = !affectsPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!affectsPlayer)
            return;
        EventManager.Broadcast(Events.PlayerCollideEvent);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
