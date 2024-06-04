using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class CapaaController : PetControllerBase
    {
        [SerializeField] private bool isSkill1;
        [SerializeField] private bool isSkill2;
        [SerializeField] private bool isSkill3;
        public override void Start()
        {
            base.Start();
            projectileSpawn = new SpawnCapaaProjectile(this.projectile, this.projectilePool, this.projectilePos);

        }
        public override void Skill1()
        {
            
        }
        public override void Skill2()
        {
          
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
    }
}
