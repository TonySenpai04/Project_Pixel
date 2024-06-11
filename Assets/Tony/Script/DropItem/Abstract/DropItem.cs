
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tony.Item
{
    public abstract class DropItem : MonoBehaviour
    {
        [SerializeField] private GameObject ItemDrop;
        [SerializeField] private List<ItemSO> lootList = new List<ItemSO>();
        public virtual void Start()
        {
            
        }

        public virtual ItemSO GetDropItem()
        {
            int RanDom = Random.Range(1, 101);
            List<ItemSO> itemList = new List<ItemSO>();
            foreach (ItemSO item in lootList)
            {

                if (RanDom <= item.DropChange)
                {
                    itemList.Add(item);
                }
            }
            if (itemList.Count > 0)
            {
                ItemSO dropitem = itemList[Random.Range(0, itemList.Count)];

                return dropitem;
            }
            return null;
        }
        public  virtual void CreateItem(Vector3 spawnPosition)
        {
            ItemSO dropitem = GetDropItem();
            if (dropitem != null)
            {
                GameObject LootGameObject = Instantiate(ItemDrop, spawnPosition, Quaternion.identity);
                LootGameObject.GetComponent<Item>().ItemSO = dropitem;
                dropitem.ItemImage = LootGameObject.GetComponent<Item>().ItemSO.ItemImage;
                LootGameObject.GetComponent<SpriteRenderer>().sprite = dropitem.ItemImage;

            }
        }

    }
}

