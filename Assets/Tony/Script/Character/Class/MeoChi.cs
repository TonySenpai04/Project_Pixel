using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class MeoChi : CharacterData
    {
        
        public override void Start()
        {
            SpeacialAbility();
        }


        public override void Update()
        {

        }
        public override void SpeacialAbility()
        {
            Debug.Log("Tăng 0.1% nhận được trứng hiếm và tăng 10% vàng");
        }
    }
}
