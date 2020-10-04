using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] gamePanels;

    public static UIManager controller;

    private void Awake()
    {
        if (controller != null && controller != this)
            Destroy(gameObject);
        else
            controller = this;
    }

    public void OnGameStateChanged(GameController.GameState newGameState)
    {
        for (int i = 0; i < gamePanels.Length; i++)
        {
            gamePanels[i].SetActive(i == (int)newGameState);
        }
    }

    public void LevelSelectButton()
    {
        GameController.controller.ChangeGameState(GameController.GameState.LevelSelect);
    }
    public void EndlessButton()
    {
        
    }
    public void ShopButton()
    {
        
    }
}
