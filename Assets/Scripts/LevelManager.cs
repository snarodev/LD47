using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelInfo[] levels;

    public static LevelManager controller;

    public Animator sceneTransition;

    Scene currentScene;
    string levelName;

    public LevelListUI levelListUI;

    private void Awake()
    {
        if (controller != null && controller != this)
            Destroy(gameObject);
        else
            controller = this;
    }

    public void LoadLevel(string levelName)
    {
        this.levelName = levelName;
        currentScene = SceneManager.LoadScene(levelName,new LoadSceneParameters (LoadSceneMode.Additive));
        //SceneManager.SetActiveScene(currentScene);
        GameController.controller.ChangeGameState(GameController.GameState.Game);
        GameController.controller.SpawnPlayer();
    }

    public void RestartCurrentLevel()
    {
        StartCoroutine("WaitRestartCurrentLevel");
    }

    public void ToLevelSelect()
    {
        int levelId = 0;

        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].levelName == levelName)
            {
                levelId = i;
                break;
            }
        }

        if (levelId + 1 < levels.Length)
            levels[levelId + 1].playable = true;

        levelListUI.RedrawUI();

        StartCoroutine("WaitToLevelSelect");
    }

    IEnumerator WaitToLevelSelect()
    {
        sceneTransition.SetTrigger("Transition");
        yield return new WaitForSeconds(0.25f);

        SceneManager.UnloadSceneAsync(currentScene);
        GameController.controller.DestroyPlayer();
        GameController.controller.ChangeGameState(GameController.GameState.LevelSelect);
    }


    IEnumerator WaitRestartCurrentLevel()
    {
        sceneTransition.SetTrigger("Transition");

        yield return new WaitForSeconds(0.25f);

        GameController.controller.DestroyPlayer();

        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(currentScene);

        yield return 0;



        asyncOperation.completed += (asyncdOperation) =>
        {
            LoadLevel(levelName);
        };

        //LoadLevel(levelName);

        NormalFunction();
    }

    void NormalFunction()
    {
        
    }


}
