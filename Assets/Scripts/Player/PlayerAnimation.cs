using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator playerAnimator;
    Rigidbody2D rigidBody2D;
    PlayerMovement playerMovement;
    Player player;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        player = GetComponent<Player>();
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

        if(playerMovement.moveDirection < 0 && !playerMovement.isDashing)
        {
            Vector3 playerScale = playerMovement.transform.localScale;
            if (playerScale.x > 0)
            {
                playerMovement.transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
            }
        }
        else if(playerMovement.moveDirection > 0 && !playerMovement.isDashing)
        {
            Vector3 playerScale = playerMovement.transform.localScale;
            if (playerScale.x < 0)
            {
                playerMovement.transform.localScale = new Vector3(playerScale.x * -1, playerScale.y, playerScale.z);
            }
        }

        // if player attacks
        if(playerMovement.doPrimaryAttack == true)
        {
            StartCoroutine(PrimaryAttack());
        }
        // Check if player is jumping
        playerAnimator.SetBool("IsJumping", playerMovement.IsJumping());

        // Check if player is falling
        playerAnimator.SetBool("IsFalling", playerMovement.IsFalling());

        // Check if player is grounded
        playerAnimator.SetBool("IsGrounded", playerMovement.IsGrounded());

        //Check if player is dashing
        playerAnimator.SetBool("IsDashing", playerMovement.isDashing);

        //Check if player is aiming up
        playerAnimator.SetBool("IsFacingUp", playerMovement.aimDirection.y > 0);

        //Check if player is aiming down
        playerAnimator.SetBool("IsFacingDown", playerMovement.aimDirection.y < 0);

        //Check if player is dead
        playerAnimator.SetBool("IsDead", player.isDead);

    }

    IEnumerator PrimaryAttack()
    {
        playerAnimator.SetBool("IsPrimaryAttacking", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("IsPrimaryAttacking", false);
    }

}
