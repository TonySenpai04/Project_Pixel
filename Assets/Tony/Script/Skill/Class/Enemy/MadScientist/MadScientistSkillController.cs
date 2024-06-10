using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Tony.Enemy;
using static Tony.Skill.SkillData;

namespace Tony.Skill
{
    public class MadScientistSkillController : SkillControllerBase
    {
        [SerializeField] private EnemyBase enemy;
       
        public override  void Skill1(SkillAttributes skillAttributes)
        {
            if (!isAbility1Cooldown && enemy.GetCurrentData().LevelSkill1>0)
            {
                Ability1Input();
                enemy.HitPoint.Heal((int)(enemy.HitPoint.GetHealth() * skillAttributes.additionalStatSkill));
    
            }
        }
        public override async void Skill2(SkillAttributes skillAttributes)
        {
            if (!isAbility2Cooldown && enemy.GetCurrentData().LevelSkill2 > 0)
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
            if (!isAbility3Cooldown && enemy.GetCurrentData().LevelSkill3 > 0)
            {
                Ability3Input();
                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.enemy.transform.position, ((IATKR)enemy.Atk).GetATKR());

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