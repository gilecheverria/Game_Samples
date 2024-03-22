/*
Reload a scene when pressing a button

Gilberto Echeverria
2021-02-18
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("BasketBall");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            SceneManager.LoadScene("Settings");
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene("Title");
        }
    }
}
