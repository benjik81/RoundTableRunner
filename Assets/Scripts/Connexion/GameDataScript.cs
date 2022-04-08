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
    public KeyCode lancelotKeyCode = KeyCode.F;
    public KeyCode gauvainKeyCode = KeyCode.D;

    public int volume = 100;
    public int music = 100;

    public int highscore = 0;

    private void OnEnable()
    {

    }

}
