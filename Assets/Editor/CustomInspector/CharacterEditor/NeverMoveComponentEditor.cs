using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 无法移动组件编辑器
/// </summary>
[CustomEditor(typeof(NeverMoveComponent))]
public class NeverMoveComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
    }
}

