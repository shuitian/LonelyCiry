using UnityEngine;
using System.Collections;

/// <summary>
/// 攻击组件
/// </summary>
public class AttackComponent : BaseComponent
{
    /// <summary>
    /// 等级组件
    /// </summary>
    LevelComponent levelComponent;

    void Awake()
    {
        levelComponent = GetComponent<LevelComponent>();
    }

    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attackDistance = 10;

    /// <summary>
    /// 攻击力
    /// </summary>
    public float[] attacks;

    /// <summary>
    /// 攻击速度
    /// </summary>
    public float attackTimePerSecond = 1;

    /// <summary>
    /// 攻击类型
    /// </summary>
    public Elements attackType;
}
