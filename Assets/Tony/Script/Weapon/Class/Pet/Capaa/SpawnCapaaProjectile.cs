using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class SpawnCapaaProjectile : IPetProjectileSpawn
    {
        private Transform projectile;
        private Transform poolProjectile;
        private Transform projectilePos;
        public SpawnCapaaProjectile(Transform projectile, Transform poolProjectile, Transform projectilePos)
        {
            this.projectile = projectile;
            this.poolProjectile = poolProjectile;
            this.projectilePos = projectilePos;
        }

        public void Spawn(Pet pet, int count, Transform target)
        {
            if (this.projectile == null)
                return;
            for (int i = 0; i < count; i++)
            {
                Transform projectileIns = PoolObjectManager.Instance.GetObjectFromPool(projectile, projectilePos, null);
                projectileIns.transform.SetParent(poolProjectile);
                float cr = Random.Range(0f, 101f);
                if (((ICR)pet.Atk).GetCR() >= cr)
                {
                    projectileIns.GetComponent<GenericProjectile>().SetDam(pet.Atk.GetAtk() * ((ICD)pet.Atk).GetCD());

                }
                else
                {
                    projectileIns.GetComponent<GenericProjectile>().SetDam(pet.Atk.GetAtk());
                }
                projectileIns.GetComponent<CapaaProjectile>().Initialize(pet.GetComponent<PetControllerBase>());
                projectileIns.GetComponent<GenericProjectile>().SetTarget(target);
            }
        }
    }
}
