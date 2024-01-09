using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    Collider2D physicsCollider;
    Rigidbody2D physicsBody;
    [SerializeField]
    private LayerMask platformsLayer;

    public bool doJump;
    public float moveDirection;
    public bool doPrimaryAttack;
    public float jumpHeight;
    public float groundMoveSpeed;
    public float airMoveSpeed;
    public float maxFallSpeed;

    private void Start()
    {
        player = transform.GetComponent<Player>();
        jumpHeight = player.playerStats.jumpHeight.Value;
        groundMoveSpeed = player.playerStats.groundSpeed.Value;
        airMoveSpeed = player.playerStats.airMoveSpeed.Value;
        maxFallSpeed = player.playerStats.maxFallSpeed.Value;
        physicsCollider = transform.GetComponent<Collider2D>();
        physicsBody = transform.GetComponent<Rigidbody2D>();
    }

    void OnJump()
    {
        doJump = true;
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>().x;
    }

    void OnPrimaryAttack()
    {
        doPrimaryAttack = true;
        player.UseMana(10f);
        Debug.Log("Attacking");
    }


    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(physicsCollider.bounds.center, physicsCollider.bounds.size, 0f, Vector2.down, .1f, platformsLayer);
        return raycastHit2d.collider != null;
    }

    // Returns true if we are moving up
    public bool IsJumping()
    {
        return physicsBody.velocity.y > 0;
    }

    // Returns true if we are moving down
    public bool IsFalling()
    {
        return physicsBody.velocity.y < 0;
    }

    void FixedUpdate()
    {

        if (doPrimaryAttack)
        {
            // do attack
            doPrimaryAttack = false;
        }

        // If changing direction, remove speed from previous direction
        if( (physicsBody.velocity.x > 0 && moveDirection < 0) || (physicsBody.velocity.x < 0 && moveDirection > 0))
        {
            physicsBody.velocity = new Vector2(0f, physicsBody.velocity.y);
        }

        // Check for movement / Add force when grounded
        if(IsGrounded())
        {
            // Allow jump when touching ground, set jump to false after
            if (doJump)
            {
                physicsBody.AddForce(new Vector2(0f, jumpHeight));
                doJump = false;
            }

            // Add ground movement 
            AddMovement(false);
        }

        // Air movement
        else
        {
            AddMovement(true);
        }
    }


    // 
    private void AddMovement(bool inAir)
    {
        float moveSpeed;
        if(inAir)
        {
            moveSpeed = airMoveSpeed;
        }
        else
        {
            moveSpeed = groundMoveSpeed;
        }
        
        physicsBody.velocity = new Vector2(moveDirection*moveSpeed, physicsBody.velocity.y);

    }

}
