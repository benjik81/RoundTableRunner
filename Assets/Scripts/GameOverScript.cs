using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TMP_Text score_Text;
    [SerializeField] private GameDataScript gameData;
    private int score;

    public void Start()
    {
        score = gameData.score;
        DisplayScore();
        UpdateHighScore();
        SaveSystem.SaveData(gameData);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoardScene");
    }

    public void DisplayScore()
    {
        score_Text.text = score.ToString();
    }

    public void TryAgain()
    {
        if (gameData.score > gameData.highscore)
            gameData.highscore = gameData.score;
        gameData.score = 0;
        SceneManager.LoadScene("JumpTestScene");
    }

    public void UpdateHighScore()
    {
        if (gameData.score > gameData.highscore)
            gameData.highscore = gameData.score;
    }
}
