using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tony;
using UnityEngine;
using static Tony.SkillData;
namespace tony
{
    public class CapaaSkillController : SkillControllerBase
    {
        [SerializeField] protected Pet pet;
        public override async void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown)
            {
                Ability1Input();
                isSkill1 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                isSkill1 = false;
            }


        }
        public override async void Skill2(SkillAttributes skillAttributes)
        {
            if (!isAbility2Cooldown)
            {
                Ability2Input();
                IHitPoint hitPoint = CharacterStats.instance.HitPoint;
                ((IDamReduction)hitPoint).SetDamReduction((skillAttributes.additionalStatSkill * pet.Atk.GetAtk() )/100+
                    CharacterStats.instance.Atk.GetAtk());
                isSkill2 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                ((IDamReduction)hitPoint).SetDamReduction(0);
                isSkill2 = false;
            }

        }

        public override async void Skill3(SkillAttributes skillAttributes)
        {
            if (!isAbility3Cooldown)
            {
                Ability3Input();
                IHitPoint hitPoint = CharacterStats.instance.HitPoint;
                ((IDamReduction)hitPoint).SetDamReduction(skillAttributes.additionalStatSkill * pet.Atk.GetAtk()/100);
                isSkill3 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                ((IDamReduction)hitPoint).SetDamReduction(0);
                isSkill3 = false;
            }


        }
    }
}
