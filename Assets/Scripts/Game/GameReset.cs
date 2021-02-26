/*
Reload a scene when pressing a button

Gilberto Echeverria
18/02/2021
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Physics2D");
        }
    }


}
