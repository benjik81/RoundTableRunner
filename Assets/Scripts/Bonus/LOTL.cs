using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOTL : Bonus
{
    public LOTLData lOTLData;
    float tempValue;

    public override void Effect()
    {
        tempValue = GameManager.instance.scrollingMultiplier;

        foreach (var item in GameManager.instance.knights)
        {
            item.GiveInvincibility(lOTLData.duration);
        }

        GameManager.instance.scrollingMultiplier = lOTLData.accelerationSpeed;

        StartCoroutine(Countdown());
    }

    
    private IEnumerator Countdown()
    {
        while (GameManager.instance.knights[0].isInvincible)
        {
            yield return null;
        }

        GameManager.instance.scrollingMultiplier = tempValue;
        Destroy(this.gameObject);
    }
}
