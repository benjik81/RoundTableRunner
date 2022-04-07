using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    AttackBehavior lastAttacking;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Obstacle tempObs = other.transform.root.GetComponent<Obstacle>();
            if (tempObs.obstacleData.obstacleType == ObstacleType.AttackingUnit)
            {
                AttackBehavior tempAttack = tempObs.GetComponentInChildren<AttackBehavior>();
                if (!lastAttacking || tempAttack == lastAttacking)
                {
                    lastAttacking = tempAttack;
                    lastAttacking.TriggerAttack();
                }
                   
            }
        }
    }
}
