/*
Motion script for background objects
Should be adjusted individually for each layer

Gilberto Echeverria
2021-04-04
*/

using UnityEngine;

public class BGParallax : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        // Change the direction of the motion given to the player
        move.x = Input.GetAxis("Horizontal") * -speed;

        transform.Translate(move);
    }
}
