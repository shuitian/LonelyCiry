using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 可修改组件编辑器类的父类
/// </summary>
public class MyCustomRevisableInspector : Editor{

    /// <summary>
    /// 是否是一次性用品
    /// </summary>
    public bool isOneTime = false;

    /// <summary>
    /// 是否是一次性永久性状态
    /// </summary>
    public bool isOneTimeForever = false;

    public override void OnInspectorGUI()
    {
        RevisableComponent revisableComponentTarget = (RevisableComponent)target;

        IForRevisableComponent iForRevisableComponent = revisableComponentTarget.GetComponent<IForRevisableComponent>();
        if (iForRevisableComponent != null) 
        {
            RevisiableTypeEnum revisiableType = iForRevisableComponent.IsOneTime();
            if (revisiableType == RevisiableTypeEnum.ONE_TIME)
            {
                isOneTime = true;
            }
            if (revisiableType == RevisiableTypeEnum.FOREVER)
            {
                isOneTimeForever = true;
            }
        }
        //Skill skill = revisableComponentTarget.GetComponent<Skill>();
        //Item item = revisableComponentTarget.GetComponent<Item>();
        /////FIXME 技能和物品有太多类似，能否简化
        //if (skill)
        //{
        //    RevisiableTypeEnum revisiableType = skill.IsOneTime();
        //    if (revisiableType == RevisiableTypeEnum.ONE_TIME)
        //    {
        //        isOneTime = true;
        //    }
        //    if (revisiableType == RevisiableTypeEnum.FOREVER)
        //    {
        //        isOneTimeForever = true;
        //    }
        //}
        //if (item)
        //{
        //    RevisiableTypeEnum revisiableType = item.IsOneTime();
        //    if (revisiableType == RevisiableTypeEnum.ONE_TIME)
        //    {
        //        isOneTime = true;
        //    }
        //    if (revisiableType == RevisiableTypeEnum.FOREVER)
        //    {
        //        isOneTimeForever = true;
        //    }
        //}
        if (isOneTime)
        {
            DoOnOneTime(revisableComponentTarget);
        }
        else if (isOneTimeForever)
        {
            DoOnOneTimeForever(revisableComponentTarget);
        }
        else
        {
            DoOnPersistence(revisableComponentTarget);
        }
    }

    /// <summary>
    /// 一次性用品的编辑器函数
    /// </summary>
    /// <param name="revisableComponent">可修改组件</param>
    public virtual void DoOnOneTime(RevisableComponent revisableComponent)
    {

    }

    /// <summary>
    /// 一次性永久状态用品的编辑器函数
    /// </summary>
    /// <param name="revisableComponent">可修改组件</param>
    public virtual void DoOnOneTimeForever(RevisableComponent revisableComponent)
    {

    }

    /// <summary>
    /// 持续性用品的编辑器函数
    /// </summary>
    /// <param name="revisableComponent">可修改组件</param>
    public virtual void DoOnPersistence(RevisableComponent revisableComponent)
    {

    }
}
