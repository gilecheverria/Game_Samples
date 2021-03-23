/*
 * This script should be added to an object with a Trigger collider
 * It will then destroy any other object that enters the trigger
 *
 * Gilberto Echeverria
 * 2021-03-23
 */

using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
