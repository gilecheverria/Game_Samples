using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool powerOn = false;
    public Sprite onSprite;
    public Sprite offSprite;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            // Toggle the switch
            powerOn = !powerOn;
            if (powerOn) {
                spriteRenderer.sprite = onSprite;
            }
            else {
                spriteRenderer.sprite = offSprite;
            }
        }
    }
}
