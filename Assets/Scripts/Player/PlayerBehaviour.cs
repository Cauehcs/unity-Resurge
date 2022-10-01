using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    [HideInInspector]
    public float currentSpeed, move;

    void FixedUpdate()
    {
        Walk();
    }

    void Walk() {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        currentSpeed = move * speed;
    }
}
