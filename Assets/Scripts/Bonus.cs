using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Obstacle
{
    public BonusType bonusType;
    protected bool started;
    public BonusData bonusData;
    protected GameObject aura;
    protected PlayerScript knight;
    public virtual void Effect(PlayerScript player)
    {
        SpawnAura(player);
        knight = player;

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
            UpdateAfterStarted();
        }
    }

    public virtual void ClearBonus()
    {
        GameManager.instance.lastBuff = null;
        Destroy(aura);
        Destroy(this.gameObject);
    }

    public virtual void SpawnAura(PlayerScript player)
    {
        aura = Instantiate(bonusData.aura);
        started = true;
    }

    public virtual void UpdateAfterStarted()
    {
        aura.transform.position = knight.transform.position + bonusData.auraOffSet;
    }
}
