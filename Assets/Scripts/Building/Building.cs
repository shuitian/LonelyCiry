using UnityEngine;
using System.Collections;

/// <summary>
/// 建筑
/// </summary>
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(LevelComponent))]
public class Building : MonoBehaviour
{
    /// <summary>
    /// 级别组件
    /// </summary>
    LevelComponent levelComponent;

    /// <summary>
    /// 攻击组件
    /// </summary>
    AttackComponent attackComponent;

    void Awake()
    {
        levelComponent = GetComponent<LevelComponent>();
        attackComponent = GetComponent<AttackComponent>();

    }
    /// <summary>
    /// 建筑名称
    /// </summary>
    public string name;

    /// <summary>
    /// 建筑等级
    /// </summary>
    public int level
    {
        get { return levelComponent.level; }
    }

    public float attack
    {
        get { return attackComponent.attacks[level]; }
    }
}
