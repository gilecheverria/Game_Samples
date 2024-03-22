/*
Game manager for the clone of the Simon game

Gilberto Echeverria
2024-02-27
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimonGameController : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] List<GameObject> buttonList;
    [SerializeField] int buttonCount;
    [SerializeField] Transform buttonParent;

    [SerializeField] float soundDelay;
    [SerializeField] TMP_Text banner;
    [SerializeField] ParticleSystem particles;

    List<int> buttonSequence;

    AudioSource audioSource;

    int steps;
    int currentIndex;

    bool playerTurn;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InitGame();
    }

    // Prepare everything to start a new game
    void InitGame()
    {
        buttonSequence = new List<int>();    
        steps = 0;
        MakeButtons();

        Invoke("NextStep", 2);
    }

    // Create as many buttons as indicated in the buttonCount variable
    void MakeButtons()
    {
        for (int i=0; i<buttonCount; i++) {
            int id = i;
            GameObject newButton = Instantiate(buttonPrefab, transform);
            // Make the buttons children of a panel with a grid layout
            newButton.transform.SetParent(buttonParent);
            // Set the callback for the buttons
            newButton.GetComponent<Button>().onClick.AddListener(delegate { CheckButton(id); });
            // Set the sounds for the buttons
            newButton.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/" + (id % 9));
            // Change the color of the button
            newButton.GetComponent<Image>().color = Color.HSVToRGB((float)id / buttonCount, 0.8f, 0.8f);
            // Store the button in the list
            buttonList.Add(newButton);
        }
    }

    // Generate the next number in the sequence and show the full sequence
    void NextStep()
    {
        banner.text = "";
        playerTurn = false;
        currentIndex = 0;
        steps++;
        // Generate the next button in the sequence
        buttonSequence.Add(Random.Range(0, buttonList.Count));
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        foreach (int index in buttonSequence) {
            buttonList[index].GetComponentInChildren<ImageBlink>().Blink();
            yield return new WaitForSeconds(soundDelay);
        }
        playerTurn = true;
        currentIndex = 0;
    }

    // Validate that the button clicked by the player is the correct one
    public void CheckButton(int buttonID)
    {
        if (playerTurn) {
            if (buttonID == buttonSequence[currentIndex]) {
                buttonList[buttonID].GetComponentInChildren<ImageBlink>().Blink();
                currentIndex++;
                if (currentIndex == buttonSequence.Count) {
                    banner.text = "OK!";
                    particles.Emit(10);
                    Invoke("NextStep", 1);
                }
            } else {
                Fail();
            }
        }
    }

    // Show the fail message and play a sound
    void Fail()
    {
        banner.text = "Fail! ----  Score: " + steps;
        audioSource.Play();
    }
}