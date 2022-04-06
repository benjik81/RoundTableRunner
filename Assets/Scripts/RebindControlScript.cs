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
        //Depending on the character, I check the saved key and display it in the placeholder.
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

    //This function is there to assign a new key to the character targeted by the player.
    //I save the new button in my GameData.
    public void NewControlCommand()
    {
        SaveKeyCode();
        if(savedKeyCode != KeyCode.None)
        {
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
        
    }

    //This function allows to convert a String into a KeyCode.
    //Necessary because I use an InputField, so it's TextMeshPro, so String
    //I want a KeyCode to assign the keys.
    public KeyCode ConvertsStringToKeyCode(string value)
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
    //Small function to save the key to be assigned when applying the changes in the parameters
    public void SaveKeyCode()
    {
        savedKeyCode = ConvertsStringToKeyCode(player_control.text);
    }

    //Function to update the display of the key.
    public void UpdateLetterControl()
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

    //cleans up the text area to avoid double display due to the placeholder.
    public void ClearTextZone()
    {
        player_control.text = "";
    }

}
