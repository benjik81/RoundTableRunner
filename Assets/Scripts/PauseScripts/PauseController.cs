using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseView;
    [Header("Connexion Settings")]
    [SerializeField] private TMP_InputField user_prenom;
    [SerializeField] private GameDataScript gameData;

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPrompt = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("BGM settings")]
    [SerializeField] private TMP_Text volumeBGMValue = null;
    [SerializeField] private Slider bgmSlider = null;
    [SerializeField] private float defaultBGM = 1.0f;
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

    public void SetVolume()
    {
        //Here, I update the text of the slider according to the value of the bar.
        //And I update the sound volume of the game.
        AudioListener.volume = volumeSlider.value;
        volumeTextValue.text = volumeSlider.value.ToString("0.0");
    }

    public void SetMusic()
    {
        volumeBGMValue.text = bgmSlider.value.ToString("0.0");
    }

    public void VolumeApply()
    {
        //I save the player's preferences about the sound.
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
        gameData.volume = volumeSlider.value;
    }

    public void MusicApply()
    {
        PlayerPrefs.SetFloat("masterMusic", bgmSlider.value);
        StartCoroutine(ConfirmationBox());
        gameData.music = bgmSlider.value;
    }

    public void ModificationApply()
    {
        VolumeApply();
        MusicApply();
        SetName();
    }

    //We reset the gameData and the audio.
    public void ResetButton()
    {

        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString();
        VolumeApply();

        bgmSlider.value = defaultBGM;
        volumeBGMValue.text = defaultBGM.ToString();
        MusicApply();


        gameData.arthurKeyCode = KeyCode.K;
        gameData.percevalKeyCode = KeyCode.J;
        gameData.lancelotKeyCode = KeyCode.G;
        gameData.gauvainKeyCode = KeyCode.F;
    }

    //When we make a "return", I erase what the player has written
    public void BackButton()
    {
        user_prenom.text = "";
    }

    public void LoadVolumeAndMusic()
    {
        volumeSlider.value = gameData.volume;
        volumeTextValue.text = gameData.volume.ToString();
        bgmSlider.value = gameData.music;
        volumeBGMValue.text = gameData.music.ToString();
    }

    //We update the display of the nickname in the parameters
    public void Update_username()
    {
        user_prenom.text = gameData.playerName;
    }

    //Displays a "loading" box when the new settings are applied.
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    //The player's name is updated according to what he has entered.
    public void SetName()
    {
        if (user_prenom.text != "")
            gameData.playerName = user_prenom.text;

        PlayerPrefs.SetString("Username", user_prenom.text);
    }
}
