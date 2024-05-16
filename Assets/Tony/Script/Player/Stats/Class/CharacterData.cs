using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    [CreateAssetMenu(fileName ="CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string id;
        public string characterName;
        public TextAsset csvFile;
        public void SpeacialAbility()
        {

        }
    }
}
