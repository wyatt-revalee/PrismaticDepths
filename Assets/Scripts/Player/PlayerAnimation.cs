using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator playerAnimator;
    Rigidbody2D rigidBody2D;
    PlayerMovement playerMovement;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //Check if player is moving
        if(rigidBody2D.velocity.x > 0 || rigidBody2D.velocity.y > 0)
        {
            playerAnimator.SetBool("IsMoving", true);
        }

        // Check if player is grounded
        if(playerMovement.IsGrounded())
        {
            playerAnimator.SetBool("IsGrounded", true);
        }
    }
}
