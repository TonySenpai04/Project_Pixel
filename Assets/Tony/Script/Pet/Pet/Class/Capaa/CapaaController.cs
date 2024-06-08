using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
namespace Tony
{
    public class CapaaController : PetControllerBase
    {

        public List<SkillData.SkillSet> skillSets;

        public override void Start()
        {
            base.Start();
            projectileSpawn = new SpawnCapaaProjectile(this.projectile, this.projectilePool, this.projectilePos);

        }
        public override void Skill1()
        {
            SetSkillAttribute();
            skillController.Skill1(this.skillSets[0].currentSkillAttributes);

        }

        public override void Skill2()
        {
            SetSkillAttribute();
            skillController.Skill1(this.skillSets[1].currentSkillAttributes);

        }

        public override void Skill3()
        {
            SetSkillAttribute();
            skillController.Skill1(this.skillSets[2].currentSkillAttributes);
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
}
