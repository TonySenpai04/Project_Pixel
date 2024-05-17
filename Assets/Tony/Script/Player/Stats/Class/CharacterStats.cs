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
                    this.characterData.id = item.CharacterID;
                    this.characterData.name = item.CharacterName;
                }
            }
            UpdateCharacterData();
        }
        private void UpdateCharacterData()
        {
            Data currentData = datas.Find(item => item.Level == currentLevel);

            if (currentData != null)
            {
                hitPoint = new HitPoint(currentData.HP, currentData.DEG, currentData.CP);
                atk = new ATK(currentData.ATK);
                level = new Level(readCSV, hitPoint, atk,currentLevel);

                UpdateStatsText();
            }
        }
        private void UpdateStatsText()
        {
            statsTxt.text =
                " HP:" + hitPoint.GetHealth() +
                "\n Atk:" + atk.GetAtk() +
                "\n EXP:" + level.GetCurrentExp() + "/" + level.GetExperience() +
                "\n Level:" + level.GetLevel() +
                "\n Dodge:" + ((IDodge)hitPoint).GetDodge() +
                "\n CP:" + ((ICP)hitPoint).GetCP();
        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.U))
            {
                level.GainExperience(1000);
                this.currentLevel = level.GetLevel();
                statsTxt.text =
                    " HP:" + hitPoint.GetHealth()
                    + "\n Atk:" + atk.GetAtk()
                    + "\n EXP:" + level.GetCurrentExp() + "/" +level.GetExperience()
                    + "\n Level:" + level.GetLevel()
                    + "\n Dodge:" + ((IDodge)hitPoint).GetDodge()
                    + "\n CP:" + ((ICP)hitPoint).GetCP()
                    ;

            }
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 2);
        }

    }
   
}
