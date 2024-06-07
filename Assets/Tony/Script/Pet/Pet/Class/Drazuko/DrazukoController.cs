using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tony;
using UnityEngine;

public class DrazukoController : PetControllerBase
{
    public List<SkillData.SkillSet> skillSets;
    [SerializeField] private bool isSkill1;
    [SerializeField] private bool isSkill2;
    [SerializeField] private bool isSkill3;
    public override void Start()
    {
        base.Start();
        projectileSpawn = new SpawnDrazukoProjectile(this.projectile, this.projectilePool, this.projectilePos);
    }

    [System.Obsolete]
    public override void Update()
    {
        base.Update();
        if(Input.GetKey(KeyCode.K))
        {
            Skill1();
        }
    }
    public override async void Skill1()
    {
        if (isSkill1)
        {
            SetSkillAttribute();
            float cr = ((ICR)pet.Atk).GetCR();
            float crBuff = cr + skillSets[0].currentSkillAttributes.additionalStatSkill;
            ((ICR)pet.Atk).SetCR(crBuff);
            Debug.Log(((ICR)pet.Atk).GetCR());
            isSkill1 = false;
            await Task.Delay((int)skillSets[0].currentSkillAttributes.skillDuration * 1000);
            ((ICR)pet.Atk).SetCR(cr);
            Debug.Log(((ICR)pet.Atk).GetCR());
            await Task.Delay((int)skillSets[0].currentSkillAttributes.coolDown * 1000);
            isSkill1 = true;
        }
    }

    public override async void Skill2()
    {
        if (isSkill2)
        {
            SetSkillAttribute();
            float characterDmg = CharacterStats.instance.Atk.GetAtk();
            float dmgBuff= skillSets[2].currentSkillAttributes.additionalStatSkill;
            float dmg = pet.Atk.GetAtk();

            pet.Atk.SetAtk(dmgBuff* characterDmg+ dmg);
            isSkill2 = false;
            await Task.Delay((int)skillSets[1].currentSkillAttributes.skillDuration * 1000);
            pet.Atk.SetAtk(dmg);
            await Task.Delay((int)skillSets[1].currentSkillAttributes.coolDown * 1000);
            isSkill2 = true;
        }
       
    }

    public override async void Skill3()
    {
        if (isSkill3)
        {
            SetSkillAttribute();
            projectileSpawnCount  *= (int)skillSets[2].currentSkillAttributes.additionalStatSkill;
            isSkill3 = false;
            await Task.Delay((int)skillSets[2].currentSkillAttributes.skillDuration * 1000);
            projectileSpawnCount = 1;
            await Task.Delay((int)skillSets[2].currentSkillAttributes.coolDown * 1000);
            isSkill3 = true;
        }
    }
    public void SetSkillAttribute()
    {
        int skill1 = pet.GetCurrentData().LevelSkill1;
        int skill2 = pet.GetCurrentData().LevelSkill2;
        int skill3 = pet.GetCurrentData().LevelSkill3;
        
        if (skill1 > 0)
        {
            skillSets[0].SetCurrentSkillAttributes(skillSets[0].attributes[skill1 - 1]);
        }
        if (skill2 > 0)
        {
            skillSets[1].SetCurrentSkillAttributes(skillSets[1].attributes[skill2 - 1]);
        }
        if (skill3 > 0)
        {
            skillSets[2].SetCurrentSkillAttributes(skillSets[2].attributes[skill3 - 1]);
        }

    }

}

