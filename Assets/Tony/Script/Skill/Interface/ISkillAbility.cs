using UnityEngine.UI;

namespace Tony
{
    public interface ISkillAbility
    {
        void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText);
    }
}