/*
Motion script for background objects
Should be adjusted individually for each layer

Adjusted according to tutorial at:
https://www.youtube.com/watch?v=jg2-9sRIUD4

Gilberto Echeverria
2021-04-04
*/

using UnityEngine;

public class BGParallax : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(cameraTransform.position.x * speed, cameraTransform.position.y * speed);
    }
}
