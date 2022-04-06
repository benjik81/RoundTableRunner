using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    int armor;
    /*
    private void Start()
    {
        speed = 0;
        armor = 0;
    }
    */

    // Update is called once per frame
    void Update()
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
            Debug.Log("something entered " + other.name);
            if (other.transform.root.TryGetComponent(out Obstacle obstacle))
            {
                if (obstacle.obstacleData.obstacleType != ObstacleType.Bonus)
                {
                    obstacle.KillObstacle();
                    armor--;
                }
            }
        }

       
    }
}
