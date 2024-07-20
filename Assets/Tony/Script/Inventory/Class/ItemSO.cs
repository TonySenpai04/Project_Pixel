using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Item
{
    [CreateAssetMenu]
    public   class ItemSO : ScriptableObject
    {
        [field: SerializeField]
        public bool IsStackable { get; set; }
        [SerializeField]
        public int ID => GetInstanceID();

        [field: SerializeField]
        public int MaxStackSize { get; set; } = 1;

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


