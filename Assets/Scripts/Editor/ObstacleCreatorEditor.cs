using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObstacleCreator))]
public class ObstacleCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObstacleCreator obstacleCreator = (ObstacleCreator)target;


        if (GUILayout.Button("Create Shape"))
        {
            Debug.Log("ShapeCreated");
            obstacleCreator.CreateShape();
        }

        if (GUILayout.Button("Delete All"))
        {
            Debug.Log("All gone");
            obstacleCreator.ClearObstacle();
        }

        if(GUILayout.Button("Pack Object"))
        {
            Debug.Log("Object packed");
            obstacleCreator.PackIntoObject();
        }
    }
}
