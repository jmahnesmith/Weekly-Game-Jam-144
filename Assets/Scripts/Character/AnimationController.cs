using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public PlayerInput input;
    public Player player;
    public EndOfLevel levelManager;
    private Animator animator;
    public PlayerSprites currSprite;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
    }


    private void Update()
    {
        if(input.Horizontal == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
            animator.SetBool("isRunning", true);
        

        if (input.Jumping)
        {
            animator.SetBool("isJumping", true);
        }
        else
            animator.SetBool("isJumping", false);

        if (!player.isOnWall && !player.isGrounded)
        {
            animator.SetBool("isInAir", true);
        }
        else
            animator.SetBool("isInAir", false);

        if (player.isGrounded && !player.isOnWall)
        {
            animator.SetBool("isLanding", true);
        }
        else
            animator.SetBool("isLanding", false);


    }
    private void LateUpdate()
    {
        ChangeSprites(currSprite);
    }

    public void ChangeSprites(PlayerSprites spriteSheet)
    {
        var subSprites = Resources.LoadAll<Sprite>("Sprites/Animations/" + spriteSheet.ToString());

        foreach(var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if(newSprite)
            {
                renderer.sprite = newSprite;
            }
        }
    }
}

public enum PlayerSprites
{
    CharacterHappySheet,
    CharacterMehSheet,
    CharacterSadSheet
}
