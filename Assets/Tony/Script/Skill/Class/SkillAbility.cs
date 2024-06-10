using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tony.Skill
{
    public class SkillAbility : ISkillAbility
    {
        public  void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
        {
            if (isCooldown)
            {
                currentCooldown -= Time.deltaTime;

                if (currentCooldown <= 0f)
                {
                    isCooldown = false;
                    currentCooldown = 0f;

                    if (skillImage != null)
                    {
                        skillImage.fillAmount = 0f;
                    }
                    if (skillText != null)
                    {
                        skillText.text = "";
                    }
                }
                else
                {
                    if (skillImage != null)
                    {
                        skillImage.fillAmount = currentCooldown / maxCooldown;
                    }
                    if (skillText != null)
                    {
                        skillText.text = Mathf.Ceil(currentCooldown).ToString();
                    }
                }
            }
        }

    }
}
