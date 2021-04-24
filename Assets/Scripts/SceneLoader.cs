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
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void LoadMainMenu() // Loads main menu and unloads gameplay
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay");
    }
    public void LoadWin()
    {
        SceneManager.LoadSceneAsync("Win", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay");
    }
    public void LoadFailed()
    {
        SceneManager.LoadSceneAsync("Failed", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay");
    }
}
