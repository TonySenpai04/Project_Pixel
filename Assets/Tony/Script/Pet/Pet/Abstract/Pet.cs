using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Tony
{
    public abstract class Pet : MonoBehaviour
    {
        [SerializeField] protected string id;
        [SerializeField] protected string petName;
        [SerializeField] protected TextAsset csvFile;
        [SerializeField] protected int currentLevel;
        [SerializeField] protected TextMeshProUGUI statsTxt;
        protected IReadCSV<PetData> readCSV;
        protected IHitPoint hitPoint;
        protected ILevel level;
        protected IATK atk;
        public TextAsset CSVFIle { get => csvFile; }

        public virtual void Awake()
        {
            readCSV = new ReadPetCSV<PetData>(this);
            readCSV.ReadData(SetData);
        }
        public virtual void SetData()
        {
            foreach (var item in readCSV.GetData())
            {
                if (item.ID != "" && item.Name != "")
                {
                    this.id = item.ID;
                    this.petName = item.Name;
                }
            }
            foreach (var item in readCSV.GetData())
            {

                if (item.Level == currentLevel)
                {
                    hitPoint = new PetHitPoint(item.HP, item.CP);
                    atk = new PetATK(item.ATK, item.ATKR, item.ATKS, item.CR, item.CD);
                    level = new PetLevel(readCSV, hitPoint, atk);
                    statsTxt.text =
                       " HP:" + hitPoint.GetHealth()
                       + "\n Atk:" + atk.GetAtk()
                       + "\n EXP:" + level.GetCurrentExp() + "/" + level.GetExperience()
                       + "\n Level:" + level.GetLevel()
                       + "\n ATKS:" + ((IATKS)atk).GetATKS()
                       + "\n ATKR:" + ((IATKR)atk).GetATKR()
                       + "\n CD:" + ((ICD)atk).GetCD()
                       + "\n CR:" + ((ICR)atk).GetCR()
                       + "\n CP:" + ((ICP)hitPoint).GetCP()
                        + "\n Level Skill 1:" + item.LevelSkill1
                         +"\n Level Skill 2:" + item.LevelSkill2
                          + "\n Level Skill 3:" + item.LevelSkill3
                       ;

                }
            }
        }
        public virtual void Update()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                level.GainExperience(10000);
                this.currentLevel = level.GetLevel();
                foreach (var item in readCSV.GetData())
                {

                    if (item.Level == currentLevel)
                    {
                        statsTxt.text =
                           " HP:" + hitPoint.GetHealth()
                           + "\n Atk:" + atk.GetAtk()
                           + "\n EXP:" + level.GetCurrentExp() + "/" + level.GetExperience()
                           + "\n Level:" + level.GetLevel()
                           + "\n ATKS:" + ((IATKS)atk).GetATKS()
                           + "\n ATKR:" + ((IATKR)atk).GetATKR()
                           + "\n CD:" + ((ICD)atk).GetCD()
                           + "\n CR:" + ((ICR)atk).GetCR()
                           + "\n CP:" + ((ICP)hitPoint).GetCP()
                            + "\n Level Skill 1:" + item.LevelSkill1
                             + "\n Level Skill 2:" + item.LevelSkill2
                              + "\n Level Skill 3:" + item.LevelSkill3
                           ;

                    }
                }
                       ;

            }
        }
    }
}