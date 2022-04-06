using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseView;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
            ? GameState.Paused
            : GameState.Gameplay;

            GameStateManager.Instance.SetState(newGameState);

            switch (newGameState)
            {
                case GameState.Paused:
                    pauseView.SetActive(true);
                    break;
                case GameState.Gameplay:
                    pauseView.SetActive(false);
                    break;
            }
        }
    }

    public void Replay()
    {


        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        currentGameState = GameState.Gameplay;

        GameStateManager.Instance.SetState(currentGameState);
    }

    public void BackButton()
    {

    }
}
