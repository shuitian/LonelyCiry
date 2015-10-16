using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改资源组件
/// </summary>
public class RevisableResourceComponent : RevisableComponent{

    /// <summary>
    /// 金钱增加值，适用于金币掉落，礼包等
    /// </summary>
    public float moneyAddedValue;

    /// <summary>
    /// 金钱获取比率增加百分比，适用于双倍金钱卡
    /// </summary>
    public float obtainMoneyRateAddedRate;

    /// <summary>
    /// 疲劳值增加值，适用于商场等
    /// </summary>
    public float tiredValueAddedValue;

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
        return this.ActOn(((Player)character).resourceComponent);
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
        return this.CancelActOn(((Player)character).resourceComponent);
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
        ResourceComponent resourceComponent = (ResourceComponent)characterComponent;
        if (obtainMoneyRateAddedRate != 0)
        {
            resourceComponent.AddObtainMoneyRate(obtainMoneyRateAddedRate);
        }
        if (moneyAddedValue > 0)
        {
            resourceComponent.AddMoney(moneyAddedValue);
        }
        else if (moneyAddedValue < 0)
        {
            resourceComponent.LoseMoney(-moneyAddedValue);
        }
        if (tiredValueAddedValue > 0)
        {
            resourceComponent.AddTiredValue(tiredValueAddedValue);
        }
        else if (tiredValueAddedValue < 0)
        {
            resourceComponent.LoseTiredValue(-tiredValueAddedValue);
        }
        return true;
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
        ResourceComponent resourceComponent = (ResourceComponent)characterComponent;
        if (obtainMoneyRateAddedRate != 0)
        {
            resourceComponent.AddObtainMoneyRate(-obtainMoneyRateAddedRate);
        }
        return true;
    }
}
