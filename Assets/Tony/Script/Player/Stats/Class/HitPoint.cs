﻿using UnityEngine;
namespace Tony
{
    public class HitPoint : IHitPoint,IDodge,ICP
    {
        private float health;
        private float currentHealth;
        private float dodge;
        private float CP;
        public HitPoint(float health, float dodge, float cP)
        {
            this.health = health;
            currentHealth = health;
            this.dodge = dodge;
            this.CP = cP;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
                currentHealth = 0;
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > health)
                currentHealth = health;
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


        public float GetDodge()
        {
            return this.dodge;
        }

        public void SetDodge(float dodge)
        {
          this.dodge=   dodge;
        }

        public float GetCP()
        {
            return this.CP;
        }

        public void SetCP(float value)
        {
            this.CP= value;
        }
    }

}
