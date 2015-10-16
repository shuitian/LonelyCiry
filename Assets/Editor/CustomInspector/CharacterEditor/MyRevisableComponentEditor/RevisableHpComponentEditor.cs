using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改生命值组件编辑器
/// </summary>
[CustomEditor(typeof(RevisableHpComponent))]
public class RevisableHpComponentEditor : MyCustomRevisableInspector
{

    public override void DoOnOneTime(RevisableComponent revisableComponent)
    {
        base.DoOnOneTime(revisableComponent);
        RevisableHpComponent target = (RevisableHpComponent)revisableComponent;
        target.hpAdded = EditorGUILayout.FloatField("生命增加值", target.hpAdded);
    }

    public override void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {
        //base.DoOnOneTimeForever(revisableComponent);
        //DrawDefaultInspector();
        DoOnPersistence(revisableComponent);
    }

    public override void DoOnPersistence(RevisableComponent revisableComponent)
    {
        base.DoOnPersistence(revisableComponent);
        RevisableHpComponent target = (RevisableHpComponent)revisableComponent;
        target.maxHpAddedValue = EditorGUILayout.FloatField("最大生命值增加值", target.maxHpAddedValue);
        target.maxHpAddedRate = EditorGUILayout.FloatField("最大生命值增加百分比", target.maxHpAddedRate);
        target.hpRecoverAddedValue = EditorGUILayout.FloatField("生命恢复增加值", target.hpRecoverAddedValue);
        target.hpRecoverAddedRate = EditorGUILayout.FloatField("生命恢复增加百分比", target.hpRecoverAddedRate);
    }
}

