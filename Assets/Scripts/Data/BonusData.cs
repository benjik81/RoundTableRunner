using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObject/BonusData")]
public class BonusData : ObstacleData
{
    [Header("Bonus Only")]
    public float duration;

}