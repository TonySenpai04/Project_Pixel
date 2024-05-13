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
        private IATKStats aTK;
        [SerializeField]private CharacterData chacracterData;
        public static CharacterStats instance;
        public TextMeshProUGUI statsTxt;

        void Awake()
        {
            instance = this;
            if (chacracterData != null )
            {
                hitPoint = new HitPoint(chacracterData.hitPoint,chacracterData.dodge);
                aTK = new ATK(chacracterData.aTK, chacracterData.critRate, chacracterData.attackRange, chacracterData.attackSpeed, chacracterData.critDamage);
                level = new Level();

                statsTxt.text = 
                    " HP:"+hitPoint.GetHealth()
                    + "\n Atk:" + aTK.GetAtk()
                    + "\n Level:" + level.GetLevel()
                    + "\n Dodge:" +((IDodge)hitPoint).GetDodge() 
                    + "\n Attack Range:" + aTK.GetAttackRange() 
                    + "\n Attack Speed:" +aTK.GetAttackSpeed()
                    + "\n Crit Damage:" + aTK.GetCritDamage()
                    + "\n Crit Rate:" + aTK.GetCritRate()
                    ;

            }

        }

        public void SetData(CharacterData characterData)
        {
            this.chacracterData = characterData;
            hitPoint = new HitPoint(chacracterData.hitPoint, chacracterData.dodge);
            aTK = new ATK(chacracterData.aTK, chacracterData.critRate, chacracterData.attackRange, chacracterData.attackSpeed, chacracterData.critDamage);
            level = new Level();
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chacracterData.attackRange);
        }

    }
   
}
