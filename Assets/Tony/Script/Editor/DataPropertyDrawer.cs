using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Tony.Editor
{
    [CustomPropertyDrawer(typeof(Data))]
    public class DataPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            int currentLevel = property.FindPropertyRelative("Level").intValue;
            label.text = "Level " + currentLevel;
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
