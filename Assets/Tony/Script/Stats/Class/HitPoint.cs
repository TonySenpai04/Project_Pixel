using UnityEngine;
namespace Tony
{
    public class HitPoint : IHitPoint,IDodge
    {
        private float health;
        private float currentHealth;
        private float baseHealth;
        private float dodge;
        public HitPoint(float health, float dodge)
        {
            this.health = health;
            currentHealth = health;
            baseHealth = health;
            this.dodge = dodge;
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
            currentHealth = health;
        }

        public void Increasehealth(float amount)
        {
            health += amount;
        }

        public float GetBaseHealth()
        {
            return baseHealth;
        }

        public float GetDodge()
        {
            return this.dodge;
        }

        public void SetDodge(float dodge)
        {
          this.dodge=   dodge;
        }
    }

}
