using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改经验值和等级组件
/// </summary>
public class RevisableExpAndLevelComponent : RevisableComponent{

    /// <summary>
    /// 经验值获取比率增加值，适用于双倍经验卡等
    /// </summary>
    public float obtainExpRateAddedRate;

    /// <summary>
    /// 经验值增加值，适用于经验豆等
    /// </summary>
    public float expAddedValue;

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
        if (!character.IsElementsCharacter())
        {
            return false;
        }
        ElementsCharacter elementsCharacter = (ElementsCharacter)character;
        if (!elementsCharacter.IsPlayer())
        {
            return false;
        }
        return this.ActOn(((Player)character).expAndLevelComponent);
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
        if (!character.IsElementsCharacter())
        {
            return false;
        }
        ElementsCharacter elementsCharacter = (ElementsCharacter)character;
        if (!elementsCharacter.IsPlayer())
        {
            return false;
        }
        return this.CancelActOn(((Player)character).expAndLevelComponent);
    }

    /// <summary>
    /// 作用于组件
    /// </summary>
    /// <param name="characterComponent">作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(CharacterComponent characterComponent)
    {
        if (!base.ActOn(characterComponent))
        {
            return false;
        }
        ExpAndLevelComponent expAndLevelComponent = (ExpAndLevelComponent)characterComponent;
        return 
            expAndLevelComponent.AddExpRate(obtainExpRateAddedRate)
                && expAndLevelComponent.AddExp(expAddedValue);
    }

    /// <summary>
    /// 取消作用于组件
    /// </summary>
    /// <param name="characterComponent">取消作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(CharacterComponent characterComponent)
    {
        if (!base.CancelActOn(characterComponent))
        {
            return false;
        }
        if (obtainExpRateAddedRate == 0)
        {
            return true;
        }
        ExpAndLevelComponent expAndLevelComponent = (ExpAndLevelComponent)characterComponent;
        return expAndLevelComponent.AddExpRate(-obtainExpRateAddedRate);
    }
}
