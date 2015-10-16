using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 元素强度和抗性组件编辑器
/// </summary>
[CustomEditor(typeof(ElementIntensityAndDefenceComponent))]
public class ElementIntensityAndDefenceComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ElementIntensityAndDefenceComponent elementIntensityAndDefenceComponent = (ElementIntensityAndDefenceComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("最小元素强度", elementIntensityAndDefenceComponent.minElementIntensity.ToString());
        EditorGUILayout.LabelField("最大元素强度", elementIntensityAndDefenceComponent.maxElementIntensity.ToString());
        EditorGUILayout.LabelField("最小元素抗性", elementIntensityAndDefenceComponent.minElementDefence.ToString());
        EditorGUILayout.LabelField("最大元素抗性", elementIntensityAndDefenceComponent.maxElementDefence.ToString());
    }
}
