using UnityEngine;
using System.Collections;

/// <summary>
/// 技能属性，太麻烦了，该简化到原子技能中
/// </summary>
[System.Serializable]
public class SkillAttribute : IActOnCharacter
{
    ///技能需要考虑的东西还是太多

    /// <summary>
    /// 施法延时
    /// </summary>
    public float fireDelayTime;

    /// <summary>
    /// 最大距离，相对于自身
    /// </summary>
    public float maxDist;

    /// <summary>
    /// 伤害
    /// </summary>
    public Damage.SkillDamage damage;

    /// <summary>
    /// 施法方向：从天而降，背后突袭，正面迎敌等
    /// </summary>
    public Vector3 fireDirect;

    /// <summary>
    /// 施法半径，当前版本为圆形区域
    /// </summary>
    public float targetRadius;
    /// <summary>
    /// 目标中心点位置，当前版本为圆形区域
    /// </summary>
    public Vector3 targetCenterPostion;

    ///// <summary>
    ///// 是否击中了一个目标
    ///// </summary>
    //public bool isEncounterWithTarget;

    /// <summary>
    /// 当击中时附加的Buff
    ///     当前版本中，一个子技能只能附加一个buff
    /// </summary>
    public Buff addedBuffToTargetWhenEncounter;

    /// <summary>
    /// 技能战斗力
    ///     战斗力由服务器计算返回
    /// </summary>
    public float skillBattleForce;

    /// <summary>
    /// 根据法强组件，加强技能伤害
    /// </summary>
    /// <param name="intensityComponent">法强组件</param>
    public void SetDamageByIntensity(ElementIntensityAndDefenceComponent intensityComponent)
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            damage.elementsDamage[i] = damage.elementsDamage[i] * (1 + intensityComponent.elementIntensityList[i]/100);
        }
    }

    /// <summary>
    /// 技能释放
    /// </summary>
    public void Release(AtomicSkill atomicSkill)
    {
        atomicSkill.StartCoroutine(SkillRelease());
    }

    /// <summary>
    /// 技能释放协程
    /// FIXME
    /// </summary>
    /// <returns>协程返回</returns>
    IEnumerator SkillRelease()
    {
        if (CheckParam()) 
        {
            yield return new WaitForSeconds(fireDelayTime);
        }
    }

    /// <summary>
    /// 检查技能属性参数是否合理
    /// FIXME
    /// </summary>
    /// <returns>合理返回真，反之返回假</returns>
    protected bool CheckParam()
    {
        if (fireDelayTime < 0 || fireDelayTime > 5) 
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public bool ActOn(Character character)
    {
        if (!character)
        {
            return false;
        }
        if (!character.IsElementsCharacter())
        {
            return false;
        }
        ElementsCharacter elementsCharacter = (ElementsCharacter)character;
        if (elementsCharacter.IsFightCharacter())
        {
            damage.ActOn(elementsCharacter);
            elementsCharacter.AttachBuff(addedBuffToTargetWhenEncounter);
            return true;
        }
        if (elementsCharacter.IsPlayer())
        {
            elementsCharacter.AttachBuff(addedBuffToTargetWhenEncounter);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public bool CancelActOn(Character character)
    {
        //if (!character.IsElementsCharacter())
        //{
        //    return false;
        //}
        //ElementsCharacter elementsCharacter = (ElementsCharacter)character;
        //elementsCharacter.DetachBuff(addedBuffToTargetWhenEncounter);
        return true;
    }

    /// <summary>
    /// 是否有buff
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public bool HaveBuff()
    {
        if (addedBuffToTargetWhenEncounter)
        {
            return true;
        }
        return false;
    }
}
