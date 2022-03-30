using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> allObstacles = new List<GameObject>();
    IntRange[] obstacleProbability;
    int overlap;
    public float maxDistance; //How far are obstacle detected in the same floor

    void Start()
    {
        //Important note: place your obstacles
        //in the folder called "Resources" like this "Assets/Resources/Obstacle"
        Object[] subListObjects = Resources.LoadAll("Obstacle", typeof(GameObject));
        obstacleProbability = new IntRange[subListObjects.Length];

        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;

            allObstacles.Add(lo);

            obstacleProbability[allObstacles.Count - 1] = new IntRange(allObstacles.Count, allObstacles.Count - 1, lo.GetComponent<Obstacle>().obstacleData.ProbabilityWeight);
            Debug.Log(allObstacles.Count);
        }
        overlap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (CanSpawn())
        {
            int randomIndex = RandomRange.Range(obstacleProbability);
            ObstacleData tempObs = allObstacles[randomIndex].GetComponent<Obstacle>().obstacleData;
            float randomFloor = Random.Range(tempObs.minFloor, tempObs.maxFloor + 1);

            Debug.DrawRay(new Vector3(transform.position.x, randomFloor, transform.position.z), -Vector3.forward * maxDistance,Color.green);

            if (!Physics.Raycast(new Vector3(transform.position.x, randomFloor, transform.position.z), -Vector3.forward, out hit,maxDistance))
            {

                GameObject temp = Instantiate(allObstacles[randomIndex]);

                temp.transform.position = new Vector3(transform.position.x, randomFloor, transform.position.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        overlap++;

    }

    private void OnTriggerExit(Collider other)
    {
        overlap--;
    }

    public bool CanSpawn()
    {
        return overlap == 0;
    }
}


