using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioSource bgm;

    public GameDataScript gameData;
    // Start is called before the first frame update
    void Awake()
    {
        if (!audioSource)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (!bgm)
        {
            bgm = gameObject.AddComponent<AudioSource>();
        }

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        bgm.volume = gameData.music/100f;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.volume = gameData.volume/100f;
        audioSource.PlayOneShot(clip);
    }
}
