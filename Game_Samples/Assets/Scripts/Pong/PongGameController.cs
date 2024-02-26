/*
Script to control the flow of the Pong game

Gilberto Echeverria
2024-02-19
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongGameController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float ballSpeed;

    [SerializeField] int score1;
    [SerializeField] int score2;

    [SerializeField] TMP_Text player1Score;
    [SerializeField] TMP_Text player2Score;

    [SerializeField] int maxScore;

    GameObject ball;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component for the sound
        source = GetComponent<AudioSource>();
        // Create the first ball
        StartCoroutine(WaitAndStartRound(0));
    }

    void Update()
    {
        // Reset the ball
        if (Input.GetKeyDown(KeyCode.R)) {
            Destroy(ball);
            StartCoroutine(WaitAndStartRound(1));
        }
    }

    // Restart a game after a few seconds
    IEnumerator WaitAndStartRound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ball = Instantiate(ballPrefab);
        Vector2 direction = Random.onUnitSphere;
        ball.GetComponent<Rigidbody2D>().velocity = direction.normalized * ballSpeed;
    }

    // Update the score for the players
    public void Score(int player)
    {
        // Sound to indicate a score
        source.Play();
        // Update the points and display in the UI
        if (player == 1) {
            score1++;
            if (score1 >= maxScore) {
                player1Score.text = "WINNER: " + score1.ToString() + "!";
            } else {
                player1Score.text = score1.ToString();
                StartCoroutine(WaitAndStartRound(2));
            }
        } else {
            score2++;
            if (score2 >= maxScore) {
                player2Score.text = "WINNER: " + score2.ToString() + "!";
            } else {
                player2Score.text = score2.ToString();
                StartCoroutine(WaitAndStartRound(2));
            }
        }
    }
}