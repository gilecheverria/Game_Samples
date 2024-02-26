/*
Script to control the motion of the paddles

Gilberto Echeverria
2024-02-19
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] float speed;
    // Limit for the movement of the paddles
    [SerializeField] float limit;
    // Keys that will be used to move each of the paddles
    // Configured from the Unity Inspector
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y < limit)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(downKey) && transform.position.y > -limit)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}