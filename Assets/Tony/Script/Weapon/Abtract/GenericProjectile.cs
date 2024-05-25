using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Tony
{
    public abstract class GenericProjectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;
        [SerializeField] protected AudioSource Audio;
        [SerializeField] protected Vector3 origin;
        [SerializeField] protected float dam;
        [SerializeField] protected Transform target;
        [SerializeField] protected float speed = 5f;
        [SerializeField] protected float homingStrength = 0.1f;
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
        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void FixedUpdate()
        {
            if (target != null)
            {
                Vector2 direction = (Vector2)target.position - rb.position;
                direction.Normalize();
                Vector2 newVelocity = Vector2.Lerp(rb.velocity, direction * speed, homingStrength);
                rb.velocity = newVelocity;
            }
            else
            {
                gameObject.SetActive(false);
            }
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