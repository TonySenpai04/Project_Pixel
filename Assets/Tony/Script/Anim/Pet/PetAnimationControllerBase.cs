using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public abstract class PetAnimationControllerBase : MonoBehaviour
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
    public virtual void RunPetAnim()
    {
        ChangeAnimationState("PetRun");
        
    }
    public virtual void IdlePetAnim()
    {
        ChangeAnimationState("PetIdle");
    }
    public virtual void HitPetAnim()
    {
        ChangeAnimationState("PetHit");
    }
    public virtual void Skill1PetAnim()
    {
        ChangeAnimationState("PetSkill1");
    }
    public virtual void Skill2PetAnim()
    {
        ChangeAnimationState("PetSkill2");
    }
    public virtual void Skill3PetAnim()
    {
        ChangeAnimationState("PetSkill3");
    }

}