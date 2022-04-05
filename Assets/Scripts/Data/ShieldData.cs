using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObject/BonusData/Shield")]
public class ShieldData : ScriptableObject
{
    public float duration;
    public GameObject aura;
}
