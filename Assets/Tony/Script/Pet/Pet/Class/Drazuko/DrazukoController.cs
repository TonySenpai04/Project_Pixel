using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tony;
using UnityEngine;

public class DrazukoController : PetControllerBase
{
    [SerializeField] private List<SkillData.SkillSet> skillSets;

    public override void Start()
    {
        base.Start();
        projectileSpawn = new SpawnDrazukoProjectile(this.projectile, this.projectilePool, this.projectilePos);
    }

    [System.Obsolete]
    public override void Update()
    {
        base.Update();
  
    }
    public override  void Skill1()
    {
        SetSkillAttribute();
        skillController.Skill1(this.skillSets[0].currentSkillAttributes);

    }

    public override  void Skill2()
    {
        SetSkillAttribute();
        skillController.Skill1(this.skillSets[1].currentSkillAttributes);

    }

    public override  void Skill3()
    {
        SetSkillAttribute();
        skillController.Skill1(this.skillSets[2].currentSkillAttributes);
    }
    public void SetSkillAttribute()
    {
        int skill1 = pet.GetCurrentData().LevelSkill1;
        int skill2 = pet.GetCurrentData().LevelSkill2;
        int skill3 = pet.GetCurrentData().LevelSkill3;

        skillSets[0].SetCurrentSkillAttributes(skillSets[0].attributes[skill1]);
        skillSets[1].SetCurrentSkillAttributes(skillSets[1].attributes[skill2]);
        skillSets[2].SetCurrentSkillAttributes(skillSets[2].attributes[skill3]);
        skillController.SetAbilityCooldown(skillSets[0].attributes[skill1].coolDown,
        skillSets[1].attributes[skill2].coolDown, skillSets[2].attributes[skill3].coolDown);




    }

}

