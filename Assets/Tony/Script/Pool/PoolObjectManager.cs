using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class PoolObjectManager : MonoBehaviour
    {
        public static PoolObjectManager Instance;

        [SerializeField] private Dictionary<Transform, List<Transform>> objectPools = new Dictionary<Transform, List<Transform>>();

        private void Awake()
        {
            Instance = this;
        }

        public Transform GetObjectFromPool(Transform prefab, Transform shotPoint, Transform parent)
        {
            if (!objectPools.ContainsKey(prefab))
            {
                objectPools[prefab] = new List<Transform>();
            }

            List<Transform> pool = objectPools[prefab];

            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    pool[i].gameObject.transform.position = shotPoint.position;
                    pool[i].gameObject.SetActive(true);

                    return pool[i];
                }
            }

            GameObject newObj = Instantiate(prefab.gameObject, shotPoint.position, Quaternion.identity, parent);
            pool.Add(newObj.transform);
            return newObj.transform;
        }

        public void ReturnObjectToPool(Transform obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}