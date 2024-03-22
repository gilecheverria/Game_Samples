/*
Move an object back and forth in a sine wave pattern.

Gilberto Echeverria
2024-03-22
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosineMotion : MonoBehaviour
{
    [SerializeField] float amplitude = 1.0f;
    [SerializeField] float frequency = 1.0f;
    [SerializeField] Vector3 direction = Vector3.right;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInCosineWave();        
    }

    void MoveInCosineWave()
    {
        float time = Time.time;
        Vector3 offset = amplitude * Mathf.Cos(2 * Mathf.PI * frequency * time) * direction;
        transform.position = initialPosition + offset;
    }
}