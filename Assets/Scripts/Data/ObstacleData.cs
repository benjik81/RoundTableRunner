using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObject/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public int minFloor;
    public int maxFloor;
    public float ProbabilityWeight; // Higher is more likely
    public float speed;
    public AudioClip sfx;

    public ObstacleType obstacleType;

}
