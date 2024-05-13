using UnityEngine;
namespace Tony
{
    public class Level : ILevel
    {
        [SerializeField] private int level = 1;
        [SerializeField] private float currentExperience = 0;
        [SerializeField] private int experienceNeededForNextLevel = 20;
        [SerializeField] private float baseExp;
        [SerializeField] private float experienceMultiplier = 1.2f;

        public Level()
        {
            this.baseExp = experienceNeededForNextLevel;

        }

        public void GainExperience(int amount)
        {
            currentExperience += amount;
            if (currentExperience >= experienceNeededForNextLevel)
            {
                LevelUp();
            }
        }
        public void Restart()
        {
            level = 1;
            experienceNeededForNextLevel = 20;
            currentExperience = 0;
            baseExp = experienceNeededForNextLevel;
        }
        void LevelUp()
        {
            level++;
         

        }

        public float GetCurrentExp()
        {
            return currentExperience;
        }

        public float GetExperience()
        {
            return experienceNeededForNextLevel;
        }

        public void SetExperience(int experience)
        {
            experienceNeededForNextLevel = experience;
        }

        public int GetLevel()
        {
            return level;
        }
    }
}