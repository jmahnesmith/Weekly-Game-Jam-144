using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Cached References
    PlayerInput input;

    public bool isGrounded;
    public bool isOnWall;

    public Transform groundCheck;
    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float currentSlideSpeed;

    //Jumping
    private int extraJump;
    public int extraJumpValue;

    //For gravity alter
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        input.OnJump += PlayerJump;

        extraJump = extraJumpValue;
    }

    void Update()
    {
        isOnWall = Physics2D.OverlapCircle(leftWallCheck.position, checkRadius, whatIsGround) ||
            Physics2D.OverlapCircle(rightWallCheck.position, checkRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isOnWall && !isGrounded)
        {
            WallSlide();
            Vector2 direction = new Vector2(input.Horizontal, 0);
            MoveCharacter(direction * 4);
        }
        else
        {
            Vector2 direction = new Vector2(input.Horizontal, 0);
            MoveCharacter(direction);
        }

        AlterGravity();
        
        
    }

    private void WallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -currentSlideSpeed);
    }

    private void AlterGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !input.Jumping)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void PlayerJump()
    {
        Debug.Log("Jump Activated", this);
        Jump();
    }

    public void Jump()
    {
        if (isGrounded == true || isOnWall)
        {
            extraJump = extraJumpValue;
        }
        if (extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (extraJump == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


    }

}
