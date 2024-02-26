/*
 * Script on the colliders of a wire,
 * detects when in contact with another object and informs the parent
 *
 * Gilberto Echeverria
 * 2021-03-23
 */

using UnityEngine;

public class WireConnection : MonoBehaviour
{
    public GameObject who = null;
    public bool connected = false;

    WireCenter wire;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the script on the parent
        wire = transform.parent.GetComponent<WireCenter>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        who = col.gameObject;
        connected = true;
        // Tell the parent who are we connecting to
        UpdateConnection(who);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        who = null;
        connected = false;
        // Tell the parent a connection has been severed
        UpdateConnection(who);
    }

    // Update the values on the parent
    void UpdateConnection(GameObject other) {
        if (tag == "Left") {
            wire.myLeft = other;
        }
        else if (tag == "Right") {
            wire.myRight = other;
        }
    }
}
