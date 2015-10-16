using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改组件接口
/// </summary>
public interface IForRevisableComponent : IActOnCharacter
{

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回1，否返回0，不明返回-1</returns>
    RevisiableTypeEnum IsOneTime();
}

/// <summary>
/// 可修改属性类型枚举
/// </summary>
public enum RevisiableTypeEnum : int
{
    /// <summary>
    /// 一次性
    /// </summary>
    ONE_TIME = 0,

    /// <summary>
    /// 持续性
    /// </summary>
    PERISISTENCE = 1,

    /// <summary>
    /// 不明
    /// </summary>
    UNCLEAR = 2,

    /// <summary>
    /// 永久状态
    /// </summary>
    FOREVER = 3,
}