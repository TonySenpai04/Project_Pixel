using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tony
{
    [Serializable]
    public class SkillData
    {

        [Serializable]
        public class SkillAttributes
        {
            public float skillDuration;
            public float additionalStatSkill;
            public float coolDown;
            public SkillAttributes(float skillDuration, float additionalStatSkill, float coolDown)
            {
                this.skillDuration = skillDuration;
                this.additionalStatSkill = additionalStatSkill;
                this.coolDown = coolDown;

            }


        }

        [Serializable]
        public class SkillSet
        {
            public List<SkillAttributes> attributes;
            public SkillAttributes currentSkillAttributes;
            public void SetCurrentSkillAttributes(SkillAttributes currentSkill)
            {

                currentSkillAttributes = currentSkill;

            }
        }
    }
}
