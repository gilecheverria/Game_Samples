/*
Adjust the time limit and store it in PlayerPrefs
Also store the changes to the toggle for obstacles in the game

Gilberto Echeverria
2021-03-23
*/

using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] InputField timeField;
    [SerializeField] public int timeLimit = 0;
    [SerializeField] Toggle obstaclesToggle;

    int defaultTime = 5;

    void Start()
    {
        // Recover a default value from player prefs
        timeLimit = PlayerPrefs.GetInt("TimeLimit", defaultTime);
        timeField.text = "" + timeLimit;

        // Set the toggle value to what is currently stored in PlayerPrefs
        obstaclesToggle.isOn = PlayerPrefs.GetInt("Obstacles", 1) == 1;
        // Set a listener to the toggle to store the changes
        obstaclesToggle.onValueChanged.AddListener((value) => UpdateObstacles(value));
    }

    // Callback for the plus and minus buttons
    public void UpdateLimit(int delta)
    {
        timeLimit += delta;
        // Convert the number into a string to be able to display it
        timeField.text = "" + timeLimit;
        // Store the new value in the player prefs
        PlayerPrefs.SetInt("TimeLimit", timeLimit);
    }
    
    // Callback when directly editing the input field
    public void ChangeLimit()
    {
        // Check if the input can be converted to int
        if (int.TryParse(timeField.text, out timeLimit)) {
            // Store the new value in the player prefs
            PlayerPrefs.SetInt("TimeLimit", timeLimit);
        } else {
            timeLimit = defaultTime;
        }
    }

    void UpdateObstacles(bool enabled)
    {
        if (enabled) {
            PlayerPrefs.SetInt("Obstacles", 1);
        } else {
            PlayerPrefs.SetInt("Obstacles", 0);
        }
    }
}