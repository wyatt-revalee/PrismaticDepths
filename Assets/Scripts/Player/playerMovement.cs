using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class playerMovement : MonoBehaviour
{
    Player player;
    public bool doJump;
    public float moveDirection;
    public float jumpHeight;
    public float moveSpeed;
    public float airSpeed;

    private void Start()
    {
        player = transform.GetComponent<Player>();
        jumpHeight = player.playerStats.jumpHeight.Value;
        moveSpeed = player.playerStats.groundSpeed.Value;
        airSpeed = player.playerStats.airSpeed.Value;
    }

    void OnJump()
    {
        doJump = true;
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>().x;
    }

    void FixedUpdate()
    {
        if (doJump)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight));
            doJump = false;
        }
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveDirection * moveSpeed, 0f));
    }

}
