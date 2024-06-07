using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tony;
using UnityEngine;

public class DrazukoController : PetControllerBase
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
        projectileSpawn = new SpawnDrazukoProjectile(this.projectile, this.projectilePool, this.projectilePos);
    }
    public override async void Skill1()
    {
        SwitchSkillState(skillState.Skill1);
        ((ICR)pet.Atk).SetCR(((ICR)pet.Atk).GetCR() + ((ICR)pet.Atk).GetCR() * additionalStatSkill);
        await Task.Delay(skillDuration);
        ((ICR)pet.Atk).SetCR(((ICR)pet.Atk).GetCR() - ((ICR)pet.Atk).GetCR() * additionalStatSkill);
    }

    public override async void Skill2()
    {
        SwitchSkillState(skillState.Skill2);
        pet.Atk.SetAtk(pet.Atk.GetAtk() + CharacterStats.instance.Atk.GetAtk() * additionalStatSkill);
        await Task.Delay(skillDuration);
        pet.Atk.SetAtk(pet.Atk.GetAtk() - CharacterStats.instance.Atk.GetAtk() * additionalStatSkill);
    }

    public override async void Skill3()
    {
        SwitchSkillState(skillState.Skill3);
        projectileSpawnCount = projectileSpawnCount * (int)additionalStatSkill;
        await Task.Delay(skillDuration);
        projectileSpawnCount = projectileSpawnCount / (int)additionalStatSkill;
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
                                additionalStatSkill = 0;
                                break;
                            }
                        case 1:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 10 / 100;
                                break;
                            }
                        case 2:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 20 / 100;
                                break;
                            }
                        case 3:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 30 / 100;
                                break;
                            }
                        case 4:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 40 / 100;
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
                                skillDuration = 0;
                                additionalStatSkill = 0;
                                break;
                            }
                        case 1:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 150 / 100;
                                break;
                            }
                        case 2:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 200 / 100;
                                break;
                            }
                        case 3:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 250 / 100;
                                break;
                            }
                        case 4:
                            {
                                skillDuration = 8;
                                additionalStatSkill = 300 / 100;
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
                                skillDuration = 4000;
                                additionalStatSkill = 2;
                                break;
                            }
                        case 2:
                            {
                                skillDuration = 5000;
                                additionalStatSkill = 2;
                                break;
                            }
                        case 3:
                            {
                                skillDuration = 7000;
                                additionalStatSkill = 2;
                                break;
                            }
                        case 4:
                            {
                                skillDuration = 9000;
                                additionalStatSkill = 2;
                                break;
                            }
                    }
                    break;
                }
        }

        currentState = newState;

    }
}

