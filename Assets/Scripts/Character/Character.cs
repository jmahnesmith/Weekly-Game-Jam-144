using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1;
    public float jumpForce = 1;
    

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    private void Start()
    {
        extraJump = extraJumpValue;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    public void MoveCharacter(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        if(isGrounded == true)
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
