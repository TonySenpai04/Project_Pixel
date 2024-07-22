using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAnimationControllerBase : MonoBehaviour
{
    [SerializeField] public Animator animator;
    private string currentAnimationState;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void ChangeAnimationState(string newAnimationState)
    {
        //if (currentAnimationState == newAnimationState) return;


        animator.Play(newAnimationState);
        currentAnimationState = newAnimationState;
    }
    public virtual void RunEnemyAnim()
    {
        ChangeAnimationState("EnemyRun");
    }
    public virtual void FlyEnemyAnim()
    {
        ChangeAnimationState("EnemyFly");
    }
    public virtual void IdleEnemyAnim()
    {
        ChangeAnimationState("EnemyIdle");
    }
    public virtual void TakeDamageEnemyAnim()
    {
        ChangeAnimationState("EnemyTakeDamages");
    }
    public virtual void HitEnemytAnim()
    {
        ChangeAnimationState("EnemyHit");
    }
    public virtual void Skill1EnemyAnim()
    {
        ChangeAnimationState("EnemySkill1");
    }
    public virtual void Skill2EnemyAnim()
    {
        ChangeAnimationState("EnemySkill2");
    }
    public virtual void Skill3EnemyAnim()
    {
        ChangeAnimationState("EnemySkill3");
    }
}
