using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    GameState currentGameState = GameState.MainMenu;

    Scene playerScene;

    private void Awake()
    {
        if (controller != null && controller != this)
            Destroy(gameObject);
        else
            controller = this;
    }

    public void ChangeGameState(GameState newGameState)
    {
        currentGameState = newGameState;

        UIManager.controller.OnGameStateChanged(newGameState);
    }

    public void SpawnPlayer()
    {
        playerScene = SceneManager.LoadScene(1, new LoadSceneParameters(LoadSceneMode.Additive));
    }
    public void DestroyPlayer()
    {
        SceneManager.UnloadSceneAsync(playerScene);
    }


    public enum GameState
    {
        MainMenu,
        LevelSelect,
        Shop,
        Game
    }
}
