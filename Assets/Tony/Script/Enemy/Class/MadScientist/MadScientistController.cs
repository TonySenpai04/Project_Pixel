using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
namespace Tony
{

    public class MadScientistController : EnemyControllerBase
    {
       
        public List<SkillData.SkillSet> skillSets;    

        [SerializeField] private bool isSkill1;
        [SerializeField] private bool isSkill2;
        [SerializeField] private bool isSkill3;
        public override void Start()
        {
            base.Start();
            projectileSpawn = new EnemySpawnProjectile(this.projectile, this.projectilePool, this.projectilePos);
        }
        public override async void Skill1()
        {
            if (isSkill1)
            {
                SetSkillAttribute();
                enemy.HitPoint.Heal((int)(enemy.HitPoint.GetHealth() * skillSets[0].currentSkillAttributes.additionalStatSkill));
                isSkill1 = false;
                await Task.Delay((int)skillSets[0].currentSkillAttributes.skillDuration * 1000);
                await Task.Delay((int)skillSets[0].currentSkillAttributes.coolDown * 1000);
                isSkill1 = true;
            }
        }
        public override async void Skill2()
        {
            if (isSkill2)
            {
                SetSkillAttribute();
                float atks = ((IATKS)enemy.Atk).GetATKS();
                float atksBuff = atks / 2;
                ((IATKS)enemy.Atk).SetATKS(atksBuff);
                isSkill2 = false;
                await Task.Delay((int)skillSets[1].currentSkillAttributes.skillDuration*1000);
                ((IATKS)enemy.Atk).SetATKS(atks);
          
                await Task.Delay((int)skillSets[1].currentSkillAttributes.coolDown * 1000);
                isSkill2 = true;
            }
        }
        public override void Skill3()
        {

        }
        public void SetSkillAttribute()
        {
            int skill1 = enemy.GetCurrentData().LevelSkill1;
            int skill2 = enemy.GetCurrentData().LevelSkill2;
            int skill3 = enemy.GetCurrentData().LevelSkill3;
            if (skill1 > 0)
            {

                skillSets[0].SetCurrentSkillAttributes(skillSets[0].attributes[skill1-1]);

            }
            if (skill2> 0)
            {
                skillSets[1].SetCurrentSkillAttributes(skillSets[1].attributes[skill2-1]);
            }
            if (skill3 > 0)
            {
                skillSets[2].SetCurrentSkillAttributes(skillSets[2].attributes[skill3 - 1]);
            }

        }
        //private void SwitchSkillState(skillState newState)
        //{
        //    //kett thuc trng thai cu
        //    switch (currentState)
        //    {
        //        case skillState.Skill1: { break; }
        //        case skillState.Skill2: { break; }
        //        case skillState.Skill3: { break; }
        //    }

        //    //bat dau trang thai moi
        //    switch (newState)
        //    {
        //        case skillState.Skill1:
        //            {
        //                switch (enemy.enemyData.LevelSkill1)
        //                {
        //                    case 0:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 1:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 5 / 100;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 10 / 100;
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 15 / 100;
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 20 / 100;
        //                            break;
        //                        }
        //                }
        //                break;
        //            }
        //        case skillState.Skill2:
        //            {
        //                switch (enemy.enemyData.LevelSkill2)
        //                {
        //                    case 0:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 1:
        //                        {
        //                            skillDuration = 3000;
        //                            additionalStatSkill = 2;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            skillDuration = 4000;
        //                            additionalStatSkill = 2;
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            skillDuration = 5000;
        //                            additionalStatSkill = 2;
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            skillDuration = 6000;
        //                            additionalStatSkill = 2;
        //                            break;
        //                        }
        //                }
        //                break;
        //            }
        //        case skillState.Skill3:
        //            {
        //                switch (enemy.enemyData.LevelSkill3)
        //                {
        //                    case 0:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 1:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            skillDuration = 0;
        //                            additionalStatSkill = 0;
        //                            break;
        //                        }
        //                }
        //                break;
        //            }
        //    }

        //    currentState = newState;

        //}

    }

}

