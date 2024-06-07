using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
namespace Tony
{
    public class CapaaController : PetControllerBase
    {
        [SerializeField] private bool isSkill1;
        [SerializeField] private bool isSkill2;
        [SerializeField] private bool isSkill3;
        private int skillDuration;
        private float randomRateSkill1;
        private float additionalStatSkill;


        private skillState currentState;
        private enum skillState
        {
            Skill1, Skill2, Skill3
        }
        public override void Start()
        {
            base.Start();
            projectileSpawn = new SpawnCapaaProjectile(this.projectile, this.projectilePool, this.projectilePos);

        }
        public override void Skill1()
        {

        }
        public override async void Skill2()
        {
            SwitchSkillState(skillState.Skill2);
            CharacterStats.instance.Shield = CharacterStats.instance.Atk.GetAtk() + additionalStatSkill * pet.Atk.GetAtk();
            await Task.Delay(skillDuration);
            CharacterStats.instance.Shield = 0;
        }
        public override void Skill3()
        {

        }
        public override bool IsSkill1()
        {
            return isSkill1;
        }
        public override bool IsSkill2()
        {
            return isSkill2;
        }
        public override bool IsSkill3()
        {
            return isSkill3;
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
                        switch (pet.petData.LevelSkill1)
                        {
                            case 0:
                                {
                                    skillDuration = 0;
                                    randomRateSkill1 = 0;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 1:
                                {
                                    skillDuration = 0;
                                    randomRateSkill1 = 20 / 100;
                                    additionalStatSkill = 50 / 100;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 0;
                                    randomRateSkill1 = 40 / 100;
                                    additionalStatSkill = 50 / 100;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 0;
                                    randomRateSkill1 = 60 / 100;
                                    additionalStatSkill = 50 / 100;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 0;
                                    randomRateSkill1 = 100 / 100;
                                    additionalStatSkill = 100 / 100;
                                    break;
                                }
                        }
                        break;
                    }
                case skillState.Skill2:
                    {
                        switch (pet.petData.LevelSkill2)
                        {
                            case 0:
                                {
                                    skillDuration = 8000;
                                    additionalStatSkill = 0;
                                    break;
                                }
                            case 1:
                                {
                                    skillDuration = 8000;
                                    additionalStatSkill = 10 / 100;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 8000;
                                    additionalStatSkill = 30 / 100;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 8000;
                                    additionalStatSkill = 50 / 100;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 8000;
                                    additionalStatSkill = 70 / 100;
                                    break;
                                }
                        }
                        break;
                    }
                case skillState.Skill3:
                    {
                        switch (pet.petData.LevelSkill3)
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
                                    additionalStatSkill = 4000;
                                    break;
                                }
                            case 2:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 5000;
                                    break;
                                }
                            case 3:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 7000;
                                    break;
                                }
                            case 4:
                                {
                                    skillDuration = 0;
                                    additionalStatSkill = 9000;
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
