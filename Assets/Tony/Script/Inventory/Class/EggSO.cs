using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Item
{
    [CreateAssetMenu]
    public class EggSO : ItemSO
    {
        [field: SerializeField]
        public EggType EggType { get; set; }
    }
    public enum EggType
    {
        Common,
        Rare, 
        Epic  , 
        Legendary
    }
}
