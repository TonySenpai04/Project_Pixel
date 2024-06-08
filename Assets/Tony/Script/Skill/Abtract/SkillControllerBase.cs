using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Tony.SkillData;
namespace Tony {
    public abstract class SkillControllerBase : MonoBehaviour
    {
        protected float ability1Cooldown = 5;
        protected float ability2Cooldown = 7;
        protected float ability3Cooldown = 10;

        [SerializeField] protected bool isAbility1Cooldown = false;
        [SerializeField] protected bool isAbility2Cooldown = false;
        [SerializeField] protected bool isAbility3Cooldown = false;

        [SerializeField] protected float currentAbility1Cooldown;
        [SerializeField] protected float currentAbility2Cooldown;
        [SerializeField] protected float currentAbility3Cooldown;

        [SerializeField] protected bool isSkill1;
        [SerializeField] protected bool isSkill2;
        [SerializeField] protected bool isSkill3;

        [SerializeField] protected ISkillAbility skillAbility;



        void Start()
        {
            skillAbility = new SkillAbility();
        }
        public virtual bool IsSkill1()
        {
            return isSkill1;
        }
        public virtual bool IsSkill2()
        {
            return isSkill2;
        }
        public virtual bool IsSkill3()
        {
            return isSkill3;
        }
        public virtual void Update()
        {

            AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, null, null);
            AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, null, null);
            AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, null, null);
        }
        public virtual void Skill1(SkillAttributes skillAttributes)
        {

        }
        public virtual void Skill2(SkillAttributes skillAttributes)
        {

        }

        public virtual void Skill3(SkillAttributes skillAttributes)
        {


        }
        public virtual void SetAbilityCooldown(float cooldown1, float cooldown2, float cooldown3)
        {
            ability1Cooldown = cooldown1;
            ability2Cooldown = cooldown2;
            ability3Cooldown = cooldown3;
        }

        public virtual void Ability1Input()
        {
            if (!isAbility1Cooldown)
            {
                isAbility1Cooldown = true;
                currentAbility1Cooldown = ability1Cooldown;
            }
        }

        public virtual void Ability2Input()
        {
            if (!isAbility2Cooldown)
            {
                isAbility2Cooldown = true;
                currentAbility2Cooldown = ability2Cooldown;
            }
        }

        public virtual void Ability3Input()
        {
            if (!isAbility3Cooldown)
            {
                isAbility3Cooldown = true;
                currentAbility3Cooldown = ability3Cooldown;
            }
        }

        public virtual void AbilityCooldown( ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
        {
            skillAbility.AbilityCooldown(ref currentCooldown, maxCooldown,ref isCooldown, skillImage, skillText);
        }

    }
}
