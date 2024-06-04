using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class MadScientistController : EnemyControllerBase
    {
        public override void Start()
        {
            base.Start();
            projectileSpawn = new EnemySpawnProjectile(this.projectile, this.projectilePool, this.projectilePos);
        }
    }
}

