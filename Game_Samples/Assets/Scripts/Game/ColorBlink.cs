/*
Temporarily modify the colors of a sprite to make it blink
Useful when taking damage

Gilberto Echeverria
2023-03-19
*/

using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    [SerializeField] Color blinkColor;
    [SerializeField] float duration;
    [SerializeField] float multiplier;

    Color baseColor;
    Renderer render;
    float elapsed;
    float t;
    bool blinking;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the required components
        render = GetComponentInChildren<Renderer>();
        baseColor = render.material.color;
        blinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(blinking) {
            if(elapsed <= duration) {
                elapsed += Time.deltaTime;
                // Adjust the value of the sine function to be in range 0-1
                t = (Mathf.Sin(elapsed * multiplier) + 1) / 2;
                render.material.color = Color.Lerp(baseColor, blinkColor, t);
            } else {
                // When time runs out, restore the color
                blinking = false;
                render.material.color = baseColor;
            }
        }
    }

    // Public method to activate the effect
    public void Blink()
    {
        elapsed = 0;
        blinking = true;
    }
}