/*
Simple motion script to modify the horizontal position

Gilberto Echeverria
2/02/2021
*/

using UnityEngine;

public class Horizontal : MonoBehaviour
{
    // Variables visible from Unity interface
    [SerializeField] float speed;

    // Instance variables
    Vector3 motion;

    // Update is called once per frame
    void Update()
    {
        motion.x = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + motion * speed;
    }
   
}
