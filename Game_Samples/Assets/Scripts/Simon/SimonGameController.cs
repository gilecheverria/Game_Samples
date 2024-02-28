/*
Game manager for the clone of the Simon game

Gilberto Echeverria
2024-02-27
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimonGameController : MonoBehaviour
{
    [SerializeField] List<GameObject> buttonList;
    List<int> buttonSequence;
    List<int> playedButtons;

    [SerializeField] float soundDelay;
    [SerializeField] TMP_Text banner;
    [SerializeField] ParticleSystem particles;

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

    void InitGame()
    {
        buttonSequence = new List<int>();    
        playedButtons = new List<int>();    
        steps = 0;

        Invoke("NextStep", 2);
    }

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

    void Fail()
    {
        banner.text = "Fail! ----  Score: " + steps;
        audioSource.Play();
    }
}