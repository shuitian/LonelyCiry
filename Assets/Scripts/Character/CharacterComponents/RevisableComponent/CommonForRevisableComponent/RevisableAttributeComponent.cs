using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改属性组件，物品、技能与角色之间的交互类
/// </summary>
public class RevisableAttributeComponent : RevisableComponent{

    /// <summary>
    /// 可修改经验值等级组件
    /// </summary>
    protected RevisableExpAndLevelComponent revisableExpAndLevelComponent;

    /// <summary>
    /// 可修改生命值组件
    /// </summary>
    protected RevisableHpComponent revisableHpComponent;

    /// <summary>
    /// 可修改移动组件
    /// </summary>
    protected RevisableMoveComponent revisableMoveComponent;

    /// <summary>
    /// 可修改资源组件
    /// </summary>
    protected RevisableResourceComponent revisableResourceComponent;

    /// <summary>
    /// 可修改元素强度和抗性组件
    /// </summary>
    protected RevisableElementIntensityAndDefenceComponent revisableElementIntensityAndDefenceComponent;

    /// <summary>
    /// 挂载的组件列表，保留变量
    /// </summary>
    RevisableComponent[] revisableComponents;

    protected void Awake()
    {
        revisableExpAndLevelComponent = GetComponent<RevisableExpAndLevelComponent>();
        revisableHpComponent = GetComponent<RevisableHpComponent>();
        revisableMoveComponent = GetComponent<RevisableMoveComponent>();
        revisableResourceComponent = GetComponent<RevisableResourceComponent>();
        revisableElementIntensityAndDefenceComponent = GetComponent<RevisableElementIntensityAndDefenceComponent>();
        revisableComponents = GetComponents<RevisableComponent>();
    }

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行作用成功</returns>
    public override bool ActOn(Character character)
    {
        if (!base.ActOn(character))
        {
            return false;
        }
        foreach (RevisableComponent t_revisableComponent in revisableComponents)
        {
            if (!(t_revisableComponent is RevisableAttributeComponent))
            {
                t_revisableComponent.ActOn(character);
            }
        }
        return true;
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(Character character)
    {
        if (!base.CancelActOn(character))
        {
            return false;
        }
        foreach (RevisableComponent t_revisableComponent in revisableComponents)
        {
            if (!(t_revisableComponent is RevisableAttributeComponent))
            {
                t_revisableComponent.CancelActOn(character);
            }
        }
        return true;
    }
}
