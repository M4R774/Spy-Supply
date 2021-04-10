using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay");
        
    }
}
