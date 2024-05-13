using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    [CreateAssetMenu(fileName = "Character Data")]
    public class CharacterData : ScriptableObject
    {
        public string name;
        public float hitPoint;
        public float dodge;
        public int level;
        public float aTK;
        public float critRate;
        public float attackRange;
        public float attackSpeed;
        public float critDamage;
        public float specialAbility;
        public float coolDown;
        public CharacterData()
        {

        }
        public void UpgradeCharacter(int newLevel)
        {
           
        }
    }
}
