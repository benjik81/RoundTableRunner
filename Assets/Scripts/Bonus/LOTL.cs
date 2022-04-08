using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOTL : Bonus
{
    private LOTLData lOTLData;
    float tempValue;
    PlayerScript[] players;
    GameObject[] auras;

    private void Start()
    {
        lOTLData = bonusData as LOTLData;
    }
    public override void Effect(PlayerScript player)
    {
        Debug.Log("oneEffect");
        knight = player;
        foreach (Transform child in transform) // Removes all collider and graphics
        {
            GameObject.Destroy(child.gameObject);
        }

        tempValue = GameManager.instance.scrollingMultiplier;
        players = GameManager.instance.knights.ToArray();


        for (int i = 0; i < players.Length; i++)
        {
            players[i].currentBuff = this;
            players[i].GiveInvincibility(lOTLData.duration);
            players[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        if (auras == null) // if the buff has already been assigned
        {
            auras = new GameObject[players.Length];

            for (int i = 0; i < auras.Length; i++)
            {
                SpawnAura(players[i]);
                auras[i] = aura;
            }
        }

        GameManager.instance.scrollingMultiplier = lOTLData.accelerationSpeed;



        StartCoroutine(Countdown());
    }

    public override void ClearBonus()
    {
        foreach (var item in auras)
        {
            Destroy(item);
        }
        foreach (var item in players)
        {
            item.InvincibilityLost();
            item.GetComponent<Rigidbody>().isKinematic = false;

        }
        GameManager.instance.scrollingMultiplier = tempValue;

        Destroy(this.gameObject);
    }

    public override void UpdateAfterStarted()
    {

        for (int i = 0; i < players.Length; i++)
        {
            auras[i].transform.position = players[i].transform.position + bonusData.auraOffSet;
        }
    }

    private IEnumerator Countdown()
    {
        while (GameManager.instance.knights[0].isInvincible)
        {
            yield return null;
        }
        Debug.Log("finished");
        ClearBonus();
    }
}
