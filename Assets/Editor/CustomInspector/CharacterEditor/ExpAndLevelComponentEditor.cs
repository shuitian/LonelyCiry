using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 经验与等级组件编辑器
/// </summary>
[CustomEditor(typeof(ExpAndLevelComponent))]
public class ExpAndLevelComponentEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ExpAndLevelComponent expAndLevelComponent = (ExpAndLevelComponent)target;
        EditorGUILayout.Space();
        if (expAndLevelComponent.IsMaxLevel())
        {
            EditorGUILayout.LabelField("当前级别已获得经验值", "已满级");
        }
        else
        {
            EditorGUILayout.LabelField("当前级别已获得经验值", expAndLevelComponent.GetCurrentLevelExp().ToString());
        }
        //EditorGUILayout.LabelField("当前级别总经验值", expAndLevelComponent.maxExpList[expAndLevelComponent.level].ToString());
    }
}
