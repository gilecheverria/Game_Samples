using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horizontal : MonoBehaviour
{
    // Variables visible from Unity interface
    [SerializeField] float speed;
    [SerializeField] Text textScore;

    // Instance variables
    Vector3 motion;
    int score = 0;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        motion.x = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + motion * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        score++;
        audioSource.Play();
        textScore.text = "Score: " + score;
        //Debug.Log("Score: " + score);
    }
    
}
