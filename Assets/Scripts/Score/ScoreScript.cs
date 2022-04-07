using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private GameDataScript gameData;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            gameData.score += 100;
            Debug.Log("current score: " + gameData.score);
        }
    }
}
