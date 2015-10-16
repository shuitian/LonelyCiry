using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改组件,挂载于buff、物品
/// </summary>
public class RevisableComponent : BaseComponent//,IActOnCharacter
{

    /// <summary>
    /// 作用于人物，虚函数
    /// </summary>
    /// <param name="character">被作用的人物</param>
    /// <returns>是否成功</returns>
    public virtual bool ActOn(Character character)
    {
        ///FIXME Component的加载和消除
        if (!character)
        {
            return false;
        } 
        return true;
    }

    /// <summary>
    /// 取消作用于人物，虚函数
    /// </summary>
    /// <param name="character">被取消作用的人物</param>
    /// <returns>是否成功</returns>
    public virtual bool CancelActOn(Character character)
    {
        if (!character)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 作用于角色组件，虚函数
    /// </summary>
    /// <param name="characterComponent">被作用的角色组件</param>
    /// <returns>是否成功</returns>
    public virtual bool ActOn(BaseComponent characterComponent)
    {
        if (!characterComponent)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 取消作用于角色组件，虚函数
    /// </summary>
    /// <param name="characterComponent">被取消作用的角色组件</param>
    /// <returns>是否成功</returns>
    public virtual bool CancelActOn(BaseComponent characterComponent)
    {
        if (!characterComponent)
        {
            return false;
        }
        return true;
    }
}
