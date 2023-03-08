/*
Control the movement of the soldier
Movement is controlled with the directional inputs
Orientation is controlled with the mouse

Gilberto Echeverria
2023-03-07
*/

using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class SoldierControl : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 move;
    Vector2 mousePos;
    Vector3 direction;

    Rigidbody2D rb2D;

    Animator topAnimator;
    Animator feetAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        topAnimator = GameObject.Find("Top").GetComponent<Animator>();
        feetAnimator = GameObject.Find("Feet").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        
        if (move.x != 0 || move.y != 0) {
            Walk();
        } else {
            Stop();
        }
    }

    void Walk()
    {
        topAnimator.SetBool("Walking", true);
        feetAnimator.SetBool("Walking", true);
        rb2D.velocity = move * speed;
    }

    void Stop()
    {
        topAnimator.SetBool("Walking", false);
        feetAnimator.SetBool("Walking", false);
    }

    void Rotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("MousePos: " + mousePos);
        direction = mousePos - rb2D.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
