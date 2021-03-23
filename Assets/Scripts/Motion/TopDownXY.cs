/*
Movement of a character from a top down perspective
The character should have a Rigidbody
The movement is on the XY plane

Gilberto Echeverria
02/03/2021
*/

using UnityEngine;

public class TopDownXY : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    Animator anim;
    Vector2 move;

    enum Direction {South, East, North, West};

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //print("South: " + (int)Direction.South
             //+ " | East: " + (int)Direction.East
             //+ " | North: " + (int)Direction.North
             //+ " | West: " + (int)Direction.West);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        // Apply the movement directly as velocity
        rb.velocity = move * speed;

        // Activate only one of the animations
        // The priority is given by the order of the if's
        if (move.y > 0) {
            anim.SetInteger("Direction", (int)Direction.North);
            //print("Moving North: " + (int)Direction.North);
        }
        else if (move.y < 0) {
            anim.SetInteger("Direction", (int)Direction.South);
            //print("Moving South: " + (int)Direction.South);
        }
        else if (move.x > 0) {
            anim.SetInteger("Direction", (int)Direction.East);
            //print("Moving East: " + (int)Direction.East);
        }
        else if (move.x < 0) {
            anim.SetInteger("Direction", (int)Direction.West);
            //print("Moving West: " + (int)Direction.West);
        }
    }
}
