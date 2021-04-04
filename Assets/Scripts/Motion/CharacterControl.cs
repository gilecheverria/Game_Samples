/*
Simple motion for a character in a side scrolling game

Gilberto Echeverria
2021-04-04
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 jumpForce;
    [SerializeField] bool grounded;

    Rigidbody2D rb;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called at regular intervals
    void FixedUpdate()
    {
        Move();
        Jump();
        Attack();
    }

    void Move()
    {
        move.x = Input.GetAxis("Horizontal") * speed;
        // Preserve the current vertical velocity
        move.y = rb.velocity.y;

        rb.velocity = move;
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && grounded) {
            rb.AddForce(jumpForce);
            grounded = false;
        }
    }

    void Attack()
    {
        if (Input.GetButton("Fire1")) {
            print("PUNCH!!");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") {
            grounded = true;
        }

    }
}