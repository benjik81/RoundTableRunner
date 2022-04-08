using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Buffs")]
    public Bonus currentBuff;

    [Header("Settings")]
    public bool isInvincible = false;
    private float invincibleDuration = 10f;
    private float invincibleTimer = 0f;

    private bool isThrowingSwords = false;
    private float throwingSwordDuration = 10f;
    private float throwingSwordDelay = 2f;
    private float throwingSwordTimer = 0f;
    private float throwOneSwordTimer = 0f;

    private Animator anim;
    public bool isDying;

    public AudioClip deathSfx;

    // Start is called before the first frame update
    void Start()
    {
        if(name != "Crown")
        {
            anim = GetComponent<Animator>();
        }
        isDying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDying)
        {
            // Scroll with background
            transform.position = new Vector3(0, transform.position.y, transform.position.z - (5 * Time.deltaTime * GameManager.instance.scrollingMultiplier));
            if(name == "Crown")
            {
                //rotate the crown as it falls
                transform.Rotate(2, 0, 0);
            }
        }

        TimersIncrement();
    }

    public void CollisionObstacle()
    {
        if(!isInvincible)
        {
            if (currentBuff)
            {
                currentBuff.ClearBonus();
            }
            if(name != "Crown"){
                GameManager.instance.knights.Remove(this);
                GameManager.instance.LooseKnight();
                
                anim.SetFloat("Blend", 3f);
            }
            isDying = true;
            AudioManager.instance.PlaySound(deathSfx);
            Destroy(gameObject, 1f);
        }
        else
        {
            if (currentBuff.bonusType == BonusType.Shield)
            {
                InvincibilityLost();
            }
            
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

    public void GetBonus(Bonus bonus)
    {
        if (bonus != GameManager.instance.lastBuff || !GameManager.instance.lastBuff)
        {
            GameManager.instance.lastBuff = bonus;
            if (currentBuff != bonus && currentBuff != null)
            {
                currentBuff.ClearBonus();
                Debug.Log("Clearing bonus");
            }

            bonus.PlaySFX();

            currentBuff = bonus;
            bonus.Effect(this);
        }
        
        
    }

    

    public void GiveInvincibility(float duration)
    {
        invincibleDuration = duration;
        isInvincible = true;
        invincibleTimer = 0f;
    }

    public void InvincibilityLost()
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
