using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private PlayerScript playerScript;

    void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if (other.transform.root.TryGetComponent(out Obstacle obstacle))
            {
                if (obstacle.obstacleData.obstacleType == ObstacleType.Bonus)
                {
                    playerScript.GetBonus(obstacle as Bonus);
                    Debug.Log("Bonunus");
                }
                else
                {
                    Debug.Log("Touché!");
                    if (playerScript.currentBuff && playerScript.currentBuff.bonusType == BonusType.Shield)
                    {
                        obstacle.KillObstacle();
                    }
                    //Destroy(transform.parent.gameObject);
                    playerScript.CollisionObstacle();
                }
            }

        }


    }
}
