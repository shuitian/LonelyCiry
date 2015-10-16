using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改魔法值组件
/// </summary>
public class RevisableMpComponent : RevisableComponent
{

    /// <summary>
    /// 魔法值增加量，适用于药品，瞬间治疗技能
    /// </summary>
    public float mpAdded;

    /// <summary>
    /// 最大魔法值增加量，适用于持久buff、装备
    /// </summary>
    public float maxMpAddedValue;

    /// <summary>
    /// 最大魔法值增加百分不，适用于持久buff、装备
    /// </summary>
    public float maxMpAddedRate;

    /// <summary>
    /// 魔法恢复增加值，适用于buff、光环、装备、持续扣血技能
    /// </summary>
    public float mpRecoverAddedValue;

    /// <summary>
    /// 魔法值恢复增加百分比，适用于光环、buff、装备等
    /// </summary>
    public float mpRecoverAddedRate;

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(Character character)
    {
        if (!base.ActOn(character))
        {
            return false;
        }
        return this.ActOn(((Monster)character).mpComponent);
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
        return this.CancelActOn(((Monster)character).mpComponent);
    }

    /// <summary>
    /// 作用于组件
    /// </summary>
    /// <param name="characterComponent">作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(BaseComponent characterComponent)
    {
        if (!base.ActOn(characterComponent))
        {
            return false;
        }
        MpComponent mpComponent = ((MpComponent)characterComponent);
        mpComponent.AddMaxMp(maxMpAddedValue, maxMpAddedRate);
        mpComponent.AddMp(mpAdded);
        mpComponent.AddMpRecover(mpRecoverAddedValue, mpRecoverAddedRate);
        return true;
    }

    /// <summary>
    /// 取消作用于组件
    /// </summary>
    /// <param name="characterComponent">取消作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(BaseComponent characterComponent)
    {
        if (!base.CancelActOn(characterComponent))
        {
            return false;
        }
        MpComponent mpComponent = ((MpComponent)characterComponent);
        mpComponent.AddMaxMp(-maxMpAddedValue, -maxMpAddedRate);
        mpComponent.AddMpRecover(-mpRecoverAddedValue, -mpRecoverAddedRate);
        return true;
    }
}
