using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jumping { get; private set; }

    public event Action OnJump;

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Jumping = Input.GetKey(KeyCode.Space);

        if(Jumping && OnJump != null)
        {
            OnJump();
        }
        
    }
}
