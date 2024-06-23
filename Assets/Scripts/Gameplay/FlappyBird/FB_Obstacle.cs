using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FB_Obstacle : MonoBehaviour
{
    Vector3 initPosition;
    OnObstacleArrived evt = new();
    void Start()
    {
        initPosition = transform.position;
        //Event data
        evt.Obstacle = gameObject;
        evt.InitialPosition = initPosition;
    }
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 3f;

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        if (!Screen.safeArea.Contains(pos) && transform.position.x < -10)
        {
            EventManager.Broadcast(evt);
        }
    }
}
