/*
Add points every time a ball passess through the net

Gilberto Echeverria
2021-02-26
*/

using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    // Variables visible from Unity
    [SerializeField] Text textScore;
    [SerializeField] AudioSource asScore;
    [SerializeField] AudioSource asBounce;

    // Made score public so that it could be accessed from the wwwFormGameData script
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        score++;
        asScore.Play();
        textScore.text = "Score: " + score;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        asBounce.Play();
    }
}
