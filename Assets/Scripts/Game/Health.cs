/*
Script to control the health of players and enemies

Gilberto Echeverria
2021-04-07
*/

using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHP;

    float currentHP;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        animator.SetTrigger("Hit");

        if (currentHP <= 0) {
            animator.SetBool("Dead", true);

            // Stop the character from falling through the ground
            GetComponent<Rigidbody2D>().gravityScale = 0;
            // Disable the collider for this object
            GetComponent<Collider2D>().enabled = false;
            // Disable this script
            this.enabled = false;
        }
    }
}
