﻿/*
Adjust the time limit and store it in PlayerPrefs

Gilberto Echeverria
23/03/2021
*/

using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] InputField timeField;
    [SerializeField] int timeLimit = 0;

    int defaultTime = 30;

    void Start()
    {
        // Recover a default value from player prefs
        timeField.text = "" + timeLimit;
    }

    // Callback for the plus and minus buttons
    public void UpdateLimit(int delta)
    {
        timeLimit += delta;
        // Convert the number into a string to be able to display it
        timeField.text = "" + timeLimit;
        // Store the new value in the player prefs

    }
    
    // Callback when directly editing the input field
    public void ChangeLimit()
    {
        // Check if the input can be converted to int
        if (int.TryParse(timeField.text, out timeLimit))
        {
            // Store the new value in the player prefs
        }
        else
        {
            timeLimit = defaultTime;
        }
    }
}
