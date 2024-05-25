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
        [SerializeField] protected float force;
        [SerializeField] protected int projectileSpawnCount=1;
        public virtual void Start()
        {
            pet=GetComponent<Pet>();
            projectileSpawn = new SpawnProjectile(this.projectile, this.projectilePool,this.projectilePos, this.force);
        }
        public virtual void Update()
        {
            HandleEnemyFound();
        }

        [System.Obsolete]
        public virtual void HandleEnemyFound()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.transform.position, ((IATKR)pet.Atk).GetATKR());
            if (collider2Ds.Length>0)
            {
                Enemy firstEnemy=null;
                foreach (var item in collider2Ds)
                {
                    var enemy = item.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        firstEnemy = enemy;
                        break;
                    }
                    
                }
                if (firstEnemy != null)
                {
                    LookAtMonster(firstEnemy.transform.position);
                    Attack();
                }
                else
                {
                    this.transform.rotation =Quaternion.EulerAngles(0,0,0);
                }



            }
            
        }
        public virtual void LookAtMonster(Vector3 pos)
        {
           
                Vector3 targetDirection = pos - this.transform.position;
                float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
           
 
        }
        public virtual void Attack()
        {
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireRate)
            {
                
              
                projectileSpawn.Spawn(this.pet, projectileSpawnCount);
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
