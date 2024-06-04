using System.Collections;
using System.Collections.Generic;
using Tony;
using UnityEngine;

public class DrazukoController : PetControllerBase
{
    public override void Start()
    {
        base.Start();
        projectileSpawn = new SpawnDrazukoProjectile(this.projectile, this.projectilePool, this.projectilePos);
    }
}

