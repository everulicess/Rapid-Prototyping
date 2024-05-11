using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Times")]
    [SerializeField] float attackTime = 10f;
    [SerializeField] float retrackTime = 5f;
    
    [SerializeField] GameObject model;
    GameObject ground;
    Vector3 groundPosition;
    Vector3 originPosition;
    Vector3 destinyPosition;

    bool isDoneAttacking;
    float distance;

    void Start()
    {
        originPosition = transform.position;
        ground = GameObject.Find("Ground");
        groundPosition = ground.transform.position;
        destinyPosition = new Vector3(transform.position.x, groundPosition.y + 0.5f, transform.position.z);

        distance = Vector3.Distance(destinyPosition, originPosition);

    }
    void Update()
    {
        ObstacleMovement();
    }
    private void ObstacleMovement()
    {
        float time = (distance / (!isDoneAttacking ? attackTime : retrackTime)) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, !isDoneAttacking ? destinyPosition : originPosition, time);

        if (transform.position.y == (!isDoneAttacking ? destinyPosition.y : originPosition.y))
            isDoneAttacking = !isDoneAttacking;
    }

}
