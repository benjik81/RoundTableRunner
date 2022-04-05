using UnityEngine;

//allows to add a Unity option to create the GameData object
[CreateAssetMenu(menuName = "Create GameData")]

public class GameDataScript : ScriptableObject
{
    //The data saved here is the player's name and score and key codes and the volume's value.
    public string playerName;

    public int score = 0;

    public KeyCode arthurKeyCode = KeyCode.K;
    public KeyCode percevalKeyCode = KeyCode.J;
    public KeyCode lancelotKeyCode = KeyCode.G;
    public KeyCode gauvainKeyCode = KeyCode.F;

    public float volume = 1.0f;

    private void OnEnable()
    {

    }

}
