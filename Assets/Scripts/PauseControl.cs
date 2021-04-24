using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles pausing the game. Esc brings up the pause menu
// NOTE game is paused by setting timeScale to 0
// this does not stop Update functions which means input is still possible
// thus all input should be put inside if conditions to check if game is paused
// more info: https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/

// The pause menu object is being set active and not active. We could also flip the canvas component active/not but this is easier.
public class PauseControl : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gameIsPaused;
    private Scene mainMenuScene;

    void Start()
    {
        if(pauseMenu == null) // If assigning the pause menu has been forgot let's write a reminder to the console
        {
            Debug.Log("Please assign the pause menu object");
        }
    }
    void Update()
    {
        mainMenuScene = SceneManager.GetSceneByName("MainMenu");
        if (!mainMenuScene.isLoaded) // Only show pause menu if we are not in main menu
        {
            if (Input.GetKeyDown(KeyCode.Escape)) // listens for pressing esc
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
        }
    }

    void PauseGame ()
    {
        if(gameIsPaused) // makes pause menu object visible, stops time
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else // hides pause menu, time continues
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void QuitGame() // application quits
    {
        Application.Quit();
    }
    public void FlipPauseBool() // Simulates exiting menu with esc
    {
        gameIsPaused = !gameIsPaused;
    }
    public void SetTimeScaleToNormal()
    {
        Time.timeScale = 1;
    }
}
