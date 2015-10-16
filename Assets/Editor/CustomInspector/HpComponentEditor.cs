using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 生命值组件编辑器
/// </summary>
[CustomEditor(typeof(HpComponent))]
public class HpComponentEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        HpComponent hpComponent = (HpComponent)target;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("当前生命值", hpComponent.hp.ToString());
        EditorGUILayout.LabelField("最大生命值", hpComponent.maxHp.ToString());
        EditorGUILayout.LabelField("每秒生命恢复值", hpComponent.hpRecover.ToString());
    }
}

