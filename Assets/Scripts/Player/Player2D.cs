using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player2D : MonoBehaviour
{
    CharacterController characterController;

    Vector3 movementDirection;
    [SerializeField] float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        CameraFollow.Singleton.SetTarget(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new(Input.GetAxisRaw("Horizontal"), 0, 0);
        //Debug.Log(characterController.isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (!characterController.isGrounded) 
            movementDirection.y -= (9.8f) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
        characterController.Move(movementDirection * movementSpeed*Time.deltaTime);
    }
    void Dash()
    {
        
    }
    void ApplyGravity()
    {
        if (characterController.isGrounded && characterController.velocity.y < 0.0f)
        {
        }
    }
    void Jump()
    {
        if (!characterController.isGrounded)
            return;
        
        movementDirection.y = 20f;
    
        
        characterController.Move(movementDirection* Time.deltaTime);

    }

    public void Die()
    {
        characterController.enabled = false;
        transform.position = new Vector3(0,1f,0);
        Debug.Log($"Player dead");
        characterController.enabled = true;

    }
}
