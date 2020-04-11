using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public PlayerInput input;
    public string spriteSheetName;
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(input.Horizontal == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }
    private void LateUpdate()
    {
        ChangeSprites();
    }

    private void ChangeSprites()
    {
        var subSprites = Resources.LoadAll<Sprite>("Sprites/Animations/" + spriteSheetName);

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
