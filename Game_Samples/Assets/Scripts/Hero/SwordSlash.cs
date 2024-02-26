/*
Methods for the sword slash

These are called from the animation on the swords

Gilberto Echeverria
2021-04-06
*/

using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void DetectHit()
    {
        // Check documentation at:
        // https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html
    }
}
