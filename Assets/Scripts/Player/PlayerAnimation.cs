using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PlayerBehaviour playerBehaviour;

    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {
        if (playerBehaviour.isRunning)
        {
            spriteRenderer.flipX = playerBehaviour.currentSpeed.x < 0;
        }
        animator.SetFloat("Speed", playerBehaviour.bottomCollider ? Input.GetAxisRaw("Horizontal") * playerBehaviour.speedWalk : 0);
        animator.SetFloat("Jumping", playerBehaviour.isFalling ? -1 : playerBehaviour.isJumping ? 1 : 0);
    }
}
