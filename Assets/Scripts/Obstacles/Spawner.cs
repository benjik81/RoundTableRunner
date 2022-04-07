using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> allObstacles = new List<GameObject>();
    IntRange[] obstacleProbability;
    [SerializeField]
    int overlap; // Number of colliders in the collider (some obstacle have multiple colliders)
    float maxDistance; //How far are obstacle detected in the same floor (used in code limit)
    public float DistanceFlight;//How far are obstacle detected in the same floor (for flying object only)

    public float Distance;//How far are obstacle detected in the same floor

    float timer;
    public float maxTimer;

    [SerializeField]
    List<Obstacle> insideObstacle;

    void Start()
    {
        //Important note: place your obstacles
        //in the folder called "Resources" like this "Assets/Resources/Obstacle"
        Object[] subListObjects = Resources.LoadAll("Obstacle", typeof(GameObject));
        obstacleProbability = new IntRange[subListObjects.Length];

        insideObstacle = new List<Obstacle>();

        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;

            allObstacles.Add(lo);

            obstacleProbability[allObstacles.Count - 1] = new IntRange(allObstacles.Count, allObstacles.Count - 1, lo.GetComponent<Obstacle>().obstacleData.ProbabilityWeight);
            Debug.Log(allObstacles.Count);
        }

        overlap = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        try
        {
            foreach (var item in insideObstacle)
            {
                if (!item)
                {
                    overlap = 0;
                    insideObstacle.Remove(item);
                }

            }
        }
        catch (System.Exception) // throw an error if the list is empty
        {

            
        }

        
        
        if (CanSpawn() && timer>maxTimer) // Check if there is anything in the spawner
        {
            timer = 0;
            int randomIndex = RandomRange.Range(obstacleProbability);
            ObstacleData tempObs = allObstacles[randomIndex].GetComponent<Obstacle>().obstacleData;
            float randomFloor = Random.Range(tempObs.minFloor, tempObs.maxFloor + 1);

            if (tempObs.obstacleType == ObstacleType.FlyingObject)
            {
                maxDistance = DistanceFlight;
            }
            else
            {
                maxDistance = Distance;
            }

            Debug.DrawRay(new Vector3(transform.position.x, randomFloor, transform.position.z), -Vector3.forward * maxDistance,Color.green);

            

            if (!Physics.Raycast(new Vector3(transform.position.x, randomFloor, transform.position.z), -Vector3.forward, out hit,maxDistance) || 
                GetObstacleType(hit) == ObstacleType.Fog)
            {// Raycast that go from the level the object is supposed to spawn to a set distance (on Z) and spawn or not the object if there is anything in the WAY. Or if it's the fog which can 
                // spawn with objects inside

                GameObject temp = Instantiate(allObstacles[randomIndex]);

                temp.transform.position = new Vector3(transform.position.x, randomFloor, transform.position.z);
            }
        }
        
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            insideObstacle.Add(other.GetComponent<Obstacle>());
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            insideObstacle.Remove(other.GetComponent<Obstacle>());
        }
    }

    bool CanSpawn()
    {
        return overlap == 0;
    }

    public ObstacleType GetObstacleType(RaycastHit ray)
    {

        return ray.collider.transform.root.GetComponent<Obstacle>().obstacleData.obstacleType;
        
    }
}


