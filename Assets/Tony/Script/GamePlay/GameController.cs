using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class GameController : MonoBehaviour
    {
     
        void Update()
        {
            if(CharacterStats.instance.HitPoint.GetCurrentHealth() <=0)
            {
                Debug.Log("You Loss");
            }
        }
    }
}
