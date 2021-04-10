using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles pausing the game. Esc brings up the main menu
public class PauseControl : MonoBehaviour
{
    public GameObject mainMenu;
    public static bool gameIsPaused;

    void Start()
    {
        if(mainMenu == null)
        {
            mainMenu = GameObject.FindGameObjectWithTag("Pause Menu");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame ()
    {
        if(gameIsPaused)
        {
            mainMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            mainMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
