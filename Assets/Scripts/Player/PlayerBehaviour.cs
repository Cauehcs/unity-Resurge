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

    [HideInInspector] public bool isGrounded, isJumping, isFalling, isRunning;

    [HideInInspector] public bool topCollider, topRightCollider, rightCollider, rightBottomCollider, bottomCollider, bottomLeftCollider, leftCollider, leftTopCollider;

    void FixedUpdate()
    {
        Walk();
        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
        SetStatus();
        currentSpeed = rb.velocity;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Walk()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speedWalk * move, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void SetStatus()
    {
        isRunning = Input.GetAxisRaw("Horizontal") != 0;
        isGrounded = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.center.x, walkCollider.bounds.min.y), .2f, groundLayer);
        isFalling = rb.velocity.y < 0;
        isJumping = rb.velocity.y > 0;

        // leftCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.min.x, walkCollider.bounds.center.y), .2f, groundLayer);
        // rightCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.max.x, walkCollider.bounds.center.y), .2f, groundLayer);
        // bottomLeftCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.min.x, walkCollider.bounds.min.y), .2f, groundLayer);
        // rightBottomCollider = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.max.x, walkCollider.bounds.min.y), .2f, groundLayer);
    }
}
