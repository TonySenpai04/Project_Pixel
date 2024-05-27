using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class EnemySpawnProjectile : IEnemyProjectileSpawn
    {
        private Transform projectile;
        private Transform poolProjectile;
        private Transform projectilePos;
        public EnemySpawnProjectile(Transform projectile, Transform poolProjectile, Transform projectilePos)
        {
            this.projectile = projectile;
            this.poolProjectile = poolProjectile;
            this.projectilePos = projectilePos;
        }

        public void Spawn(Enemy enemy, int count, Transform target)
        {
            if (this.projectile == null)
                return;
            for (int i = 0; i < count; i++)
            {
                Transform projectileIns = PoolObjectManager.Instance.GetObjectFromPool(projectile, projectilePos, null);
                projectileIns.transform.SetParent(poolProjectile);

                float cr = Random.Range(0f, 101f);
                if (((ICR)enemy.Atk).GetCR() >= cr)
                {
                    projectileIns.GetComponent<GenericProjectile>().SetDam(enemy.Atk.GetAtk() * ((ICD)enemy.Atk).GetCD());
                }
                else
                {
                    projectileIns.GetComponent<GenericProjectile>().SetDam(enemy.Atk.GetAtk());
                }
                projectileIns.GetComponent<GenericProjectile>().SetTarget(target);
                //var projRb = projectileIns.GetComponent<Rigidbody2D>();
                //projRb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }
    }
}
