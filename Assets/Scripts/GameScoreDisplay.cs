using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreDisplay;
    [SerializeField] private GameDataScript gameData;

    private void Update()
    {
        scoreDisplay.text = gameData.score.ToString();
    }
}
