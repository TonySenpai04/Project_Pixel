using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
namespace Tony
{
    public class SpawnProjectile : IPetProjectileSpawn
    {
        private Transform projectile;
        private Transform poolProjectile;
        private Transform projectilePos;
        private float force;
        public SpawnProjectile(Transform projectile, Transform poolProjectile, Transform projectilePos,
            float force)
        {
            this.projectile = projectile;
            this.poolProjectile = poolProjectile;
            this.projectilePos = projectilePos;
            this.force = force;
        }

        public void Spawn(Pet pet,int count)
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

                var projRb = projectileIns.GetComponent<Rigidbody2D>();
                projRb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }
    }
}
