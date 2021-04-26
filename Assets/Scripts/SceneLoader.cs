using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles loading and unloading between main menu and gameplay
// Scenes are always loaded on top of SceneManager scene, which holds important game logic stuff 
// This script needs to be in a prefab in order to use buttons for calling the methods
public class SceneLoader : MonoBehaviour
{
    public void LoadGame() // Loads gameplay and unloads main menu
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
        
        if (SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }

        if (SceneManager.GetSceneByBuildIndex(3).isLoaded)
        {
            SceneManager.UnloadSceneAsync("Ending");
        }
        
        Stats.ResetStats();
    }
    public void LoadMainMenu() // Loads main menu and unloads gameplay
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        if (SceneManager.GetSceneByBuildIndex(2).isLoaded)
        {
            SceneManager.UnloadSceneAsync("Gameplay");
        }

        if (SceneManager.GetSceneByBuildIndex(3).isLoaded)
        {
            SceneManager.UnloadSceneAsync("Ending");
        }
    }

    public void LoadEnding()
    {
        SceneManager.LoadSceneAsync("Ending", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay");
    }
}
