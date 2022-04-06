using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Bonus
{
    public FireBallData fireBallData;
    Vector3 shootingPos;
    public override void Effect(PlayerScript player)
    {
        foreach (var item in GameManager.instance.knights)
        {
            shootingPos = item.gameObject.transform.position + fireBallData.offSet;
            GameObject tempFireBall = Instantiate(fireBallData.fireBallPrefab);
            tempFireBall.transform.position = shootingPos;
            Projectile tempProj = tempFireBall.GetComponent<Projectile>();

            tempProj.SetProjectile(fireBallData.projSpeed, fireBallData.armor);
        }

        Destroy(this.gameObject);
        
    }
}
