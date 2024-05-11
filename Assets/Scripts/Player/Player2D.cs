using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player2DMovement : MonoBehaviour
{
    CharacterController characterController;

    Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();   
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

        characterController.Move(movementDirection * Time.deltaTime);
    }
    
    void Jump()
    {
        if (!characterController.isGrounded)
            return;
        //movementDirection.y = characterController.isGrounded && characterController.velocity.y < 0 ? 100f : 0f;
        //characterController.Move(movementDirection * Time.deltaTime);

        movementDirection.y = 20f;
    
        
        characterController.Move(movementDirection* Time.deltaTime);

    }
}
