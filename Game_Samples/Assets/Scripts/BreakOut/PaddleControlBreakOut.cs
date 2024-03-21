/*
Script to control the motion of the paddle
in the Break Out game

Also control when to release the ball,
giving the ball the same horizontal speed as the paddle

Gilberto Echeverria
2024-03-20
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControlBreakOut : MonoBehaviour
{
    [SerializeField] float speed;
    // Limit for the movement of the paddles
    [SerializeField] float limit;
    // Keys that will be used to move each of the paddles
    // Configured from the Unity Inspector
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;

    public GameObject ball;

    // Store the current speed of the paddle
    public Vector3 paddleDirection = Vector3.zero;
    Vector2 ballSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey) && transform.position.x > -limit) {
            paddleDirection = Vector3.left;
            transform.Translate(paddleDirection * speed * Time.deltaTime);
        } else if (Input.GetKey(rightKey) && transform.position.x < limit) {
            paddleDirection = Vector3.right;
            transform.Translate(paddleDirection * speed * Time.deltaTime);
        } else {
            paddleDirection = Vector3.zero;
        }

        // Release the ball from the paddle, giving the ball the same horizontal speed as the paddle
        if (Input.GetKeyDown(KeyCode.Space) && ball)
        {
            ball.transform.SetParent(null);
            ballSpeed = (paddleDirection + Vector3.up).normalized * speed;
            Debug.Log("Releasing the ball with speed: " + ballSpeed);
            ball.GetComponent<Rigidbody2D>().velocity = ballSpeed;
            ball = null;
        }
    }
}