using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 资源组件编辑器
/// </summary>
[CustomEditor(typeof(ResourceComponent))]
public class ResourceComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ResourceComponent resourceComponent = (ResourceComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("最大疲劳值", resourceComponent.maxTiredValue.ToString());
    }
}
