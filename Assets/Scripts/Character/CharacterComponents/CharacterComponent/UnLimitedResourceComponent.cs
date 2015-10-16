using UnityEngine;
using System.Collections;

/// <summary>
/// 无限资源组件，适用于商人等，TODO：一些显示问题
/// </summary>
public class UnLimitedResourceComponent : ResourceComponent
{
    /// <summary>
    /// 试着扣除相应金钱
    /// </summary>
    /// <param name="p_money">金钱扣除量</param>
    /// <returns>返回真</returns>
    public override bool TryToLoseMoney(float p_money)
    {
        LoseMoney(p_money);
        return true;
    }

    /// <summary>
    /// 获取金钱获取比率
    /// </summary>
    /// <returns>金钱获取比率</returns>
    public override float GetObtainMoneyRate()
    {
        return 1;
    }

    /// <summary>
    /// 获取当前疲劳值
    /// </summary>
    /// <returns>0</returns>
    public override float GetCurrentTiredValue()
    {
        return 0;
    }

    /// <summary>
    /// 试着失去疲劳值
    /// </summary>
    /// <param name="p_value">疲劳值失去量</param>
    /// <returns>返回真</returns>
    public override bool TryToLoseTiredValue(float p_value)
    {
        return true;
    }

    /// <summary>
    /// 获取当前最大疲劳值
    /// </summary>
    /// <returns>0</returns>
    public override float GetCurrentMaxTiredValuue()
    {
        return 0;
    }
}
