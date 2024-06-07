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
        [SerializeField] private bool isSkill1;
        [SerializeField] private bool isSkill2;
        [SerializeField] private bool isSkill3;

        public override void Start()
        {
            base.Start();
            projectileSpawn = new SpawnCapaaProjectile(this.projectile, this.projectilePool, this.projectilePos);

        }
        public override async void Skill1()
        {
            isSkill1=true;
            await Task.Delay((int)skillSets[0].currentSkillAttributes.skillDuration * 1000);
            isSkill1 = false;

        }
        public override async void Skill2()
        {
            await Task.Delay((int)skillSets[0].currentSkillAttributes.skillDuration * 1000);
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
