using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Map
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [SerializeField] private float radius;
        public void Update()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(endPoint.transform.position, radius);

            if (collider2Ds.Length > 0)
            {
               

                foreach (var item in collider2Ds)
                {
                    var player = item.GetComponent<CharacterStats>();
                    if (player != null)
                    {
                        Debug.Log("You Win");
                    }
                }

  
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(endPoint.transform.position, radius);
        }
    }
}
