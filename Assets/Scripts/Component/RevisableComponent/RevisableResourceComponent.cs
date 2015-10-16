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
        return this.CancelActOn(((Player)character).resourceComponent);
    }

    /// <summary>
    /// 作用于组件
    /// </summary>
    /// <param name="component">作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(BaseComponent component)
    {
        if (!base.ActOn(component))
        {
            return false;
        }
        ResourceComponent resourceComponent = (ResourceComponent)component;
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
        return true;
    }

    /// <summary>
    /// 取消作用于组件
    /// </summary>
    /// <param name="component">取消作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(BaseComponent component)
    {
        if (!base.CancelActOn(component))
        {
            return false;
        }
        ResourceComponent resourceComponent = (ResourceComponent)component;
        if (obtainMoneyRateAddedRate != 0)
        {
            resourceComponent.AddObtainMoneyRate(-obtainMoneyRateAddedRate);
        }
        return true;
    }
}
