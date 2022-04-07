using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBehavior : AttackBehavior
{
    public Animator anim;

    public AudioSource audioSource;
    public AudioClip bonkSfx;
    public AudioClip walkSfx;

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        anim.SetTrigger("Bonk");
        BonkingSound();
    }

    public void BonkingSound()
    {
        audioSource.clip = bonkSfx;
        audioSource.volume = GameManager.instance.gameData.volume;
        audioSource.Play();
    }

    public void WalkSound()
    {
        audioSource.clip = walkSfx;
        audioSource.volume = GameManager.instance.gameData.volume;
        audioSource.Play();
    }
}
