using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tony.Pet;
using UnityEngine;
namespace Tony.Item
{
    [CreateAssetMenu(menuName = "EggItemAction")]
    public class EggItemAction : ItemActionSO
    {
        public float eggHatchingTime;
        public string petReceivedId;

        public override void Use()
        {
           //PetBase pet= PetManager.instance.FindPetById(petReceivedId);
           // if (PetManager.instance.PetSlotManager.petSlots.Count < 3)
           // {
           //     PetManager.instance.PetSlotManager.petSlots.Add(pet);
           // }
            Debug.Log("Egg Hatching Time: " + eggHatchingTime + " Day");
            Debug.Log("Pet Received: " + petReceivedId);
        }
    }
}