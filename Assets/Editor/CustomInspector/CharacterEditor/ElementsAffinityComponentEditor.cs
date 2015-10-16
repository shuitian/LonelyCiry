using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 元素亲和力组件编辑器
/// </summary>
[CustomEditor(typeof(ElementsAffinityComponent))]
public class ElementsAffinityComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ElementsAffinityComponent elementsAffinityComponent = (ElementsAffinityComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("最小元素亲和力", elementsAffinityComponent.minElementAffinity.ToString());
        EditorGUILayout.LabelField("最大元素亲和力", elementsAffinityComponent.maxElementAffinity.ToString());
    }
}
