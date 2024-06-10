using System.Collections.Generic;
using Tony.Skill;
using UnityEditor;
using UnityEngine;

namespace Tony
{
    [CustomPropertyDrawer(typeof(SkillData.SkillSet))]
    public class SkillSetPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            int index = GetListIndex(property);
            label.text = "Skill " + (index+1);
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        private int GetListIndex(SerializedProperty property)
        {
            string path = property.propertyPath;
            string[] splitPath = path.Split('[', ']');
            return int.Parse(splitPath[1]);
        }
    }
}
