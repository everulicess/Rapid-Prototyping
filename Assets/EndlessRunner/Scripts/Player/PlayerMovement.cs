using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerAnim
{
    sprint,
    jump,
    fall,
    die
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.002f;

    [SerializeField] float leftBoundarie;
    [SerializeField] float rightBoundarie;

    public static bool canMove = true;
    bool isJumping = false;
    bool isGoingDown = false;
    bool jumpActivated = false;

    bool isFlying = false;
    GameObject playerObject;

    Animator anim;

    
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        canMove = true;
        EventManager.AddListener<OnPlayerCollide>(OnPlayerLose);
        EventManager.AddListener<OnRestartGame>(RestartGame);
        EventManager.AddListener<OnAbilityActivated>(ActivateAbility);
    }

    private void ActivateAbility(OnAbilityActivated evt)
    {
        //Debug.Log($"PLAYER ABILITY {evt.isActive} ARRIVED IS: {evt.abilityActive}");
        if (evt.isActive)
        {
            switch (evt.abilityActive)
            {
                case Abilities.Jump:
                    jumpActivated = true;
                    Jump();
                    Invencibility(true);
                    break;
                case Abilities.Shield:
                    Invencibility(true);
                    break;
                case Abilities.Fly:
                    Fly();
                    Invencibility(true);
                    break;
                case Abilities.Goldx2:
                    break;
                default:
                    break;
            }
        }
        
        if (!evt.isActive)
        {
            switch (evt.abilityActive)
            {
                case Abilities.Jump:
                    jumpActivated = false;
                    Invencibility(false);
                    break;
                case Abilities.Shield:
                    Invencibility(false);
                    break;
                case Abilities.Fly:
                    isFlying = false;
                    Invencibility(false);
                    break;
                case Abilities.Goldx2:
                    //beingHandled elsewhere
                    break;
                default:
                    break;
            }
        }
       
    }

    private void Jump()
    {
        if (isJumping)
            return;
        isJumping = true;
        anim.Play(PlayerAnim.die.ToString());
        StartCoroutine(JumpCoroutine());
    }
    private void Fly()
    {
        if (isFlying)
            return;
        isFlying = true;
        anim.Play(PlayerAnim.fall.ToString());
        //StartCoroutine(JumpCoroutine());
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
        EventManager.RemoveListener<OnAbilityActivated>(ActivateAbility);

    }
    private void OnPlayerLose(OnPlayerCollide evt)
    {
        canMove = false;
        anim.Play(PlayerAnim.die.ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            jumpActivated = true;
            Jump();
        }
        if (!canMove)
            return;
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x <= leftBoundarie)
                return;
            transform.Translate(Vector3.left * 1f);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x >= rightBoundarie)
                return;
            transform.Translate(Vector3.right * 1f);
        }

        
        if (isJumping)
        {
            if (!isGoingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 7, Space.World);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * -7, Space.World);

            }
        }
        else
        {
            if (!isFlying)
            {
                transform.position = new Vector3(transform.position.x, 1.255f, transform.position.z);
                anim.Play(PlayerAnim.sprint.ToString());
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 4f, transform.position.z);

            }
        }

    }

    private static void Invencibility(bool isInvencible)
    {
        OnPlayerInvencible evt = new();
        evt.isShield = isInvencible;
        EventManager.Broadcast(evt);
    }

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(1f);
        isGoingDown = true;
        yield return new WaitForSeconds(1f);
        isJumping = false;
        isGoingDown = false;
        yield return new WaitForSeconds(0.3f);
        anim.Play(PlayerAnim.sprint.ToString());
        if (jumpActivated)
            Jump();
    }
    //IEnumerator FlyCoroutine()
    //{
    //    yield return new WaitForSeconds(10f);
    //    isGoingDown = true;
    //    yield return new WaitForSeconds(1f);
    //    isJumping = false;
    //    isGoingDown = false;
    //    yield return new WaitForSeconds(0.3f);
    //    if (jumpActivated)
    //        Jump();
    //}
}
