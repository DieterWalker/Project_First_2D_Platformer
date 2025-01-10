using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false; // Vô hiệu hóa chỉnh sửa
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true; // Bật lại chỉnh sửa
    }
}
#endif

