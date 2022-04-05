using UnityEngine;

//allows to add a Unity option to create the GameData object
[CreateAssetMenu(menuName = "Create GameData")]

public class GameDataScript : ScriptableObject
{
    //The data saved here is the player's name and score.
    public string playerName;

    public int score = 0;

    public KeyCode arthurKeyCode = KeyCode.K;
    public KeyCode percevalKeyCode = KeyCode.J;
    public KeyCode lancelotKeyCode = KeyCode.G;
    public KeyCode gauvainKeyCode = KeyCode.F;

    private void OnEnable()
    {

    }

}
