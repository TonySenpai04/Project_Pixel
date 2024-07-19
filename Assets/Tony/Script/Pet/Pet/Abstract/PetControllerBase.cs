using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Tony.Enemy;
using Tony.Projectile;
using Tony.Skill;
using System.Linq;

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
        //[SerializeField] protected float fireRate;
        //[SerializeField] protected float nextFireTime;
        [SerializeField] protected int projectileSpawnCount = 1;
        [SerializeField] protected EnemyBase firstEnemy;
        [SerializeField] protected SkillControllerBase skillController;
        [SerializeField] protected PetMovementController petMoveController;
        [SerializeField] protected PetAnimationControllerBase petAnimationController;

        public Transform Player { get => player; }
        public SkillControllerBase SkillController { get => skillController; }
        public PetBase Pet { get => pet; }


        public int ProjectileSpawnCount { get => projectileSpawnCount; set => projectileSpawnCount = value; }

        public virtual void Start()
        {
            petAnimationController = GetComponent<PetAnimationControllerBase>();
            pet = GetComponent<PetBase>();
            //fireRate = ((IATKS)pet.Atk).GetATKS();
            //nextFireTime = fireRate;
        }

        [System.Obsolete]
        public virtual void Update()
        {
            //  fireRate = ((IATKS)pet.Atk).GetATKS();
            Move();
            HandleEnemyFound();

        }

        [System.Obsolete]
        public virtual void HandleEnemyFound()
        {
            Collider2D[] combinedColliders = GetAllCollidersInRange();

            if (combinedColliders.Length > 0)
            {
                firstEnemy = FindFirstEnemy(combinedColliders);

                if (firstEnemy != null && firstEnemy.HitPoint.GetCurrentHealth() > 0
                    && CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
                {
                    // Attack();
                    petAnimationController.HitPetAnim();
                    petMoveController.LookAtEnemy(firstEnemy.transform);
                }
                else
                {
                    firstEnemy = null;
                    petMoveController.SyncPetRotationWithPlayer();
                }
            }
            else
            {
                firstEnemy = null;
                petMoveController.SyncPetRotationWithPlayer();
            }
        }
        public virtual void Move()
        {
            petMoveController.PetMove();


        }
        public virtual Collider2D[] GetAllCollidersInRange()
        {
            Collider2D[] collider2Dsplayer = Physics2D.OverlapCircleAll(player.transform.position, ((IATKR)Pet.Atk).GetATKR());
            Collider2D[] collider2Dspet = Physics2D.OverlapCircleAll(transform.position, ((IATKR)Pet.Atk).GetATKR());

            // Combine both collider arrays
            return collider2Dsplayer.Concat(collider2Dspet).ToArray();
        }

        public virtual EnemyBase FindFirstEnemy(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                var enemy = item.GetComponent<EnemyBase>();
                if (enemy != null)
                {
                    return enemy;
                }
            }
            return null;
        }

        public virtual void Attack()
        {
            if (firstEnemy != null)
            {
                projectileSpawn.Spawn(this.pet, projectileSpawnCount, firstEnemy.transform);
            }

            //nextFireTime += Time.deltaTime;
            //if (nextFireTime >= fireRate)
            //{
            //    petAnimationController.HitPetAnim();
            //    projectileSpawn.Spawn(this.pet, projectileSpawnCount, firstEnemy.transform);
            //    nextFireTime = 0f;

            //}
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
