using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerAnim
{
    sprint,
    jump,
    die
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.002f;

    [SerializeField] float leftBoundarie;
    [SerializeField] float rightBoundarie;

    public static bool canMove = true;

    Animator anim;

    
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        canMove = true;
        EventManager.AddListener<OnPlayerCollide>(OnPlayerLose);
        EventManager.AddListener<OnRestartGame>(RestartGame);
    }
    private void RestartGame(OnRestartGame evt)
    {
        canMove = true;
        anim.Play(PlayerAnim.sprint.ToString());
    }

    private void OnDisable()
    {
        EventManager.RemoveListener<OnPlayerCollide>(OnPlayerLose);
        EventManager.RemoveListener<OnRestartGame>(RestartGame);

    }
    private void OnPlayerLose(OnPlayerCollide evt)
    {
        canMove = false;
        anim.Play(PlayerAnim.die.ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerInvencible evt = new();
            EventManager.Broadcast(evt);
        }
        if (!canMove)
            return;
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x <= leftBoundarie)
                return;
            transform.Translate(Vector3.left * 1f);
        }
        if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x >= rightBoundarie)
                return;
            transform.Translate(Vector3.right * 1f);
        }

    }
}
