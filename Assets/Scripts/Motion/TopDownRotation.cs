/*
Movement of a character from a top down perspective
The character should have a Rigidbody
The movement is along the vertical axis, and the character can rotate

Gilberto Echeverria
02/03/2021
*/

using UnityEngine;

public class TopDownRotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationRatio;

    Rigidbody2D rb;
    float move;
    float rotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotate = Input.GetAxis("Horizontal");
        move = Input.GetAxis("Vertical");

        rb.velocity = transform.up * move * speed;
        // Rotate in the inverse direction as the arrow pressed
        rb.rotation = rb.rotation + -rotate * rotationRatio;
    }
}
