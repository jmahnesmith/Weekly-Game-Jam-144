using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Cached References
    PlayerInput input;
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

    void Update()
    {
        AlterGravity();
        Vector2 direction = new Vector2(input.Horizontal, 0);
        MoveCharacter(direction);
        //Test
    }
}
