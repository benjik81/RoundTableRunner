using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Settings")]
    private bool isInvincible = false;
    public float invincibleDuration = 10f;
    private float invincibleTimer = 0f;

    private bool isThrowingSwords = false;
    public float throwingSwordDuration = 10f;
    public float throwingSwordDelay = 2f;
    private float throwingSwordTimer = 0f;
    private float throwOneSwordTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimersIncrement();
    }

    public void CollisionObstacle()
    {
        if(!isInvincible)
        {
            Destroy(gameObject);
        }
        else
        {
            InvincibilityLost();
        }
    }

    public void ShootFireball()
    {
        //To do
        //Instantiate Fireball Prefab or something
    }

    public void ThrowSword()
    {
        //To do
        //Instantiate Sword Prefab or something
    }

    public void GetBonus(GameObject bonus)
    {
        //To do
    }

    private void InvincibilityLost()
    {
        isInvincible = false;
        invincibleTimer = 0f;
    }

    private void StopThrowingSwords()
    {
        isThrowingSwords = false;
        throwingSwordTimer = 0f;
        throwOneSwordTimer = 0f;
    }

    private void TimersIncrement()
    {
        // Timer for Shield Bonus
        if(isInvincible)
        {
            invincibleTimer += Time.deltaTime;
            if(invincibleTimer >= invincibleDuration)
            {
                InvincibilityLost();
            }
        }


        // Timer for ThowingSwords
        if(isThrowingSwords)
        {
            throwingSwordTimer += Time.deltaTime;
            throwOneSwordTimer += Time.deltaTime;

            if(throwingSwordTimer >= throwingSwordDuration)
            {
                StopThrowingSwords();
            }

            if(throwOneSwordTimer >= throwingSwordDelay)
            {
                throwOneSwordTimer = 0f;
                ThrowSword();
            }
        }

    }
}
