using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tony.Pet;
using UnityEngine;
using static Tony.Skill.SkillData;
namespace Tony.Skill
{
    public class CapaaSkillController : SkillControllerBase
    {
        [SerializeField] protected PetBase pet;
        public override async void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown && pet.GetCurrentData().LevelSkill1 > 0 )
            {
                Ability1Input();
                isSkill1 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                isSkill1 = false;
            }


        }
        public override async void Skill2(SkillAttributes skillAttributes)
        {
            if (!isAbility2Cooldown && pet.GetCurrentData().LevelSkill2 > 0)
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
            if (!isAbility3Cooldown && pet.GetCurrentData().LevelSkill3 > 0)
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
