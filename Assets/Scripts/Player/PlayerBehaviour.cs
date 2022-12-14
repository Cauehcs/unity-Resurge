using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float speedWalk, speedRun, jumpForce;
    public Rigidbody2D rb;
    public Collider2D walkCollider;
    public LayerMask groundLayer;

    [HideInInspector] public Vector2 currentSpeed;

    [HideInInspector] public float move, lastMove;

    public bool isGrounded, isJumping, isFalling, isRunning;
    [HideInInspector] public int lastJumpSide;
    [HideInInspector] public bool topCollider, topRightCollider, rightCollider, rightBottomCollider, bottomCollider, bottomLeftCollider, leftCollider, leftTopCollider;

    void Update()
    {
        Walk();
        if (Input.GetButtonDown("Jump") && isGrounded && ((lastJumpSide == -1 && rightBottomCollider) || (lastJumpSide == 1 && bottomLeftCollider) || lastJumpSide == 0))
        {
            Jump();
        }
        SetStatus();
        currentSpeed = rb.velocity;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Walk()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speedWalk * move * (isJumping ? 1.2f : 1), rb.velocity.y);
    }

    void Jump()
    {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        lastJumpSide = bottomCollider ? 0 : bottomLeftCollider ? -1 : 1;
    }

    void SetStatus()
    {
        isRunning = Input.GetAxisRaw("Horizontal") != 0;
        isGrounded = bottomCollider || bottomLeftCollider || rightBottomCollider;
        isFalling = rb.velocity.y < 0 && !bottomCollider;
        isJumping = rb.velocity.y > 0 && !bottomCollider;

        bottomLeftCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.min.x, walkCollider.bounds.min.y), .4f, groundLayer);
        rightBottomCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.max.x, walkCollider.bounds.min.y), .4f, groundLayer);
        bottomCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.center.x, walkCollider.bounds.min.y), .4f, groundLayer);
    }
}
