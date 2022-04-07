using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBall", menuName = "ScriptableObject/BonusData/Fire Ball")]
public class FireBallData : BonusData
{
    public GameObject fireBallPrefab;
    public float projSpeed;
    public int armor; // how many hits can they take
    public Vector3 offSet; // where does the fireball start
    
}
