using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class ATK : IATKStats, IAttackActions
    {

        private float atk;
        private float baseATK;
        private float critRate;
        private float attackRange;
        private float attackSpeed;
        private float critDamage;

        public ATK(float damage, float critRate, float attackRange, float attackSpeed , float critDamage)
        {
            this.atk = damage;
            this.baseATK = damage;
            this.critRate = critRate;
            this.attackRange = attackRange;
            this.attackSpeed = attackSpeed;
            this.critDamage = critDamage;
        }

        public float GetAtk()
        {
            return this.atk;
        }

        public float GetAttackRange()
        {
            return this.attackRange;
        }

        public float GetAttackSpeed()
        {
            return this.attackSpeed;
        }

        public float GetbaseATK()
        {
            return this.baseATK;
        }

        public float GetCritDamage()
        {
            return this.critDamage;
        }

        public float GetCritRate()
        {
            return this.critRate;
        }

        public void SetData(float atk, float critRate, float attackRange, float attackSpeed, float critDamage)
        {
            this.atk=atk;
            this.critRate = critRate;
            this.attackRange = attackRange;
            this.attackSpeed = attackSpeed;
            this.critDamage = critDamage;
        }
        
    }
}
