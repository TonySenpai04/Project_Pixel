using System.Collections;
using System.Collections.Generic;
using Tony.Pet;
using UnityEngine;
using UnityEngine.UI;

public class PetSlotManager : MonoBehaviour
{
    public List<PetBase>petSlots;
    public Image[] slotImages;
    void Start()
    {
        UpdateAllSlotButtons();
    }
    public void UpdateAllSlotButtons()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < petSlots.Count && petSlots[i] != null)
            {
                slotImages[i].enabled = true;
                slotImages[i].sprite = petSlots[i].petIcon;
            }
            else
            {
                slotImages[i].enabled=false;
            }
        }
    }
    public void AssignPetToSlot(PetBase pet, int slotIndex)
    {
        for (int i = 0; i < petSlots.Count; i++)
        {
            if (petSlots[i] == null)
            {
                petSlots[i] = pet;
                UpdateAllSlotButtons();
                return;
            }
        }
        Debug.Log("No available slot to assign the pet.");
    }

    // Method to get a pet from a slot
    public PetBase GetPetFromSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < petSlots.Count)
        {
            return petSlots[slotIndex];
        }
        return null;
    }

}
