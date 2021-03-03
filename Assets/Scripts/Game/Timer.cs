using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Variables visible from Unity
    [SerializeField] int timer;
    [SerializeField] Text textTime;
    [SerializeField] Text textMessage;

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
        dropper.StopBalls();
        CancelInvoke();
        textMessage.text = "GAME OVER\nPress 'R' key to restart";
    }
}
