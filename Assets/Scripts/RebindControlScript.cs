using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RebindControlScript : MonoBehaviour
{
    public GameDataScript gameData;
    public GameObject playerControlZone;
    public TMP_InputField player_control;
    public TMP_Text placeholder;

    private KeyCode savedKeyCode;
    private KeyCode keyCodeConvert;

    public void Start()
    {
        switch (playerControlZone.name)
        {
            case "Arthur_controls":
                placeholder.text = gameData.arthurKeyCode.ToString();
                break;
            case "Perceval_controls":
                placeholder.text = gameData.percevalKeyCode.ToString();
                break;
            case "Lancelot_controls":
                placeholder.text = gameData.lancelotKeyCode.ToString();
                break;
            case "Gauvain_controls":
                placeholder.text = gameData.gauvainKeyCode.ToString();
                break;
        }
    }
    public void newControl()
    {
        saveKeyCode();
        //updateLetterControl();
        switch (playerControlZone.name)
        {
            case "Arthur_controls":
                gameData.arthurKeyCode = savedKeyCode;
                //PlayerPrefs.SetString("Arthur_key", savedKeyCode.ToString());
                break;
            case "Perceval_controls":
                gameData.percevalKeyCode = savedKeyCode;
                //PlayerPrefs.SetString("Perceval_key", savedKeyCode.ToString());
                break;
            case "Lancelot_controls":
                gameData.lancelotKeyCode = savedKeyCode;
                //PlayerPrefs.SetString("Lancelot_key", savedKeyCode.ToString());
                break;
            case "Gauvain_controls":
                gameData.gauvainKeyCode = savedKeyCode;
                //PlayerPrefs.SetString("Gauvain_key", savedKeyCode.ToString());
                break;
        }
    }

    public KeyCode convertStringToKeyCode(string value)
    {

        if (value.Length != 0)
        {
            var keycode = value.Substring(0, 1).ToLower();
            char[] keycodeV2 = keycode.ToCharArray();
            char keycodeFinal = keycodeV2[0];
            //Debug.Log(keycodeFinal);
            keyCodeConvert = (KeyCode)keycodeFinal;
        }

        return keyCodeConvert;

    }

    public void saveKeyCode()
    {
        savedKeyCode = convertStringToKeyCode(player_control.text);
    }

    public void updateLetterControl()
    {
        switch (playerControlZone.name)
        {
            case "Arthur_controls":
                placeholder.text = gameData.arthurKeyCode.ToString();
                break;
            case "Perceval_controls":
                placeholder.text = gameData.percevalKeyCode.ToString();
                break;
            case "Lancelot_controls":
                placeholder.text = gameData.lancelotKeyCode.ToString();
                break;
            case "Gauvain_controls":
                placeholder.text = gameData.gauvainKeyCode.ToString();
                break;
        }
    }

    public void clearTextZone()
    {
        player_control.text = "";
    }

}
