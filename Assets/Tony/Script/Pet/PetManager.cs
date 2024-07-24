using System.Collections;
using System.Collections.Generic;
using Tony.Pet;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    [SerializeField] private List<PetBase> pets;
    public static PetManager instance;
    [SerializeField] private PetSlotManager petSlotManager;

    public PetSlotManager PetSlotManager { get => petSlotManager; }

    void Start()
    {
        instance = this;
        ActivatePetFromSlot(0);
    }
    public void ActivatePetFromSlot(int slotIndex)
    {
        
        PetBase pet = petSlotManager.GetPetFromSlot(slotIndex);
        if (pet != null)
        {
            // Deactivate all pets first
            foreach (PetBase p in pets)
            {
                if (p != pet)
                {
                    p.gameObject.SetActive(false);
                }
            }
            // Activate the selected pet
            pet.gameObject.SetActive(true);

        }
    }
    public PetBase FindPetById(string id)
    {
        return pets.Find(p => p.PetID == id);
    }
}
