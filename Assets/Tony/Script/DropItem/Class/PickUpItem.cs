using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tony.Item
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;

        private void Start()
        {
          
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Debug.Log("Pick up + " + item.ItemSO.Name);
                inventory.AddItem(item.ItemSO,1);
                item.DestroyItem();
               
            }
        }

    }
}
