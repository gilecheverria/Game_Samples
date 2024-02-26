/*
Move an object (a bullet) in a straight line

Gilberto Echeverria
2023-20-02
*/

using UnityEngine;

public class StraightMotion : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }
}
