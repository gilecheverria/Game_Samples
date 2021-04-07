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

    [SerializeField] GameObject highSlash;
    [SerializeField] Vector3 highOffset;
    [SerializeField] GameObject lowSlash;
    [SerializeField] Vector3 lowOffset;

    Rigidbody2D rb;
    Vector3 move;
    Animator[] animators;
    bool facingRight = true;
    bool crouching = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get reference to the animator
        animators = GetComponentsInChildren<Animator>();
    }

    // Update is called at regular intervals
    void FixedUpdate()
    {
        Move();
        Crouch();
        Jump();
        Attack();
    }

    void Move()
    {
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        // Preserve the current vertical velocity
        move.y = rb.velocity.y;

        rb.velocity = move;

        // Flip the character when changing direction
        if (move.x < 0 && facingRight) {
            facingRight = false;
            transform.Rotate(0, 180, 0);
        } else if (move.x > 0 && !facingRight) {
            facingRight = true;
            transform.Rotate(0, 180, 0);
        }

        foreach (Animator animator in animators) {
            animator.SetFloat("Velocity", Mathf.Abs(move.x));
        }
    }

    void Crouch()
    {
        float down = Input.GetAxisRaw("Vertical");
        if (down < 0 && grounded) {
            crouching = true;
            foreach (Animator animator in animators) {
                animator.SetBool("Crouch", true);
            }
        }
        if (down >= 0 && crouching) {
            crouching = false;
            foreach (Animator animator in animators) {
                animator.SetBool("Crouch", false);
            }
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded) {
            rb.AddForce(jumpForce);
            grounded = false;
            foreach (Animator animator in animators) {
                animator.SetTrigger("Jump");
            }
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1")) {
            // Instantiate the slash object
            if (crouching) {
                GameObject slash = Instantiate(lowSlash, transform.position + lowOffset, Quaternion.identity);
                slash.transform.parent = transform;
            } else {
                GameObject slash = Instantiate(highSlash, transform.position + highOffset, Quaternion.identity);
                slash.transform.parent = transform;
            }
            foreach (Animator animator in animators) {
                animator.SetTrigger("Punch");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") {
            if (!grounded) {
                foreach (Animator animator in animators) {
                    animator.SetTrigger("Land");
                }
            }
            grounded = true;
        }
    }
}