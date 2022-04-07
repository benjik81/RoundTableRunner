using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacleData;


    
    public virtual void Update()
    {

        if(GameStateManager.Instance.CurrentGameState == GameState.Gameplay)
        {
            transform.Translate(new Vector3(0, 0, 1) * -obstacleData.speed * GameManager.instance.scrollingMultiplier * Time.deltaTime);
        }
        
    }

    public virtual void KillObstacle()
    {
        
        AudioSource.PlayClipAtPoint(obstacleData.sfx, transform.position, GameManager.instance.gameData.volume / 100);
        Destroy(this.gameObject);
    }

    public virtual void PlaySFX()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = obstacleData.sfx;
        audio.volume = GameManager.instance.gameData.volume / 100;
        audio.Play();
    }
}
