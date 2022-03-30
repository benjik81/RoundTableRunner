using UnityEngine;

[CreateAssetMenu(menuName = "Create GameData")]

public class GameData : ScriptableObject
{
    public string PlayerName;

    public int Score = 0;

    private void OnEnable()
    {

    }

}
