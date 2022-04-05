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

    [Header("Affichage")]
    [SerializeField] private TMP_Text Arthur_letter = null;
    [SerializeField] private TMP_Text Gauvain_letter = null;
    [SerializeField] private TMP_Text Lancelot_letter = null;
    [SerializeField] private TMP_Text Perceval_letter = null;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
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

        Arthur_letter.text = KeyCode.R.ToString();
        Gauvain_letter.text = KeyCode.A.ToString();
        Perceval_letter.text = KeyCode.E.ToString();
        Lancelot_letter.text = KeyCode.Z.ToString();


    }

    public void backButton()
    {
        user_prenom.text = "";
    }

    public void update_username()
    {
        user_prenom.text = gameData.playerName;
    }

    //TENTATIVE DE SAUVEGARDE = ECHEC POUR LE MOMENT

    public static void savedPlayer()
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
