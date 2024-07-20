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
        [SerializeField] protected int projectileSpawnCount = 1;
        [SerializeField] protected EnemyBase firstEnemy;
        [SerializeField] protected SkillControllerBase skillController;
        [SerializeField] protected PetMovementController petMoveController;
        [SerializeField] protected PetAnimationControllerBase petAnimationController;
        protected bool isRun;
        protected bool isAtk;
        public Transform Player { get => player; }
        public SkillControllerBase SkillController { get => skillController; }
        public PetBase Pet { get => pet; }
        public int ProjectileSpawnCount { get => projectileSpawnCount; set => projectileSpawnCount = value; }

        public virtual void Start()
        {
            petAnimationController = GetComponent<PetAnimationControllerBase>();
            pet = GetComponent<PetBase>();
        }

        [System.Obsolete]
        public virtual void Update()
        {
            Move();
            HandleEnemyFound();
            HandleAnimation();
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
                    petAnimationController.HitPetAnim();
                    petMoveController.LookAtEnemy(firstEnemy.transform);
                    isAtk = true;
                    isRun = false;
                }
                else
                {
                    firstEnemy = null;
                    isRun=true;
                    isAtk=false;
                    petMoveController.SyncPetRotationWithPlayer();
                }
            }
            else
            {
                firstEnemy = null;
                isRun = true;
                isAtk = false;
                petMoveController.SyncPetRotationWithPlayer();
            }
        }
        public virtual void Move()
        {
            petMoveController.PetMove();
        }
        protected virtual void HandleAnimation()
        {
            if (petMoveController.IsStandingStill() && !isAtk)
            {
                petAnimationController.IdlePetAnim();
                isRun = false;
            }
            if (isRun)
            {
                petAnimationController.RunPetAnim();
            }
           
        }
        public virtual Collider2D[] GetAllCollidersInRange()
        {
            Collider2D[] collider2Dsplayer = Physics2D.OverlapCircleAll(player.transform.position, ((IATKR)Pet.Atk).GetATKR());
            Collider2D[] collider2Dspet = Physics2D.OverlapCircleAll(transform.position, ((IATKR)Pet.Atk).GetATKR());
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
