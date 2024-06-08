using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Tony.SkillData;

namespace Tony
{
    public class MadScientistSkillController : SkillControllerBase
    {
        [SerializeField] private Enemy enemy;
       
        public override  void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown)
            {
                Ability1Input();
                enemy.HitPoint.Heal((int)(enemy.HitPoint.GetHealth() * skillAttributes.additionalStatSkill));
    
            }
        }
        public override async void Skill2(SkillAttributes skillAttributes)
        {
            if (!isAbility2Cooldown)
            {
                Ability2Input();

                float atks = ((IATKS)enemy.Atk).GetATKS();
                float atksBuff = atks / skillAttributes.additionalStatSkill;
                ((IATKS)enemy.Atk).SetATKS(atksBuff);
                isSkill2 = true;
                await Task.Delay((int)skillAttributes.skillDuration * 1000);
                ((IATKS)enemy.Atk).SetATKS(atks);
                isSkill2 = false;
            }
        }
        public override void Skill3(SkillAttributes skillAttributes)
        {
            if (!isAbility3Cooldown)
            {
                Ability3Input();
                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, ((IATKR)enemy.Atk).GetATKR());

                if (collider2Ds.Length > 0)
                {

                    foreach (var item in collider2Ds)
                    {
                        var player = item.GetComponent<CharacterStats>();
                        if (player != null)
                        {
                            player.HitPoint.TakeDamage((int)(enemy.HitPoint.GetHealth() * skillAttributes.additionalStatSkill));
                            break;
                        }
                    }
                }
            }
        }
    }
}