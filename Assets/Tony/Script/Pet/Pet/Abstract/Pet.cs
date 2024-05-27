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
        public IHitPoint HitPoint { get => hitPoint; }
        public List<PetData> PetDatas { get => petDatas; }
        public IATK Atk { get => atk;}
        public ILevel Level { get => level;  }

        public virtual void Awake()
        {
            readCSV = new ReadPetCSV<PetData>(this);
            readCSV.ReadData(SetData);
          
        }
        public virtual void SetData()
        {

            List<PetData> petDatasClone = readCSV.GetData();
            this.petDatas=petDatasClone;
            foreach (var item in PetDatas)
            {
                if (item.PetID != "" && item.PetName != "")
                {
                    this.petID = item.PetID;
                    this.petName = item.PetName;
                }  
            }
            Initialization();

        }
        protected void Initialization()
        {
            PetData currentPetData = PetDatas.Find(item => item.Level == currentLevel);

            if (currentPetData != null)
            {
                hitPoint = new PetHitPoint(currentPetData.HP, currentPetData.CP);
                atk = new PetATK(currentPetData.ATK, currentPetData.ATKR, currentPetData.ATKS, currentPetData.CR, currentPetData.CD);
                level = new PetLevel(readCSV, HitPoint, Atk, currentLevel);

                UpdateStatsText(currentPetData);
            }
        }
        protected void UpdatePetData()
        {
            PetData currentPetData = PetDatas.Find(item => item.Level == currentLevel);

            if (currentPetData != null)
            {

                UpdateStatsText(currentPetData);
            }
        }
        protected void UpdateStatsText(PetData petData)
        {
            statsTxt.text =
                " HP:" + HitPoint.GetHealth() +
                "\n Atk:" + Atk.GetAtk() +
                "\n EXP:" + Level.GetCurrentExp() + "/" + Level.GetExperience() +
                "\n Level:" + Level.GetLevel() +
                "\n ATKS:" + ((IATKS)Atk).GetATKS() +
                "\n ATKR:" + ((IATKR)Atk).GetATKR() +
                "\n CD:" + ((ICD)Atk).GetCD() +
                "\n CR:" + ((ICR)Atk).GetCR() +
                "\n CP:" + ((ICP)HitPoint).GetCP() +
                "\n Level Skill 1:" + petData.LevelSkill1 +
                "\n Level Skill 2:" + petData.LevelSkill2 +
                "\n Level Skill 3:" + petData.LevelSkill3;
        }

        public virtual void Update()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                Level.GainExperience(10000);
                this.currentLevel = Level.GetLevel();
                UpdatePetData();



            }
        }

    }
}