using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Bonus
{
    private FireBallData fireBallData;
    Vector3 shootingPos;

    private void Start()
    {
        fireBallData = bonusData as FireBallData;
    }
    public override void Effect(PlayerScript player)
    {
        base.Effect(player);
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
