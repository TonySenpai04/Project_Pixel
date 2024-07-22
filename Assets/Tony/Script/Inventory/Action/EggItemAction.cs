using System.Collections;
using System.Collections.Generic;
using Tony.Pet;
using UnityEngine;
namespace Tony.Item
{
    [CreateAssetMenu(menuName = "EggItemAction")]
    public class EggItemAction : ItemActionSO
    {
        public float eggHatchingTime;
        public string petReceived;

        public override void Use()
        {
            Debug.Log("Egg Hatching Time: " + eggHatchingTime + " Day");
            Debug.Log("Pet Received: " + petReceived);
        }
    }
}