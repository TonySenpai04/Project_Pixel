using System.Collections;
using System.Collections.Generic;
using Tony.Item;
using Tony.Projectile;
using Tony.Skill;
using UnityEngine;
using Tony.Player;
namespace Tony.Enemy
{
    public abstract class EnemyControllerBase : MonoBehaviour
    {
        [SerializeField] protected EnemyBase enemy;
        [SerializeField] protected PlayerControllerBase player;
        [SerializeField] protected Transform projectile;
        [SerializeField] protected Transform projectilePos;
        [SerializeField] protected Transform projectilePool;
        [SerializeField] protected IEnemyProjectileSpawn projectileSpawn;
        [SerializeField] protected float fireRate;
        [SerializeField] protected float nextFireTime;
        [SerializeField] protected int projectileSpawnCount = 1;
        [SerializeField] protected SkillControllerBase skillController;
        [SerializeField] protected EnemyAnimationControllerBase enemyAnimationController;

        public SkillControllerBase SkillController { get => skillController;  }

        public virtual void Start()
        {
            enemyAnimationController = GetComponent<EnemyAnimationControllerBase>();
            enemy = GetComponent<EnemyBase>();
            fireRate = ((IATKS)enemy.Atk).GetATKS();
            nextFireTime = fireRate;
        }

        [System.Obsolete]
        public virtual void Update()
        {
            fireRate = ((IATKS)enemy.Atk).GetATKS();
            HandlePlayerFound();
            OnDeath();
        }

        [System.Obsolete]
        public virtual void HandlePlayerFound()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, ((IATKR)enemy.Atk).GetATKR());

            if (collider2Ds.Length > 0)
            {
                bool playerFound = false;

                foreach (var item in collider2Ds)
                {
                    var player = item.GetComponent<PlayerControllerBase>();
                    if (player != null)
                    {
                        this.player = player;
                        playerFound = true;
                        break;
                    }
                }

                if (playerFound)
                {
                    if (player != null && player.Stats.HitPoint.GetCurrentHealth()>0)
                    {
                        Attack();
                    }
                }
                else
                {
                    player = null;
                }
            }
            else
            {
                player = null;
            }
        }

        public virtual void Attack()
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {
                enemyAnimationController.HitEnemytAnim();
                projectileSpawn.Spawn(this.enemy, projectileSpawnCount, player.transform);
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
        public virtual void OnDeath()
        {
            if (enemy.HitPoint.GetCurrentHealth() <= 0)
            {
                GetComponent<DropItem>().CreateItem(this.transform.position);
                this.gameObject.SetActive(false);
            }
        }
    }
}
