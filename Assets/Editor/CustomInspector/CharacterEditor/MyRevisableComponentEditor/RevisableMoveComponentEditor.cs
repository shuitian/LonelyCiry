using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改移动组件编辑器
/// </summary>
[CustomEditor(typeof(RevisableMoveComponent))]
public class RevisableMoveComponentEditor : MyCustomRevisableInspector
{

    public override void DoOnOneTime(RevisableComponent revisableComponent)
    {
        base.DoOnOneTime(revisableComponent);
    }

    public override void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {
        base.DoOnOneTimeForever(revisableComponent);
        MyDrawDefaultInspector(revisableComponent);
    }

    public override void DoOnPersistence(RevisableComponent revisableComponent)
    {
        base.DoOnPersistence(revisableComponent);
        MyDrawDefaultInspector(revisableComponent);
    }

    public void MyDrawDefaultInspector(RevisableComponent revisableComponent)
    {
        RevisableMoveComponent target = (RevisableMoveComponent)revisableComponent;
        target.moveSpeedAddedValue = EditorGUILayout.FloatField("移动速度增加值", target.moveSpeedAddedValue);
        target.moveSpeedAddedRate = EditorGUILayout.FloatField("移动速度增加百分比", target.moveSpeedAddedRate);
    }
}
