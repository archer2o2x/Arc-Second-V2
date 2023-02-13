using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityPredicate;
using PopupWindow = UnityEngine.UIElements.PopupWindow;
//using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(UnityPredicate))]
public class UnityPredicateDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        UnityPredicate obj = GetVariable<UnityPredicate>(property);

        EditorGUI.BeginProperty(position, label, property);

        Rect backgroundRect = new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(property));
        EditorGUI.DrawRect(backgroundRect, new Color(0.2f, 0.2f, 0.2f));

        EditorGUI.indentLevel++;

        property.isExpanded = EditorGUI.Foldout(backgroundRect, property.isExpanded, property.displayName + " (Predicate)");

        Rect enumRect = new Rect(position.x + position.width * 0.8f, position.y, position.width * 0.2f, EditorGUI.GetPropertyHeight(property));
        obj.PredicateMode = (AdditionMode)EditorGUI.EnumPopup(enumRect, obj.PredicateMode);

        //EditorGUI.LabelField(backgroundRect, label.text + " (Predicate)");

        if (property.isExpanded)
        {
            Rect mainRect = new Rect(position.x, position.y + backgroundRect.height, position.width, GetPropertyHeight(property, label) - backgroundRect.height);
            EditorGUI.DrawRect(mainRect, new Color(0.3f, 0.3f, 0.3f));

            for (int i = 0; i < obj.GetCount(); i++)
            {
                Rect boxRect = new Rect(position.x, position.y + EditorGUI.GetPropertyHeight(property) * (1 + i), position.width, EditorGUI.GetPropertyHeight(property));
                EditorGUI.PropertyField(boxRect, property);
                //EditorGUI.DrawRect(boxRect, Color.blue);
            }

            Rect bottomRect = new Rect(position.x, position.y + GetPropertyHeight(property, label) - EditorGUI.GetPropertyHeight(property), position.width, EditorGUI.GetPropertyHeight(property));
            if (EditorGUI.DropdownButton(bottomRect, new GUIContent("+"), FocusType.Passive))
            {
                obj.AddListener(null);
            }
        }

        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
        {
            UnityPredicate obj = GetVariable<UnityPredicate>(property);

            return base.GetPropertyHeight(property, label) * (2 + obj.GetCount());
        }
        return base.GetPropertyHeight(property, label);
    }

    public T GetVariable<T>(SerializedProperty property)
    {
        var targetObject = property.serializedObject.targetObject;
        var targetObjectClassType = targetObject.GetType();
        var field = targetObjectClassType.GetField(property.propertyPath);
        if (field != null)
        {
            return (T)field.GetValue(targetObject);
        }
        return default(T);
    }

    /*public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var popup = new PopupWindow();
        container.Add(popup);
        popup.text = property.displayName + " - Using C#";
        popup.Add(new PropertyField(property.FindPropertyRelative("amount")));
        popup.Add(new PropertyField(property.FindPropertyRelative("unit")));
        popup.Add(new PropertyField(property.FindPropertyRelative("name"), "CustomLabel: Name"));

        return container;
    }*/
}
