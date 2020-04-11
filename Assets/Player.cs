using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Cached References
    PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }
    void Update()
    {
        Vector2 direction = new Vector2(input.Horizontal, input.Vertical);
        MoveCharacter(direction);
        //Test
    }
}
