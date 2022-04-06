using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Bonus
{
    private ShieldData shieldData;

    private void Start()
    {
        shieldData = bonusData as ShieldData;
    }
    public override void Effect(PlayerScript player)
    {
        base.Effect(player);
        player.GiveInvincibility(shieldData.duration);
        //Destroy(this.gameObject);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (knight.isInvincible)
        {
            yield return null;
        }
        Debug.Log("finished");
        ClearBonus();
    }


}
