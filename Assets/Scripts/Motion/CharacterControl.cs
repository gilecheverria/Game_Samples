/*
Simple motion for a character in a side scrolling game

Gilberto Echeverria
2021-04-04
*/

using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 jumpForce;
    [SerializeField] bool grounded;

    [SerializeField] float damage;
    
    [SerializeField] GameObject highSlash;
    [SerializeField] Transform highOffset;
    [SerializeField] Transform highPoint;
    [SerializeField] float highRange;
    [SerializeField] GameObject lowSlash;
    [SerializeField] Transform lowOffset;
    [SerializeField] Transform lowPoint;
    [SerializeField] float lowRange;

    [SerializeField] LayerMask enemyLayers;

    Rigidbody2D rb;
    Vector3 move;
    Animator[] animators;
    bool facingRight = true;
    bool crouching = false;
    bool running = false;

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

        // Detect if the character is in motion
        running = (move.x != 0);

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
        Collider2D[] enemiesHit;

        if (Input.GetButtonDown("Fire1")) {
            // Instantiate the slash object
            if (crouching) {
                GameObject slash = Instantiate(lowSlash,
                                               lowOffset.position,
                                               lowOffset.rotation);
                slash.transform.parent = transform;
                // Detect enemies hit
                enemiesHit = Physics2D.OverlapCircleAll(lowPoint.position,
                                                        lowRange, enemyLayers);
            } else {
                GameObject slash = Instantiate(highSlash,
                                               highOffset.position,
                                               highOffset.rotation);
                slash.transform.parent = transform;
                // Detect enemies hit
                enemiesHit = Physics2D.OverlapCircleAll(highPoint.position,
                                                        highRange, enemyLayers);
            }
            // Trigger the animation unless the character is running on the ground
            if (!running || crouching || !grounded) {
                // Animate all child objects
                foreach (Animator animator in animators) {
                    animator.SetTrigger("Punch");
                }
            }
            // Detect enemies hit
            foreach (Collider2D enemy in enemiesHit) {
                //print("Hit enemy: " + enemy.name);
                enemy.GetComponent<Health>().TakeDamage(damage);
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

    void OnDrawGizmosSelected()
    {
        if (highPoint != null) {
            Gizmos.DrawWireSphere(highPoint.position, highRange);
            Gizmos.DrawWireSphere(lowPoint.position, lowRange);
        }
    }
}