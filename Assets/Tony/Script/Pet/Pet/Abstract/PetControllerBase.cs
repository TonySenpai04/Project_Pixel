using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
namespace Tony
{
    public abstract class PetControllerBase : MonoBehaviour
    {
        [SerializeField] protected Pet pet;
        [SerializeField] protected Transform player;
        [SerializeField] protected Transform projectile;
        [SerializeField] protected Transform projectilePos;
        [SerializeField] protected Transform projectilePool;
        [SerializeField] protected IPetProjectileSpawn projectileSpawn;
        [SerializeField] protected float fireRate;
        [SerializeField] protected float nextFireTime;
        [SerializeField] protected int projectileSpawnCount = 1;
        [SerializeField] protected Enemy firstEnemy;
        [SerializeField] protected SkillControllerBase skillController;

        public Transform Player { get => player;  }
        public SkillControllerBase SkillController { get => skillController; }
        public Pet Pet { get => pet; }
        public int ProjectileSpawnCount { get => projectileSpawnCount; set => projectileSpawnCount = value; }

        public virtual void Start()
        {
            pet=GetComponent<Pet>();
            fireRate = ((IATKS)pet.Atk).GetATKS();
            nextFireTime = fireRate;
        }

        [System.Obsolete]
        public virtual void Update()
        {
            fireRate = ((IATKS)pet.Atk).GetATKS();
            HandleEnemyFound();
        }

        [System.Obsolete]
        public virtual void HandleEnemyFound()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.transform.position, ((IATKR)Pet.Atk).GetATKR());

            if (collider2Ds.Length > 0)
            {
                bool enemyFound = false;
             
                foreach (var item in collider2Ds)
                {
                    var enemy = item.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        firstEnemy = enemy;
                        enemyFound = true;
                        break;
                    }
                }

                if (enemyFound)
                {
                    if (firstEnemy != null)
                    {
                        Attack();
                    }
                }
                else
                {
                    firstEnemy = null;
                }
            }
            else
            {
                firstEnemy = null;
            }
        }

        public virtual void Attack()
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {
               
                projectileSpawn.Spawn(this.Pet, projectileSpawnCount,firstEnemy.transform);
                nextFireTime = 0f;

            }
        }
        public virtual void Skill1()
        {

        }
        public virtual void Skill2()
        {

        }
        public virtual void Skill3()
        {

        }
    }
}
