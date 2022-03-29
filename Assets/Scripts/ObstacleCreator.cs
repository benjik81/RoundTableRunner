using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Shape
{
    Stairs,
    Square
}
public class ObstacleCreator : MonoBehaviour
{
    GameObject[] listOfShapes;
    
    [Header("Square only")]
    public int sizeY;
    public int sizeZ;

    [Header("Stairs only")]
    public int steps;
    public int stepSize;
    public bool mirorred;
    public int topSize;

    public Shape shape;

    [Header("Obstacle")]
    public string obstacleName;
    public void CreateSquare()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(1, sizeY, sizeZ);
        cube.transform.position = new Vector3(0, 0.5f * sizeY, 0.5f*sizeZ);

        cube.tag = "Obstacle";
        
        
        listOfShapes = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    public void CreateStairs()
    {
        float scaleSizeZ;
        float scaleSizeY;
        if (mirorred)
        {
            scaleSizeZ = steps * stepSize * 2 - 1 + topSize;
            scaleSizeY = 0.5f;

            for (int i = 0; i < steps; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(1, 1, scaleSizeZ);
                cube.transform.position = new Vector3(0, scaleSizeY, (0.5f * scaleSizeZ) + (i * stepSize));

                cube.tag = "Obstacle";
                scaleSizeZ -= stepSize*2;
                scaleSizeY++;
            }
        }
        else
        {
            scaleSizeZ = steps * stepSize + topSize;
            scaleSizeY = 0.5f;
            for (int i = 0; i < steps; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(1, 1, scaleSizeZ);
                cube.transform.position = new Vector3(0, scaleSizeY, (0.5f * scaleSizeZ) + (i * stepSize));

                cube.tag = "Obstacle";
                scaleSizeZ -= stepSize;
                scaleSizeY++;
            }
        }
        

        listOfShapes = GameObject.FindGameObjectsWithTag("Obstacle");
    }


    public void ClearObstacle()
    {
        for (int i = 0; i < listOfShapes.Length; i++)
        {
            DestroyImmediate(listOfShapes[i]);
        }
    }

    public void CreateShape()
    {
        if (listOfShapes!=null)
        {
            ClearObstacle();
        }
            
        switch (shape)
        {
            case Shape.Stairs:
                CreateStairs();
                break;
            case Shape.Square:
                CreateSquare();
                break;
            default:
                break;
        }
    }

    public void PackIntoObject() // Create an obstacle with correct parenting
    {
        var obj = new GameObject();
        obj.tag = "Obstacle";
        obj.name = obstacleName;

        var coll = new GameObject();
        coll.tag = "Obstacle";
        coll.name = "Colliders";

        var graph = new GameObject();
        graph.tag = "Obstacle";
        graph.name = "Graphics";

        ConvertToCollider();

        for (int i = 0; i < listOfShapes.Length; i++)
        {
            listOfShapes[i].transform.SetParent(coll.transform);
        }

        coll.transform.SetParent(obj.transform);
        graph.transform.SetParent(obj.transform);
        obj.AddComponent<Obstacle>();
        listOfShapes = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    public void ConvertToCollider() // Convert all meshes to trigger colliders
    {
        for (int i = 0; i < listOfShapes.Length; i++)
        {
            listOfShapes[i].GetComponent<MeshRenderer>().enabled = false;
            listOfShapes[i].GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
