using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Tony.SkillData;

namespace Tony
{
    public class DrazukoSkillController : SkillControllerBase
    {
        [SerializeField] protected Pet pet;
        public override async void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown)
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
            if (!isAbility2Cooldown)
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
            if (!isAbility3Cooldown)
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