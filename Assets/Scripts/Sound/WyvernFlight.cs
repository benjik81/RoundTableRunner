using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyvernFlight : MonoBehaviour
{
    public AudioSource audioSource;

    public void Flap()
    {
        audioSource.volume = GameManager.instance.gameData.volume / 100;
        audioSource.Play();
    }
}
