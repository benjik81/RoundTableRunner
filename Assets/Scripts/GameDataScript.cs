using UnityEngine;

//allows to add a Unity option to create the GameData object
[CreateAssetMenu(menuName = "Create GameData")]

public class GameDataScript : ScriptableObject
{
    //The data saved here is the player's name and score.
    public string PlayerName;

    public int Score = 0;

    private void OnEnable()
    {

    }

}
