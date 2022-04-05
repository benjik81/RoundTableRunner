using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Bonus
{
    public ShieldData shieldData;
    public override void Effect(PlayerScript player)
    {
        player.GiveInvincibility(shieldData.duration);
        Destroy(this.gameObject);
    }
}
