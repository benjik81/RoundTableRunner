using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Bonus
{
    private SwordData swordData;
    Vector3 shootingPos;
    
    float maxTimer;
    float maxTimertemp;
    private void Start()
    {
        swordData = bonusData as SwordData;
    }

    public override void Effect(PlayerScript player)
    {
        base.Effect(player);
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
            if (GameStateManager.Instance.CurrentGameState == GameState.Gameplay)
                transform.Translate(new Vector3(0, 0, 1) * -obstacleData.speed * GameManager.instance.scrollingMultiplier * Time.deltaTime);
        }
        else
        {
            aura.transform.position = knight.transform.position + bonusData.auraOffSet;
            if (maxTimer <= maxTimertemp - swordData.delay)
            {
                maxTimertemp = maxTimer;
                Shoot();
            }


            if (maxTimer < 0)
            {
                ClearBonus();
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
