
using UnityEngine;
namespace Tony
{
    [CreateAssetMenu(fileName ="CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string characterID;
        public string characterName;
        public TextAsset csvFile;
        public void SpeacialAbility()
        {

        }
    }
}
