/*
 * Count down from a given amount of seconds
 * Stop the game when the time runs out
 *
 * Gilberto Echeverria
 * 23/03/2021
 */

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Variables visible from Unity
    [SerializeField] int timer;
    [SerializeField] Text textTime;
    [SerializeField] Text textMessage;

    // Reference to another script
    DropBalls dropper;

    void Start()
    {
        dropper = GetComponent<DropBalls>();
        InvokeRepeating("CountDown", 1, 1);
    }

    void CountDown()
    {
        timer--;
        textTime.text = "Time: " + timer;
        if (timer == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Stop the invokes in this and the other script
        dropper.StopBalls();
        CancelInvoke();
        textMessage.text = "GAME OVER\nPress 'R' key to restart";
    }
}
