/*
Manager for the Break Out game

- Keep track of the points scored
- Restart the ball when it goes out of bounds
- Keep track of the number of lives remaining

Gilberto Echeverria
2024-03-20
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOutGameController : MonoBehaviour
{
    [SerializeField] Transform paddle;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] float brickOffset;
    [SerializeField] int rows;
    [SerializeField] int columns;

    // Variables to keep track of the game state
    [SerializeField] int score;
    [SerializeField] int lives;

    // Start is called before the first frame update
    void Start()
    {
        // Begin a new game
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialize the game state
    void InitGame()
    {
        // Set the initial values for the game
        score = 0;
        lives = 3;
        CreteBricks();
        RestartGame();
    }

    // Add points to the score
    public void AddPoints(int points)
    {
        score += points;
    }

    // Remove a life from the player
    public void LoseLife()
    {
        lives--;
        // Check if the game is over
        if (lives <= 0) {
            GameOver();
        } else {
            RestartGame();
        }
    }

    // Restart the game
    void GameOver()
    {
        // Reset the game state
        Debug.Log("GAME OVER!");
    }

    // Restart the game
    public void RestartGame()
    {
        // Restart the ball
        Vector3 position = paddle.position + new Vector3(0, 0.5f, 0);
        GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
        ball.transform.SetParent(paddle);
        paddle.GetComponent<PaddleControlBreakOut>().ball = ball;
    }

    // Fill the field with multiple bricks
    void CreteBricks()
    {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                Vector3 position = new Vector3(-6.5f + brickOffset * j, 2 - i, 0);
                GameObject brick = Instantiate(brickPrefab, position, Quaternion.identity);
                brick.GetComponent<SpriteRenderer>().color = Color.HSVToRGB((float)j / columns, 0.5f + ((float)i / rows) / 2, 1);
            }
        }
    }
}