/*
 * Toggle a switch on and off
 *
 * Gilberto Echeverria
 * 2021-03-23
 */

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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            // Toggle the switch when pressing the Left Mouse Button
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
