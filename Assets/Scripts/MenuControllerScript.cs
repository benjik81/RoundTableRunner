using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuControllerScript : MonoBehaviour
{
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
    [SerializeField] private Slider BGMSlider = null;
    [SerializeField] private float defaultBGM = 1.0f;

    public void Start()
    {
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        volumeTextValue.text = volumeSlider.value.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }
    
    /*
    public void SetBGM(float bgm)
    {
        AudioListener.volume = bgm;
        volumeTextValue.text = bgm.ToString("0.0");
    }

    public void BGMApply()
    {
        //PlayerPrefs.SetFloat("masterBGM", AudioListener.)
        //StartCoroutine(ConfirmationBox());
    }*/

    public void ModificationApply()
    {
        VolumeApply();
        SetName();
    }

    public void ResetButton()
    {

        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString();
        VolumeApply();

        gameData.playerName = "";
        gameData.arthurKeyCode = KeyCode.R;
        gameData.percevalKeyCode = KeyCode.E;
        gameData.lancelotKeyCode = KeyCode.Z;
        gameData.gauvainKeyCode = KeyCode.A;
    }

    public void BackButton()
    {
        user_prenom.text = "";
    }

    public void Update_username()
    {
        user_prenom.text = gameData.playerName;
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    public void SetName()
    {
        if (user_prenom.text != "")
            gameData.playerName = user_prenom.text;

        PlayerPrefs.SetString("Username", user_prenom.text);
    }



    //Systeme de sauvegarde

    public static void SavedPlayer()
    {
        GameDataScript gameData = new GameDataScript();

        string path = Application.persistentDataPath + "/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(stream, gameData);

        stream.Close();
    }

    private GameDataScript LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameDataScript gameData = formatter.Deserialize(stream) as GameDataScript;

            stream.Close();

            return gameData;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}