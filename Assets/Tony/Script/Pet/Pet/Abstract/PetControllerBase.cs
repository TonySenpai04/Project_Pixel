using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Tony.Enemy;
using Tony.Projectile;
using Tony.Skill;

namespace Tony.Pet
{
    public abstract class PetControllerBase : MonoBehaviour
    {
        [SerializeField] protected PetBase pet;
        [SerializeField] protected Transform player;
        [SerializeField] protected Transform projectile;
        [SerializeField] protected Transform projectilePos;
        [SerializeField] protected Transform projectilePool;
        [SerializeField] protected IPetProjectileSpawn projectileSpawn;
        [SerializeField] protected float fireRate;
        [SerializeField] protected float nextFireTime;
        [SerializeField] protected int projectileSpawnCount = 1;
        [SerializeField] protected EnemyBase firstEnemy;
        [SerializeField] protected SkillControllerBase skillController;

        public Transform Player { get => player;  }
        public SkillControllerBase SkillController { get => skillController; }
        public PetBase Pet { get => pet; }
        public int ProjectileSpawnCount { get => projectileSpawnCount; set => projectileSpawnCount = value; }

        public virtual void Start()
        {
            pet=GetComponent<PetBase>();
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
                    var enemy = item.GetComponent<EnemyBase>();
                    if (enemy != null)
                    {
                        firstEnemy = enemy;
                        enemyFound = true;
                        break;
                    }
                }

                if (enemyFound)
                {
                    if (firstEnemy != null && firstEnemy.HitPoint.GetCurrentHealth()>0
                        && CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
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
               
                projectileSpawn.Spawn(this.pet, projectileSpawnCount,firstEnemy.transform);
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
