using UnityEngine;
using System.Collections;

/// <summary>
/// 资源组件
/// </summary>
public class ResourceComponent : BaseComponent
{
    /// <summary>
    /// 当前金币
    /// </summary>
    public float money = 0;
    /// <summary>
    /// 金钱获取比率
    /// </summary>
    //[SerializeField]
    private float obtainMoneyRate = 1;

    /// <summary>
    /// 获取当前金钱
    /// </summary>
    /// <returns>当前金钱</returns>
    public float GetCurrentMoney()
    {
        return money;
    }

    /// <summary>
    /// 增加金钱
    /// </summary>
    /// <param name="p_money">金钱增加量</param>
    public void AddMoney(float p_money)
    {
        if (p_money < 0)
        {
            p_money = 0;
        }
        this.money += GetObtainMoneyRate() * p_money;
    }

    /// <summary>
    /// 无条件扣除相应金钱
    /// </summary>
    /// <param name="p_money">金钱扣除量</param>
    public void LoseMoney(float p_money)
    {
        if (p_money < 0)
        {
            p_money = 0;
        }
        this.money -= p_money;
    }

    /// <summary>
    /// 试着扣除相应金钱
    /// </summary>
    /// <param name="p_money">金钱扣除量</param>
    /// <returns>成功返回真，否则返回假</returns>
    public virtual bool TryToLoseMoney(float p_money)
    {
        if (p_money < 0)
        {
            p_money = 0;
        }
        if (this.money >= p_money)
        {
            this.money -= p_money;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获取金钱获取比率
    /// </summary>
    /// <returns>金钱获取比率</returns>
    public virtual float GetObtainMoneyRate()
    {
        if (obtainMoneyRate < 0)
        {
            return 0;
        }
        return obtainMoneyRate;
    }

    /// <summary>
    /// 增加金钱获取比率
    /// </summary>
    /// <param name="p_newObtainMoneyRateAdded">增加的金钱获取比率</param>
    public void AddObtainMoneyRate(float p_newObtainMoneyRateAdded)
    {
        obtainMoneyRate += p_newObtainMoneyRateAdded;
    }

    /// <summary>
    /// 改变金钱获取比率
    /// </summary>
    /// <param name="p_newObtainMoneyRate">新的金钱获取比率</param>
    public void ChangeObtainMoneyRate(float p_newObtainMoneyRate)
    {
        obtainMoneyRate = p_newObtainMoneyRate;
    }
}
