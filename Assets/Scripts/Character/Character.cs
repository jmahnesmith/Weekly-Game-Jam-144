using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1;
    public float jumpForce = 1;
    

    

    

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    public virtual void MoveCharacter(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }
    
}
