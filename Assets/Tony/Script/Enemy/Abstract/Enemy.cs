using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tony;
using UnityEngine;
namespace Tony
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected string enemyID;
        [SerializeField] protected string enemyName;
        [SerializeField] protected TextAsset csvFile;
        [SerializeField] protected int currentLevel;
        [SerializeField] protected TextMeshProUGUI statsTxt;
        [SerializeField] protected List<EnemyData> enemyDatas;
        protected IReadCSV<EnemyData> readCSV;
        protected IHitPoint hitPoint;
        protected ILevel level;
        protected IATK atk;
        public TextAsset CSVFIle { get => csvFile; }
        public IHitPoint HitPoint { get => hitPoint; }
        public List<EnemyData> EnemyDatas { get => enemyDatas; }
        public IATK Atk { get => atk; }
        public ILevel Level { get => level; }
        public EnemyData enemyData;
        public virtual void Awake()
        {
            readCSV = new ReadEnemyCSV<EnemyData>(this);
            readCSV.ReadData(SetData);

        }
        public virtual void SetData()
        {

            List<EnemyData> petDatasClone = readCSV.GetData();
            this.enemyDatas = petDatasClone;
            foreach (var item in EnemyDatas)
            {
                if (item.EnemyID != "" && item.EnemyName != "")
                {
                    this.enemyID = item.EnemyID;
                    this.enemyName = item.EnemyName;
                }
            }
            Initialization();

        }
        protected void Initialization()
        {
            EnemyData currentEnemyData = EnemyDatas.Find(item => item.Level == currentLevel);

            if (currentEnemyData != null)
            {
                hitPoint = new EnemyHitPoint(currentEnemyData.HP, currentEnemyData.CP);
                atk = new EnemyATK(currentEnemyData.ATK, currentEnemyData.ATKR, currentEnemyData.ATKS, currentEnemyData.CR, currentEnemyData.CD);
                level = new EnemyLevel(readCSV, HitPoint, Atk, currentLevel);

                UpdateStatsText(currentEnemyData);
            }
        }
        protected void UpdateEnemyData()
        {
            EnemyData currentEnemyData = EnemyDatas.Find(item => item.Level == currentLevel);

            if (currentEnemyData != null)
            {

                UpdateStatsText(currentEnemyData);
            }
        }
        protected void UpdateStatsText(EnemyData enemyData)
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
                "\n Level Skill 1:" + enemyData.LevelSkill1 +
                "\n Level Skill 2:" + enemyData.LevelSkill2 +
                "\n Level Skill 3:" + enemyData.LevelSkill3;
        }

        public virtual void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Level.GainExperience(10000);
                this.currentLevel = Level.GetLevel();
                UpdateEnemyData();

            }
        }
        public void TakeDamage(float dam)
        {
            Debug.Log(dam);
        }
    }
}
