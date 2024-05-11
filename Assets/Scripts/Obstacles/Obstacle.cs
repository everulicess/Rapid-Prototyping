using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MyStates
{
    Attacking,
    Resetting
}
public class Obstacle : MonoBehaviour
{
    MyStates currentState;
    [SerializeField] GameObject model;
    GameObject ground;
    Vector3 groundPosition;
    Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        ground = GameObject.Find("Ground");
        groundPosition = ground.transform.position;
        currentState = MyStates.Attacking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MyStates.Attacking:
                transform.position += Vector3.down * Time.deltaTime;
                if (transform.position.y <= groundPosition.y)
                    currentState = MyStates.Resetting;
                break;
            case MyStates.Resetting:
                transform.position += Vector3.up * Time.deltaTime;
                if (transform.position.y >= originPosition.y)
                    currentState = MyStates.Attacking;
                break;
            default:
                break;
        }
    }
}
