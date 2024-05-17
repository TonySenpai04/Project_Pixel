using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class PetHitPoint : IHitPoint, ICP
    {
        private float health;
        private float currentHealth;
        private float CP;
        public PetHitPoint (float health, float cP)
        {
            this.health = health;
            currentHealth = health;
            this.CP = cP;
        }
        public void TakeDamage(int damage)
        {
            
        }

        public void Heal(int amount)
        {
           
        }

        public float GetHealth()
        {
            return health;
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public void SetHealth(float value)
        {
            health = value;
        }
        public float GetCP()
        {
            return this.CP;
        }

        public void SetCP(float value)
        {
            this.CP = value;
        }

    }
}
