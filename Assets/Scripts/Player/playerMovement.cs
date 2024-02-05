using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    Collider2D physicsCollider;
    Rigidbody2D physicsBody;
    public InventoryUI inventoryUI;
    [SerializeField]
    private LayerMask platformsLayer;

    // Jumping
    public bool doJump;
    public float jumpHeight;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // General movement
    public float moveDirection;
    public float groundMoveSpeed;
    public float airMoveSpeed;

    //Combat
    public bool doPrimaryAttack;
    public Vector2 aimDirection;

    public float maxFallSpeed;
    public bool isDashing;

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
        aimDirection = value.Get<Vector2>();
    }

    // need to add attack delay - based on weapon attack time
    // How to add mana into here?
    void OnPrimaryAttack()
    {
        doPrimaryAttack = true;
        if(player.primaryWeapon != null)
        {
            player.primaryWeapon.PrimaryAttack();
        }
        else
        {
            Debug.Log("Unarmed attack!");
        }
    }


    void OnOpenInventory()
    {
        Debug.Log("Inventory Activated");   
        inventoryUI.ActivateInventory();
    }

    void OnDash()
    {
        Debug.Log("Dash!");
        StartCoroutine(DoDash());
        
    }

    public IEnumerator DoDash()
    {
        isDashing = true;
        physicsBody.velocity = new Vector2(2 * moveDirection * groundMoveSpeed, physicsBody.velocity.y);
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
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

    public int GetDirection()
    {
        return player.transform.localScale.x > 0 ? 1 : -1;
    }

    void FixedUpdate()
    {

        
        // Handle gravity increasing fall speed and holding down the jump button for a longer jump cf
        if (IsFalling())
        {
            physicsBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(IsJumping() && !GetComponent<PlayerInput>().actions["Jump"].IsPressed())
        {
            physicsBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (doPrimaryAttack)
        {
            // do attack
            doPrimaryAttack = false;
        }

        // If changing direction, remove speed from previous direction
        if( ( (physicsBody.velocity.x > 0 && moveDirection < 0) || (physicsBody.velocity.x < 0 && moveDirection > 0) )&& !isDashing)
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


    // Include player speed, and any modifiers
    private void AddMovement(bool inAir)
    {
        // If dashing, let it handle movement
        if(isDashing)
        {
            return;
        }

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
