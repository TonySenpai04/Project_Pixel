using UnityEngine;
namespace Tony
{
    public class Level : ILevel
    {
        [SerializeField] private int level = 1;
        [SerializeField] private float currentExperience = 0;
        [SerializeField] private int experienceNeed ;
        [SerializeField] private ReadCSV readCSV;
        private IHitPoint hitPoint;
        private IATK atk;
        public Level(ReadCSV readCSV, IHitPoint hitPoint, IATK atk)
        {
            this.readCSV = readCSV;
            this.hitPoint = hitPoint;
            this.atk = atk;
            foreach (var item in readCSV.Datas)
            {
                if (item.Level == this.level)
                {
                    this.experienceNeed = item.EXPNeed;
                    hitPoint.SetHealth(item.HP);
                    ((IDodge)hitPoint).SetDodge(item.DEG);
                    ((ICP)hitPoint).SetCP(item.CP);
                    atk.SetAtk(item.ATK);

                }
            }
        }

        public void GainExperience(int amount)
        {
            currentExperience += amount;
            if (currentExperience >= experienceNeed)
            {
                if (level < readCSV.Datas.Count)
                {
                    currentExperience -= experienceNeed;
                    LevelUp();
                }
                else
                {
                    currentExperience = experienceNeed;

                }
                //currentExperience -= experienceNeed;
                //LevelUp();
                
            }
        }
        void LevelUp()
        {
             level++;
            
 
            foreach (var item in readCSV.Datas)
            {
                if (item.Level == this.level)
                {
                    this.experienceNeed = item.EXPNeed;
                    hitPoint.SetHealth(item.HP);
                    ((IDodge)hitPoint).SetDodge(item.DEG);
                    ((ICP)hitPoint).SetCP(item.CP);
                    atk.SetAtk(item.ATK);

                }
            }


        }

        public float GetCurrentExp()
        {
            return currentExperience;
        }

        public float GetExperience()
        {
            return experienceNeed;
        }

        public void SetExperience(int experience)
        {
            experienceNeed = experience;
        }

        public int GetLevel()
        {
            return level;
        }

        public void SetLevel(int level)
        {
            this.level= level;
        }
    }
}