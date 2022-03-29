using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> allObstacles = new List<GameObject>();

    void Start()
    {
        //Important note: place your obstacles
        //in the folder called "Resources" like this "Assets/Resources/Obstacle"
        Object[] subListObjects = Resources.LoadAll("Obstacle", typeof(GameObject));

        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;

            allObstacles.Add(lo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(allObstacles[0]);
            ObstacleData tempObs = temp.GetComponent<Obstacle>().obstacleData;

            float rnd = Random.Range(tempObs.minFloor, tempObs.maxFloor+1);

            temp.transform.position = new Vector3(transform.position.x, rnd, transform.position.z);
        }
    }
}
