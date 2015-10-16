using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 怪物类
/// </summary>
[RequireComponent(typeof(HpComponent))]
[RequireComponent(typeof(MpComponent))]
[RequireComponent(typeof(ArmorComponent))]
public class Monster : Character
{
    /// <summary>
    /// 生命值组件
    /// </summary>
    [HideInInspector]
    public HpComponent hpComponent;

    /// <summary>
    /// 魔法值组件
    /// </summary>
    [HideInInspector]
    public MpComponent mpComponent;

    /// <summary>
    /// 元素强度抗性组件
    /// </summary>
    [HideInInspector]
    public ArmorComponent armorComponent;

    protected void Awake()
    {
        base.Awake();
        hpComponent = GetComponent<HpComponent>();
        armorComponent = GetComponent<ArmorComponent>();
    }

    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="p_skillDamage">受到的伤害</param>
    public void GetDamaged(Damage.SkillDamage p_skillDamage)
    {
        if (!hpComponent || p_skillDamage == null)
        {
            return;
        }
        hpComponent.LoseHp(Damage.CalculateDamage(this, p_skillDamage));
    }

}
