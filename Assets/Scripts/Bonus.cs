using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Obstacle
{
    public BonusType bonusType;
    public virtual void Effect(PlayerScript player)
    {

    }

    public virtual void ClearBonus()
    {
        Destroy(this.gameObject);
    }
}
