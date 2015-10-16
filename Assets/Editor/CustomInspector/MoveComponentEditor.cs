using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 移动组件编辑器
/// </summary>
[CustomEditor(typeof(MoveComponent))]
public class MoveComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MoveComponent moveComponent = (MoveComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("最小移动速度", moveComponent.minMoveSpeed.ToString());
        EditorGUILayout.LabelField("最大移动速度", moveComponent.maxMoveSpeed.ToString());
        EditorGUILayout.LabelField("当前移动速度", moveComponent.moveSpeed.ToString());
    }
}
