using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCellUI : MonoBehaviour
{
    string levelName;

    public void SetUp(LevelInfo levelInfo)
    {
        transform.Find("LevelCellName").GetComponent<TMP_Text>().text = levelInfo.displayName;

        levelName = levelInfo.levelName;

        GetComponent<Button>().interactable = levelInfo.playable;
        GetComponent<Button>().onClick.AddListener(StartLevel);
    }

    public void StartLevel()
    {
        LevelManager.controller.LoadLevel(levelName);
    }
}
