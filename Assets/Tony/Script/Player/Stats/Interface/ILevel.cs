namespace Tony
{
    public interface ILevel
    {
         void GainExperience(int amount);
         float GetCurrentExp();
         float GetExperience();
         void SetExperience(int experience);
         int GetLevel();
         void SetLevel(int level);
       


    }
}