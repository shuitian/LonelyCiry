using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 魔法值组件编辑器
/// </summary>
[CustomEditor(typeof(MpComponent))]
public class MpComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MpComponent mpComponent = (MpComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("当前魔法值", mpComponent.mp.ToString());
        EditorGUILayout.LabelField("最大魔法值", mpComponent.maxMp.ToString());
        EditorGUILayout.LabelField("每秒魔法恢复值", mpComponent.mpRecover.ToString());
    }
}

