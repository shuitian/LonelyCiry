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
}
