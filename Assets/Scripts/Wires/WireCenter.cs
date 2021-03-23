/*
 * Script to control whether a wire is receiving power
 * This object should have two children with Trigger colliders
 *
 * Gilberto Echeverria
 * 2021-03-23
 */

using UnityEngine;

public class WireCenter : MonoBehaviour
{
    // References to the child objects
    public GameObject myLeft;
    public GameObject myRight;

    public Sprite onSprite;
    public Sprite offSprite;

    SpriteRenderer spriteRenderer;

    public bool powerOn;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectConnection();
        SetSprite();
    }

    // Update the connection status
    void DetectConnection()
    {
        // detecting if there is a connection to the left to another wire
        if (myLeft != null && (myLeft.tag == "Right" || myLeft.tag == "Left")) {
            // When connecting to a wire endpoing, get the wire first
            powerOn = myLeft.transform.parent.GetComponent<WireCenter>().powerOn;
        }
        // Detect if connected to the left to a switch
        else if (myLeft != null && myLeft.tag == "Switch") {
            powerOn = myLeft.GetComponent<Switch>().powerOn;
        }
        // If there is no connection
        else {
            powerOn = false;
        }
    }

    // Light on or off depending on power
    void SetSprite()
    {
        if (powerOn) {
            spriteRenderer.sprite = onSprite;
        }
        else {
            spriteRenderer.sprite = offSprite;
        }
    }
}
