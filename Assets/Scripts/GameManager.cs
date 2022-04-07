using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameDataScript gameData;
    public List<PlayerScript> knights;

    
    public Bonus lastBuff;

    public float scrollingMultiplier;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        scrollingMultiplier = 1;
    }

    private void Start()
    {
        
    }

    
}
