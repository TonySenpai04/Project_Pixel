using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class CapaaProjectile : GenericProjectile
    {
        [SerializeField] private PetControllerBase petController;
        public override void Awake()
        {
            base.Awake();
        }
        public void Initialize(PetControllerBase controller)
        {
            petController = controller;
        }
        [System.Obsolete]
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
           
                
            if (enemy != null)
            {
                if (petController.IsSkill1())
                {
                    int healingChance = 0;
                    float healingPercentage = 0f;
                    int level= petController.Pet.GetCurrentData().LevelSkill1;
                    switch (level)
                    {
                        case 1:
                            healingChance = 20;
                            healingPercentage = 0.50f;
                            break;
                        case 2:
                            healingChance = 40;
                            healingPercentage = 0.50f;
                            break;
                        case 3:
                            healingChance = 60;
                            healingPercentage = 0.50f;
                            break;
                        case 4:
                            healingChance = 100;
                            healingPercentage = 1.00f;
                            break;
                    }
                 
                    if (Random.Range(0, 100) < healingChance)
                    {
                        int healingAmount = (int)(dam * healingPercentage);
                        petController.Player.GetComponent<CharacterStats>().HitPoint.Heal(healingAmount);
                    }
                    
                  

                }
                gameObject.SetActive(false);
                enemy.TakeDamage(this.dam);
            }

        }
    }
}
