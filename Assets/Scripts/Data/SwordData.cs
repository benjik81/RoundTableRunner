using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObject/BonusData/Sword")]
public class SwordData : ScriptableObject
{
    public float duration;
    public Vector3 offSet;
    public float projSpeed;
    public int armor;

    public float delay;
    public GameObject swordPrefab;
}
