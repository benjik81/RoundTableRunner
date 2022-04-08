using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    [Header("Settings")]
    public float scrollSpeed;
    public float spawnX; // x value where we spawn the new background
    public float destroyX; // x value where we destroy this background
    //private float middleX; // x value where we trigger the spawn of the next background
    private bool nextBGSpawned = false;

    public float xValueTriggerSpawn = 20;

    [Header("Backgrounds")]
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    private GameObject nextBG;

    // Start is called before the first frame update
    void Start()
    {

        // TO DO
        // Make a GameManager to apply new scrollSpeed when we loses knights
        
        SelectNextBG();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStateManager.Instance.CurrentGameState == GameState.Gameplay)
        {
            Scroll(); 
        }

        if(!nextBGSpawned)
        {
            //if(transform.position.x <= xValueTriggerSpawn)
            if(transform.position.z <= xValueTriggerSpawn)
            {
                nextBGSpawned = true; // each background only spawn the one following it
                SpawnNextBG();
            }
        }

        // Background far enough, Destroy it
        //if(transform.position.x < destroyX /*+ (transform.localScale.x / 4)*/)
        if(transform.position.z < destroyX)
        {
            //Debug.Log(name + " en fin de course. pos actuelle: " + transform.position.z + " valeur de destruction: " + destroyX);
            Destroy(gameObject);
        }
    }

    private void Scroll()
    {
        //float newX = transform.position.x - (scrollSpeed * Time.deltaTime);
        float newX = transform.position.z - (scrollSpeed * GameManager.instance.scrollingMultiplier * Time.deltaTime);
        //transform.position = new Vector3(newX, 3.5f, 1);
        transform.position = new Vector3(0, 0, newX);
    }

    // Randomly choose the next background
    private void SelectNextBG()
    {
        float rng = Random.value;
        if(rng < 0.33f)
        {
            nextBG = bg1;
            //Debug.Log("bg1");
        }
        else if(rng < 0.66f)
        {
            nextBG = bg2;
            //Debug.Log("bg2");
        }
        else
        {
            nextBG = bg3;
            //Debug.Log("bg3");
        }
    }


    private void SpawnNextBG()
    {
        if(nextBG != null)
        {
            Instantiate(nextBG, new Vector3(0, 3.5f, spawnX + (transform.position.z - xValueTriggerSpawn)), Quaternion.Euler(new Vector3(0, 90, 0)));
        }
    }
}
