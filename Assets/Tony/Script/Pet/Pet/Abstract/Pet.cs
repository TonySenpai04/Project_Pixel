using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Tony
{
    public abstract class Pet : MonoBehaviour
    {
        [SerializeField] protected string petID;
        [SerializeField] protected string petName;
        [SerializeField] protected TextAsset csvFile;
        [SerializeField] protected int currentLevel;
        [SerializeField] protected TextMeshProUGUI statsTxt;
        [SerializeField] protected List<PetData> petDatas;
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

            List<PetData> petDatasClone = readCSV.GetData();
            this.petDatas=petDatasClone;
            foreach (var item in petDatas)
            {
                if (item.PetID != "" && item.PetName != "")
                {
                    this.petID = item.PetID;
                    this.petName = item.PetName;
                }  
            }
             UpdatePetData();
            
        }
        protected void UpdatePetData()
        {
            PetData currentPetData = petDatas.Find(item => item.Level == currentLevel);

            if (currentPetData != null)
            {
                hitPoint = new PetHitPoint(currentPetData.HP, currentPetData.CP);
                atk = new PetATK(currentPetData.ATK, currentPetData.ATKR, currentPetData.ATKS, currentPetData.CR, currentPetData.CD);
                level = new PetLevel(readCSV, hitPoint, atk,currentLevel);

                UpdateStatsText(currentPetData);
            }
        }
        protected void UpdateStatsText(PetData petData)
        {
            statsTxt.text =
                " HP:" + hitPoint.GetHealth() +
                "\n Atk:" + atk.GetAtk() +
                "\n EXP:" + level.GetCurrentExp() + "/" + level.GetExperience() +
                "\n Level:" + level.GetLevel() +
                "\n ATKS:" + ((IATKS)atk).GetATKS() +
                "\n ATKR:" + ((IATKR)atk).GetATKR() +
                "\n CD:" + ((ICD)atk).GetCD() +
                "\n CR:" + ((ICR)atk).GetCR() +
                "\n CP:" + ((ICP)hitPoint).GetCP() +
                "\n Level Skill 1:" + petData.LevelSkill1 +
                "\n Level Skill 2:" + petData.LevelSkill2 +
                "\n Level Skill 3:" + petData.LevelSkill3;
        }

        public virtual void Update()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                level.GainExperience(10000);
                this.currentLevel = level.GetLevel();
                UpdatePetData();



            }
        }
    }
}