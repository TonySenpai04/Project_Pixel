using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class ATK : IATK
    {

        private float atk;
     
        public ATK(float damage)
        {
            this.atk = damage;
      
        }

        public float GetAtk()
        {
            return this.atk;
        }

        public void SetAtk(float value)
        {
            this.atk=value;
        }

        public void SetData(float atk)
        {
            this.atk=atk;

        }
        
    }
}
