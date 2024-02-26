/*
Scripts to detect when the user scores a point in the Pong game.

Gilberto Echeverria
2024-02-19
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongScore : MonoBehaviour
{
    [SerializeField] int side;
    PongGameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to a script in another object
        gameController = GameObject.FindWithTag("GameController").GetComponent<PongGameController>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Call a method in the other script
        gameController.Score(side);
        Destroy(other.gameObject);
    }
}
