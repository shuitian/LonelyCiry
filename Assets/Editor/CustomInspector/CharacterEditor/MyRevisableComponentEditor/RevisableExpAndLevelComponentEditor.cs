using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改经验值和等级组件编辑器
/// </summary>
[CustomEditor(typeof(RevisableExpAndLevelComponent))]
public class RevisableExpAndLevelComponentEditor : MyCustomRevisableInspector
{

    public override void DoOnOneTime(RevisableComponent revisableComponent)
    {
        base.DoOnOneTime(revisableComponent);
        RevisableExpAndLevelComponent target = (RevisableExpAndLevelComponent)revisableComponent;
        target.expAddedValue = EditorGUILayout.FloatField("经验增加值", target.expAddedValue);
    }

    public override void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {
        base.DoOnOneTimeForever(revisableComponent);
        //DrawDefaultInspector();
        DoOnPersistence(revisableComponent);
    }

    public override void DoOnPersistence(RevisableComponent revisableComponent)
    {
        base.DoOnPersistence(revisableComponent);
        RevisableExpAndLevelComponent target = (RevisableExpAndLevelComponent)revisableComponent;
        target.obtainExpRateAddedRate = EditorGUILayout.FloatField("获取经验倍率增加百分比", target.obtainExpRateAddedRate);
    }
}