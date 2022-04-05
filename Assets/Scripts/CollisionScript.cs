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
        if(other.tag == "Obstacle")
        {
            Debug.Log("Touché!");
            //Destroy(transform.parent.gameObject);
            playerScript.CollisionObstacle();
        }
        
        if(other.tag == "Bonus")
        {
            playerScript.GetBonus(other.gameObject);
        }
    }
}
