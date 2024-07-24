using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Item
{

    public abstract  class ItemSO : ScriptableObject
    {
        [SerializeField]
        public int ID;
        [field: SerializeField]
        public bool IsStackable { get; set; }


        [field: SerializeField]
        public double MaxStackSize { get; set; } = 1;

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }
        [field: SerializeField]
         public Sprite ItemImage { get; set; }
        [field: SerializeField]
        public Sprite BackGround { get; set; }
        [field: SerializeField] public int DropChange;
        [field: SerializeField] public bool Consumable;
        [field: SerializeField] public bool IsVisibleInInventory;
        [field: SerializeField] public ItemActionSO ItemAction { get; set; }

        // Method to use the item
        public void UseItem()
        {
            if (ItemAction != null)
            {
                ItemAction.Use();
                
            }
            else
            {
                Debug.LogWarning($"{Name} does not have a defined action.");
            }
        }

    }
   
   
}


