using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Tony
{
    public class CharacterStats : MonoBehaviour
    {
        private IHitPoint hitPoint;
        private ILevel level;
        private IATK atk;
        private IReadCSV<Data> readCSV;

        [SerializeField] protected TextMeshProUGUI statsTxt;
        [SerializeField] protected CharacterData characterData;
        [SerializeField] protected List<Data> datas;
        [SerializeField] protected int currentLevel=1;
        public static CharacterStats instance;
        public float Shield;

        public IATK Atk { get => atk;  }
        public IHitPoint HitPoint { get => hitPoint;}
        public ILevel Level { get => level;  }

        void Awake()
        {
            instance = this;
            readCSV = new ReadCharacterCSV<Data>(characterData);
            readCSV.ReadData(SetData);
        }
        private void SetData()
        {
            List<Data> datasClone = readCSV.GetData();
            this.datas = datasClone;
            foreach (var item in datas)
            {
                if (item.CharacterID != "" && item.CharacterName != "")
                {
                    this.characterData.characterID = item.CharacterID;
                    this.characterData.name = item.CharacterName;
                }
            }
            Initialization();
        }
        private void UpdateCharacterData()
        {
            Data currentData = datas.Find(item => item.Level == currentLevel);

            if (currentData != null)
            {

                UpdateStatsText();
            }
        }
 
        protected void Initialization()
        {
            Data currentData = datas.Find(item => item.Level == currentLevel);

            if (currentData != null)
            {
                hitPoint = new HitPoint(currentData.HP, currentData.DEG, currentData.CP);
                atk = new ATK(currentData.ATK);
                level = new Level(readCSV, HitPoint, Atk, currentLevel);

                UpdateStatsText();
            }
        }
        private void UpdateStatsText()
        {
            statsTxt.text =
                " CurrentHP:" + HitPoint.GetCurrentHealth() +
                " /HP:" + HitPoint.GetHealth() + 
                "\n Atk:" + Atk.GetAtk() +
                "\n EXP:" + Level.GetCurrentExp() + "/" + Level.GetExperience() +
                "\n Level:" + Level.GetLevel() +
                "\n Dodge:" + ((IDodge)HitPoint).GetDodge() +
                "\n CP:" + ((ICP)HitPoint).GetCP();
        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.U))
            {
                Level.GainExperience(1000);
                this.currentLevel = Level.GetLevel();
               

            }
            UpdateStatsText();
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 2);
        }

    }
   
}
