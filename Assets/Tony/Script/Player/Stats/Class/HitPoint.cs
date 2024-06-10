using UnityEngine;
namespace Tony
{
    public class HitPoint : IHitPoint,IDodge,ICP, IDamReduction
    {
        private float health;
        private float currentHealth;
        private float dodge;
        private float CP;
        private float damageReduction=0;
        public HitPoint(float health, float dodge, float cP)
        {
            this.health = health;
            currentHealth = health;
            this.dodge = dodge;
            this.CP = cP;
            damageReduction = 0;
        }

        public void TakeDamage(int damage)
        {
            int reducedDamage;

 
            if (damageReduction < damage)
            {
                reducedDamage = damage - (int)damageReduction;
            }
            else
            {
                reducedDamage = 1; 
            }


            currentHealth -= reducedDamage;

            Debug.Log("Incoming Damage: " + damage);
            Debug.Log("Damage Reduction: " + damageReduction);
            Debug.Log("Calculated Reduced Damage: " + reducedDamage);


            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
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

        public void SetDamReduction(float damReduction)
        {
            this.damageReduction = damReduction;
        }
    }

}
