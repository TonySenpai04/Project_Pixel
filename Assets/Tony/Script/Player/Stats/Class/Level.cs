using UnityEngine;
namespace Tony
{
    public class Level : ILevel
    {
        private int level = 1;
        private float currentExperience = 0;
        private int experienceNeed ;
        private IReadCSV<Data> readCSV;
        private IHitPoint hitPoint;
        private IATK atk;
        public Level(IReadCSV<Data> readCSV, IHitPoint hitPoint, IATK atk,int level)
        {
            this.readCSV = readCSV;
            this.hitPoint = hitPoint;
            this.atk = atk;
            this.level = level;
            SetData();
        }
        void SetData()
        {
            foreach (var item in readCSV.GetData())
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
                if (level < readCSV.GetData().Count)
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


            SetData();


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