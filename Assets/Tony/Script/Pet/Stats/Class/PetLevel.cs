using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class PetLevel : ILevel
    {
        private int level = 1;
        private float currentExperience = 0;
        private int experienceNeed;
        private IReadCSV<PetData> readCSV;
        private IHitPoint hitPoint;
        private IATK atk;
        public PetLevel(IReadCSV<PetData> readCSV, IHitPoint hitPoint, IATK atk,int level)
        {
            this.readCSV = readCSV;
            this.hitPoint = hitPoint;
            this.atk = atk;
            this.level = level;
            SetData();
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
   

            }
        }
        void SetData()
        {
            foreach (var item in readCSV.GetData())
            {
                if (item.Level == this.level)
                {
                    this.experienceNeed = item.EXPNeed;
                    hitPoint.SetHealth(item.HP);
                    atk.SetAtk(item.ATK);
                    ((ICD)atk).SetCD(item.CD);
                    ((ICP)hitPoint).SetCP(item.CP);
                    ((IATKS)atk).SetATKS(item.ATKS);
                    ((IATKR)atk).SetATKR(item.ATKR);
                    ((ICR)atk).SetCR(item.CR);

                }
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
            this.level = level;
        }
    }
}
