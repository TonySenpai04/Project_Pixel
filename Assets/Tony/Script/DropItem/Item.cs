
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Item
{
    public  class Item : MonoBehaviour
    {

        [field: SerializeField]
        protected ItemSO itemSO;

        [field: SerializeField]
        protected int Quantity { get; set; } = 1;

        public ItemSO ItemSO { get => itemSO; set => itemSO = value; }

        [SerializeField]
        protected AudioSource audioSource;

        [field: SerializeField]
        protected float duration = 0.3f;

        public virtual void Start()
        {

            GetComponent<SpriteRenderer>().sprite = ItemSO.ItemImage;
            audioSource= GetComponent<AudioSource>();
        }

        public virtual void DestroyItem()
        {
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(AnimateItemPickup());

        }

        public virtual  IEnumerator AnimateItemPickup()
        {
            audioSource.Play();
            Vector3 startScale = transform.localScale;
            Vector3 endScale = Vector3.zero;
            float currentTime = 0;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                transform.localScale =
                    Vector3.Lerp(startScale, endScale, currentTime / duration);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
