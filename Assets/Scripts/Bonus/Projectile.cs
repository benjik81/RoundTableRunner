using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int armor;

    public AudioClip sfx;
    AudioSource sourceSfx;
    private void Awake()
    {
        if (!sourceSfx)
        {
            sourceSfx = gameObject.AddComponent<AudioSource>();
        }

        sourceSfx.clip = sfx;
        sourceSfx.volume = GameManager.instance.gameData.volume / 100;
        sourceSfx.Play();


    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        if (armor < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetProjectile(float s, int a)
    {
        armor = a;
        speed = s;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Obstacle")
        {
            Debug.Log(armor);
            armor -= 1;
            Debug.Log("something entered " + other.name);
            if (other.transform.root.TryGetComponent(out Obstacle obstacle))
            {
                if (obstacle.obstacleData.obstacleType != ObstacleType.Bonus)
                {
                    
                    obstacle.KillObstacle();
                    
                }
            }
        }


    }
}
