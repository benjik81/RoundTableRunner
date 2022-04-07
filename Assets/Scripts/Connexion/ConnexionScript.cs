using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class ConnexionScript : MonoBehaviour
{
    [Header("Username zone")]
    [SerializeField] private TMP_InputField userName;
    [Header("Game Data")]
    [SerializeField] private GameDataScript gameData;


    void Start()
    {
        userName.text = gameData.playerName;
        
    }

    public void SetName()
    {
        gameData.playerName = userName.text;
        Save newSave = SaveSystem.LoadData();
        if(newSave.name == gameData.playerName)
        {
            gameData.highscore = newSave.highScore;
            gameData.lancelotKeyCode = (KeyCode)newSave.lancelotCode;
            gameData.arthurKeyCode = (KeyCode)newSave.arthurCode;
            gameData.gauvainKeyCode = (KeyCode)newSave.gauvainCode;
            gameData.percevalKeyCode = (KeyCode)newSave.percevalCode;
            gameData.music = newSave.bgm;
            gameData.volume = newSave.fx;
            gameData.score = newSave.score;
        }
        else
        {
            gameData.highscore = 0;
            gameData.lancelotKeyCode = KeyCode.G;
            gameData.arthurKeyCode = KeyCode.K;
            gameData.gauvainKeyCode = KeyCode.F;
            gameData.percevalKeyCode = KeyCode.J;
            gameData.music = 100;
            gameData.volume = 100;
            gameData.score = 0;
        }
    }

    public void resetName()
    {
        gameData.playerName = "";
    }
}
