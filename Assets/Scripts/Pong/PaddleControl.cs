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
    [SerializeField] float limit;
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y < limit)
        {
            MoveUp();
        }
        if (Input.GetKey(downKey) && transform.position.y > -limit)
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}