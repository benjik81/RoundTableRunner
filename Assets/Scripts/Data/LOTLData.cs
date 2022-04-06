using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LOTL", menuName = "ScriptableObject/BonusData/LadyOfTheLake")]
public class LOTLData : ScriptableObject
{
    public float duration;
    public float accelerationSpeed;
    public GameObject aura;
}
