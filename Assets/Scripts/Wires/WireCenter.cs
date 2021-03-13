using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCenter : MonoBehaviour
{
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
        // Update the connection status
        if (myLeft != null && (myLeft.tag == "Right" || myLeft.tag == "Left")) {
            // When connecting to a wire endpoing, get the wire first
            powerOn = myLeft.transform.parent.GetComponent<WireCenter>().powerOn;
        }
        else if (myLeft != null && myLeft.tag == "Switch") {
            powerOn = myLeft.GetComponent<Switch>().powerOn;
        }
        else {
            powerOn = false;
        }
        // Light on or off depending on power
        if (powerOn) {
            spriteRenderer.sprite = onSprite;
        }
        else {
            spriteRenderer.sprite = offSprite;
        }
    }
}
