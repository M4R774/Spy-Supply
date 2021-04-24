using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles game logic things
public class GameManager : MonoBehaviour
{
    private bool atGameStart = true; // Has the game started for the first time
    void Awake()
    {
        //Init();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
    void Init() // This is called when the game first starts. Can later be used to reset game if modified.
    {
        if(atGameStart)
        {
            atGameStart = false;
            Scene gamePlayScene = SceneManager.GetSceneByName("Gameplay");
            if (gamePlayScene.isLoaded) // If for some reason the Gameplay scene been loaded, let's unload it
            {
                SceneManager.UnloadSceneAsync("Gameplay");
            }
            Scene scene = SceneManager.GetSceneByName("MainMenu");
            if (!scene.isLoaded) // If for some reason the scene has not been loaded, let's do so
            {
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
            }
        }
    }
}
