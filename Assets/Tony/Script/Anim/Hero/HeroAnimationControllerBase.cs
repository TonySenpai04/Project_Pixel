using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationControllerBase : MonoBehaviour
{
    [SerializeField] public Animator animator;
    private string currentAnimationState;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void ChangeAnimationState(string newAnimationState)
    {
        if (currentAnimationState == newAnimationState) return;

        animator.Play(newAnimationState);
        currentAnimationState = newAnimationState;
    }
    public virtual void RunHeroAnim()
    {
        ChangeAnimationState("HeroRun");
    }
    public virtual void IdleHeroAnim()
    {
        ChangeAnimationState("HeroIdle");
    }
    public virtual void JumpHeroAnim()
    {
        ChangeAnimationState("HeroJump");
    }
    public virtual void DieHeroAnim()
    {
        ChangeAnimationState("HeroDie");
    }
    public virtual void TakeDamage()
    {
        ChangeAnimationState("HeroTakeDamage");
    }
}
