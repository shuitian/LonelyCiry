using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改生命值组件编辑器
/// </summary>
[CustomEditor(typeof(RevisableResourceComponent))]
public class RevisableResourceComponentEditor : MyCustomRevisableInspector
{

    public override void DoOnOneTime(RevisableComponent revisableComponent)
    {
        base.DoOnOneTime(revisableComponent);
        RevisableResourceComponent target = (RevisableResourceComponent)revisableComponent;
        target.moneyAddedValue = EditorGUILayout.FloatField("金钱增加值", target.moneyAddedValue);
        target.tiredValueAddedValue = EditorGUILayout.FloatField("疲劳增加值", target.tiredValueAddedValue);
    }

    public override void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {
        base.DoOnOneTimeForever(revisableComponent);
        DoOnPersistence(revisableComponent);
    }

    public override void DoOnPersistence(RevisableComponent revisableComponent)
    {
        base.DoOnPersistence(revisableComponent);
        RevisableResourceComponent target = (RevisableResourceComponent)revisableComponent;
        target.obtainMoneyRateAddedRate = EditorGUILayout.FloatField("获取金币倍率增加百分比", target.obtainMoneyRateAddedRate);
    }
}
