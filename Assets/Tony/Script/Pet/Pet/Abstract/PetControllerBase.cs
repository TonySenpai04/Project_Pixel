using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public abstract class PetControllerBase : MonoBehaviour
    {
        [SerializeField] protected Pet pet;
        [SerializeField] protected Transform player;
        public virtual void Start()
        {
            pet=GetComponent<Pet>();
        }
        public virtual void Update()
        {
            HandleEnemyFound();
        }
        public virtual void HandleEnemyFound()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.transform.position, ((IATKR)pet.Atk).GetATKR());
            if (collider2Ds.Length>0)
            {
                foreach (var item in collider2Ds)
                {
                    var enemy = item.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        Debug.Log("have "+enemy.name+ " within attack range");
                    }


                }
                

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
