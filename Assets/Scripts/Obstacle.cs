using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{

    public ObstacleData obstacleData;

    public virtual void Update()
    {

        transform.Translate(new Vector3(0, 0, 1) * -obstacleData.speed * GameManager.instance.scrollingMultiplier * Time.deltaTime);
    }

}
