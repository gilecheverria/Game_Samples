/*
Ball script for the Break Out game

Destroy any blocks tagged as Enemy, adding points to the score

Gilberto Echeverria
2024-03-20
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    BreakOutGameController manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<BreakOutGameController>();
    }

    // Check for collisions with other objects
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object has the tag "Enemy"
        if (other.gameObject.CompareTag("Enemy")) {
            manager.AddPoints(10);
            // Destroy the brick object
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Destroyer")) {
            manager.LoseLife();
            Destroy(gameObject);
        }
    }
}