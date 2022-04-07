using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TMP_Text score_Text;
    [SerializeField] private GameDataScript gameData;

    public void Start()
    {
        DisplayScore();
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
        score_Text.text = gameData.score.ToString();
    }

    public void TryAgain()
    {
        if (gameData.score > gameData.highscore)
            gameData.highscore = gameData.score;
        gameData.score = 0;
        SceneManager.LoadScene("JumpTestScene");
    }
}
