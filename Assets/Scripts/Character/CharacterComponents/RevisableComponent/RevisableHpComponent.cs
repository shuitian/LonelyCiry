using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改生命值组件
/// </summary>
public class RevisableHpComponent : RevisableComponent{

    /// <summary>
    /// 生命值增加量，适用于药品，瞬间治疗技能
    /// </summary>
    public float hpAdded;

    /// <summary>
    /// 最大生命值增加量，适用于持久buff、装备
    /// </summary>
    public float maxHpAddedValue;

    /// <summary>
    /// 最大生命值增加百分不，适用于持久buff、装备
    /// </summary>
    public float maxHpAddedRate;

    /// <summary>
    /// 生命恢复增加值，适用于buff、光环、装备、持续扣血技能
    /// </summary>
    public float hpRecoverAddedValue;

    /// <summary>
    /// 生命值恢复增加百分比，适用于光环、buff、装备等
    /// </summary>
    public float hpRecoverAddedRate;

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
        if (!elementsCharacter.IsFightCharacter())
        {
            return false;
        }
        return this.ActOn(((FightCharacter)character).hpComponent);
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
        if (!elementsCharacter.IsFightCharacter())
        {
            return false;
        }
        return this.CancelActOn(((FightCharacter)character).hpComponent);
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
        HpComponent hpComponent = ((HpComponent)characterComponent);
        hpComponent.AddMaxHp(maxHpAddedValue, maxHpAddedRate);
        hpComponent.AddHp(hpAdded);
        hpComponent.AddHpRecover(hpRecoverAddedValue, hpRecoverAddedRate);
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
        HpComponent hpComponent = ((HpComponent)characterComponent);
        hpComponent.AddMaxHp(-maxHpAddedValue, -maxHpAddedRate);
        hpComponent.AddHpRecover(-hpRecoverAddedValue, -hpRecoverAddedRate);
        return true;
    }
}
