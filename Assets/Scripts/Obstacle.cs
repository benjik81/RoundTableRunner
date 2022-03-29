using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{

    public ObstacleData obstacleData;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * -obstacleData.speed * Time.deltaTime);
    }

}
