/*
Script to determine how the bullet interacts with other objects

Gilberto Echeverria
2023-03-19
*/

using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] int damage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy") {
            // Look for the enemy's health component
            AgentHealth health = col.gameObject.GetComponent<AgentHealth>();
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
