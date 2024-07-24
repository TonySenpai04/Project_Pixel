using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetButtonHandler : MonoBehaviour
{
    public PetManager petManager;
    public int slotIndex; 

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        petManager.ActivatePetFromSlot(slotIndex);
    }
}
