using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tony.Item
{
    public class PickUpItem : MonoBehaviour
    {

        private void Start()
        {
          
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Debug.Log("Pick up + " + item.ItemSO.Name);
                item.DestroyItem();
               
            }
        }

    }
}
