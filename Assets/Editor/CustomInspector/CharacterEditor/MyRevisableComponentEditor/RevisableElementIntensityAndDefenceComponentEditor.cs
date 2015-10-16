using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改元素强度和抗性组件编辑器
/// </summary>
[CustomEditor(typeof(RevisableElementIntensityAndDefenceComponent))]
public class RevisableElementIntensityAndDefenceComponentEditor : MyCustomRevisableInspector
{
    public override void DoOnOneTime(RevisableComponent revisableComponent)
    {
        base.DoOnOneTime(revisableComponent);
        //DrawElementInspector(revisableComponent);
    }

    public override void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {
        base.DoOnOneTimeForever(revisableComponent);
        DrawElementInspector(revisableComponent);
    }

    public override void DoOnPersistence(RevisableComponent revisableComponent)
    {
        base.DoOnPersistence(revisableComponent);
        DrawElementInspector(revisableComponent);
    }

    public void DrawElementInspector(RevisableComponent revisableComponent)
    {
        RevisableElementIntensityAndDefenceComponent target = (RevisableElementIntensityAndDefenceComponent)revisableComponent;
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            target.elementIntensityAddedValueList[i] = EditorGUILayout.FloatField(((Elements.Element)i).ToString()+" 强度增加值", target.elementIntensityAddedValueList[i]);
        }
        EditorGUILayout.Separator();
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            target.elementDefenceAddedValueList[i] = EditorGUILayout.FloatField(((Elements.Element)i).ToString() + " 抗性增加值", target.elementDefenceAddedValueList[i]);
        }
    }
}
