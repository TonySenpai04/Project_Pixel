using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public abstract class EnemyControllerBase : MonoBehaviour
    {
        [SerializeField] protected Enemy enemy;
        [SerializeField] protected CharacterStats player;
        [SerializeField] protected Transform projectile;
        [SerializeField] protected Transform projectilePos;
        [SerializeField] protected Transform projectilePool;
        [SerializeField] protected IEnemyProjectileSpawn projectileSpawn;
        [SerializeField] protected float fireRate;
        [SerializeField] protected float nextFireTime;
        [SerializeField] protected int projectileSpawnCount = 1;
        public virtual void Start()
        {
            enemy = GetComponent<Enemy>();
            fireRate = ((IATKS)enemy.Atk).GetATKS();
            nextFireTime = fireRate;
        }

        [System.Obsolete]
        public virtual void Update()
        {
            fireRate = ((IATKS)enemy.Atk).GetATKS();
            HandlePlayerFound();
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
                    var player = item.GetComponent<CharacterStats>();
                    if (player != null)
                    {
                        this.player = player;
                        playerFound = true;
                        break;
                    }
                }

                if (playerFound)
                {
                    if (player != null)
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
    }
}
