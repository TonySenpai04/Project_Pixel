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

        public TextMeshProUGUI statsTxt;
        [SerializeField] private CharacterData characterData;
        public int currentLevel=1;
        public static CharacterStats instance;
        void Awake()
        {
            instance = this;
            readCSV = new ReadCharacterCSV<Data>(characterData);
            readCSV.ReadData(SetData);
        }
        private void SetData()
        {
            foreach (var item in readCSV.GetData())
            {
                if(item.ID!="" && item.Name != "")
                {
                    this.characterData.id= item.ID;
                    this.characterData.characterName = item.Name;
                }
            }
            foreach (var item in readCSV.GetData())
            {
                if (item.Level == currentLevel)
                {
                    hitPoint = new HitPoint(item.HP, item.DEG, item.CP);
                    atk = new ATK(item.ATK);
                    level = new Level(readCSV, hitPoint, atk);
                    statsTxt.text =
                    " HP:" + hitPoint.GetHealth()
                    + "\n Atk:" + atk.GetAtk()
                    + "\n EXP:" + level.GetCurrentExp() + "/" + level.GetExperience()
                    + "\n Level:" + level.GetLevel()
                    + "\n Dodge:" + ((IDodge)hitPoint).GetDodge()
                    + "\n CP:" + ((ICP)hitPoint).GetCP()
                    ;
                }
            }
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
