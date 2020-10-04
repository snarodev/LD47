using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelInfo
{
    public string displayName;
    public string levelName;

    public bool playable;
}

public class LevelListUI : MonoBehaviour
{
    
    public Transform listParent;

    public GameObject levelCellPrefab;



    private void Start()
    {
        RedrawUI();
    }

    public void RedrawUI()
    {
        foreach (Transform child in listParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < LevelManager.controller.levels.Length; i++)
        {
            GameObject go = Instantiate(levelCellPrefab, listParent);

            go.GetComponent<LevelCellUI>().SetUp(LevelManager.controller.levels[i]);
        }

    }

    public void BackToMainMenu()
    {
        GameController.controller.ChangeGameState(GameController.GameState.MainMenu);
    }
}
