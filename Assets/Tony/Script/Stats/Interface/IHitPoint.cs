namespace Tony
{
    public interface IHitPoint
    {
         float GetHealth();
         float GetCurrentHealth();
         void SetHealth(float value);
         void TakeDamage(int damage);

         void Heal(int amount);
         void Increasehealth(float amount);
         float GetBaseHealth();
        
    }
}