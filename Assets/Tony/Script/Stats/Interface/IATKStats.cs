namespace Tony
{
    public interface IATKStats

    {
        // void SetData(float atk, float critRate, float attackRange, float attackSpeed, float critDamage);
         float GetAtk();
         float GetbaseATK();
         float GetCritRate();
         float GetAttackRange();
         float GetAttackSpeed();
         float GetCritDamage();

    }

}