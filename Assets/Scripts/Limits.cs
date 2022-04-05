using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" || other.tag == "Projectile")
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}
