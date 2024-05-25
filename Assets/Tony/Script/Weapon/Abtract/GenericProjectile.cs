using System;
using UnityEngine;
namespace Tony
{
    public abstract class GenericProjectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;
        [SerializeField] protected AudioSource Audio;
        [SerializeField] protected Vector3 origin;
        [SerializeField] protected float dam;
        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();

            origin = transform.position;
        }

        public virtual void SetDam(float dam)
        {
            this.dam = dam;
        }


        [Obsolete]
        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(this.dam);
                gameObject.SetActive(false);

            }


        }
    }
}