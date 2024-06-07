using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Tony
{
    public class MadScientistController : EnemyControllerBase
    {
        private int skillDuration;
        private float additionalStatSkill;

        private skillState currentState;
        private enum skillState
        {
            Skill1, Skill2, Skill3
        }
        public override void Start()
        {
            base.Start();
            projectileSpawn = new EnemySpawnProjectile(this.projectile, this.projectilePool, this.projectilePos);
        }
        public override void Skill1()
        {
            SwitchSkillState(skillState.Skill1);
            enemy.HitPoint.SetHealth(enemy.HitPoint.GetHealth() + enemy.HitPoint.GetHealth() * additionalStatSkill);
        }
        public override async void Skill2()
        {
            SwitchSkillState(skillState.Skill2);
            ((IATKS)enemy.Atk).SetATKS(((IATKS)enemy.Atk).GetATKS() * additionalStatSkill);
            await Task.Delay(skillDuration);
            ((IATKS)enemy.Atk).SetATKS(((IATKS)enemy.Atk).GetATKS() / additionalStatSkill);
        }
        public override void Skill3()
        {

        }
        private void SwitchSkillState(skillState newState)
        {
            //kett thuc trng thai cu
            switch (currentState)
            {
                case skillState.Skill1: { break; }
                case skillState.Skill2: { break; }
                case skillState.Skill3: { break; }
            }

            //bat dau trang thai moi
            switch (newState)
            {
                case skillState.Skill1:
                    {
                        switch (enemy.enemyData.LevelSkill1)
                        {
                            case 0:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 1:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 5 / 100;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 10 / 100;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 15 / 100;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 20 / 100;
                                    break;
                                }
                        }
                        break;
                    }
                case skillState.Skill2:
                    {
                        switch (enemy.enemyData.LevelSkill2)
                        {
                            case 0:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 1:
                                {
                                    skillDuration = 3000;
                                    additionalStatSkill = 2;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 4000;
                                    additionalStatSkill = 2;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 5000;
                                    additionalStatSkill = 2;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 6000;
                                    additionalStatSkill = 2;
                                    break;
                                }
                        }
                        break;
                    }
                case skillState.Skill3:
                    {
                        switch (enemy.enemyData.LevelSkill3)
                        {
                            case 0:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 1:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                        }
                        break;
                    }
            }

            currentState = newState;

        }
    }
}

