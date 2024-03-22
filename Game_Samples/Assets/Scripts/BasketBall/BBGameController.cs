/*
Game controller for the Basket Ball game

Keeps track of the time left in the game, using the settings stored as PlayerPrefs.
 
Gilberto Echeverria
2021-03-23
*/

using UnityEngine;
using UnityEngine.UI;

public class BBGameController : MonoBehaviour
{
    // Variables visible from Unity
    [SerializeField] Text textTime;
    [SerializeField] Text textMessage;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject obstacles;

    // This script is needed to start a coroutine that uploads the game data to the api.
    wwwFormGameData sendGameData;

    int timer;
    public int timeLimit;

    DropBalls dropper;

    void Start()
    {
        // Get the value from the settings scene
        timer = PlayerPrefs.GetInt("TimeLimit");
        if (PlayerPrefs.GetInt("Obstacles", 1) == 1) {
            obstacles.SetActive(true);
        } else {
            obstacles.SetActive(false);
        }
        // Initialize the display text
        timeLimit = timer;
        textTime.text = "Time: " + timer;
        InvokeRepeating("CountDown", 1, 1);

        dropper = GetComponent<DropBalls>();

        sendGameData = GetComponent<wwwFormGameData>();
    }

    void CountDown()
    {
        timer--;
        textTime.text = "Time: " + timer;
        if (timer == 0) {
            GameOver();
        }
    }

    void GameOver()
    {
        // Stop the invokes in this and the other script
        dropper.StopBalls();
        CancelInvoke();
        gameOverPanel.SetActive(true);

        // After the game ends, we make a request to the api through the
        // uploadData method.
        StartCoroutine(sendGameData.uploadData());
    }
}
