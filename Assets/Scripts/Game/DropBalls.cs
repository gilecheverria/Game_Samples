﻿/*
Generate new balls at random horizontal positions

Gilberto Echeverria
18/02/2021
*/

using UnityEngine;

public class DropBalls : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Vector2 limits;
    [SerializeField] float delay;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping balls after 1 second, then every 'delay' seconds
        InvokeRepeating("NewBall", 1, delay);
    }

    void NewBall()
    {
        position = new Vector3(Random.Range(-limits.x, limits.x), limits.y, 0);
        Instantiate(ball, position, Quaternion.identity);
    }

    public void StopBalls()
    {
        CancelInvoke();
    }
}
