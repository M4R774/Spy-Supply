using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles game logic things
public class GameManager : MonoBehaviour
{
    private bool atGameStart = true; // Has the game started for the first time
    [SerializeField] bool skipToGameplay = false;
    [SerializeField] SceneLoader sceneLoader;
    public int numberOfWonMissions = 0;
    public int numberOfFailedMissions = 0;
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
        if(numberOfWonMissions == 3)
        {
            sceneLoader.LoadWin();
        }
        if(numberOfFailedMissions == 3)
        {
            sceneLoader.LoadFailed();
        }
    }
    void Init() // This is called when the game first starts. Can later be used to reset game if modified.
    {
        if(atGameStart)
        {
            atGameStart = false;
            Scene scene = SceneManager.GetSceneByName("MainMenu");
            Scene gamePlayScene = SceneManager.GetSceneByName("Gameplay");

            if(!skipToGameplay)
            {
                if (gamePlayScene.isLoaded) // If for some reason the Gameplay scene been loaded, let's unload it
                {
                    SceneManager.UnloadSceneAsync("Gameplay");
                }
                if (!scene.isLoaded) // If for some reason the scene has not been loaded, let's do so
                {
                    SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
                }
            }
            else
            {
                if (!gamePlayScene.isLoaded) // If for some reason the Gameplay scene been loaded, let's unload it
                {
                    SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
                }
                if (scene.isLoaded) // If for some reason the scene has not been loaded, let's do so
                {
                    SceneManager.UnloadSceneAsync("MainMenu");
                }
            }
        }
    }
}
