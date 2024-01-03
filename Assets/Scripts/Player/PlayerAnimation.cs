using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator playerAnimator;
    Rigidbody2D rigidBody2D;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Check if player is moving
        if(rigidBody2D.velocity.x != 0 || rigidBody2D.velocity.y != 0)
        {
            playerAnimator.SetBool("IsMoving", true);
        }
        else
        {
            playerAnimator.SetBool("IsMoving", false);
        }

        if(playerMovement.moveDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(playerMovement.moveDirection > 0)
        {
            spriteRenderer.flipX = false;
        }

        // if player attacks
        if(playerMovement.doMainAttack == true)
        {
            StartCoroutine(MainAttack());
        }

        // if (rigidBody2D.velocity.x > 0 || rigidBody2D.velocity.y > 0)
        // {
        //     playerAnimator.SetBool("IsMoving", true);
        // }

        // Check if player is grounded
        if (playerMovement.IsGrounded())
        {
            playerAnimator.SetBool("IsGrounded", true);
        }
        else
        {
            playerAnimator.SetBool("IsGrounded", false);
        }
    }

    IEnumerator MainAttack()
    {
        playerAnimator.SetBool("IsMainAttacking", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("IsMainAttacking", false);
    }

}
