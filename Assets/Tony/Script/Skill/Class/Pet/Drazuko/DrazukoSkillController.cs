using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Tony.Pet;
using static Tony.Skill.SkillData;

namespace Tony.Skill
{
    public class DrazukoSkillController : SkillControllerBase
    {
        [SerializeField] protected PetBase pet;
        public override async void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown && pet.GetCurrentData().LevelSkill1 > 0)
            {
                Ability1Input();
                float cr = ((ICR)pet.Atk).GetCR();
                float crBuff = cr + skillAttributes.additionalStatSkill;
                ((ICR)pet.Atk).SetCR(crBuff);
                Debug.Log(((ICR)pet.Atk).GetCR());
                isSkill1 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                ((ICR)pet.Atk).SetCR(cr);
                isSkill1 = false;
                Debug.Log(((ICR)pet.Atk).GetCR());
            }


        }
        public override async void Skill2(SkillAttributes skillAttributes)
        {
            if (!isAbility2Cooldown && pet.GetCurrentData().LevelSkill2 > 0)
            {
                Ability2Input();
                float characterDmg = CharacterStats.instance.Atk.GetAtk();
                float dmgBuff = skillAttributes.additionalStatSkill;
                float dmg = pet.Atk.GetAtk();
                pet.Atk.SetAtk(dmgBuff * characterDmg + dmg);
                isSkill2 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                pet.Atk.SetAtk(dmg);
                isSkill2 = false;
            }

        }

        public override async void Skill3(SkillAttributes skillAttributes)
        {
            if (!isAbility3Cooldown && pet.GetCurrentData().LevelSkill3 > 0)
            {
                Ability3Input();
                GetComponent<PetControllerBase>().ProjectileSpawnCount *= (int)skillAttributes.additionalStatSkill;
                isSkill3 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                GetComponent<PetControllerBase>().ProjectileSpawnCount = 1;
                isSkill3 = false;
            }


        }
    }
}