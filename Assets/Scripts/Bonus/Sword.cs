using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Bonus
{
    public SwordData swordData;
    Vector3 shootingPos;
    PlayerScript knight;
    float maxTimer;
    float maxTimertemp;
    bool started;
    public override void Effect(PlayerScript player)
    {
        started = true;
        knight = player;
        maxTimer = swordData.duration;
        maxTimertemp = maxTimer;

        foreach (Transform child in transform) // Removes all collider and graphics
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public override void Update()
    {
        if (!started)
        {
            transform.Translate(new Vector3(0, 0, 1) * -obstacleData.speed * GameManager.instance.scrollingMultiplier * Time.deltaTime);
        }
        else
        {
            if (maxTimer <= maxTimertemp - swordData.delay)
            {
                maxTimertemp = maxTimer;
                Shoot();
            }


            if (maxTimer < 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                maxTimer -= Time.deltaTime;
            }
        }
        
    }

    void Shoot()
    {
        shootingPos = knight.gameObject.transform.position + swordData.offSet;
        GameObject tempSword = Instantiate(swordData.swordPrefab);
        tempSword.transform.position = shootingPos;
        Projectile tempProj = tempSword.GetComponent<Projectile>();

        tempProj.SetProjectile(swordData.projSpeed, swordData.armor);
    }
}
