using UnityEngine;
using System.Collections;

/// <summary>
/// 原子技能
/// </summary>
public class AtomicSkill : Skill {

    protected void Start()
    {
        //base.Start();
        skillAttribute.addedBuffToTargetWhenEncounter = GetComponentInChildren<Buff>();
    }

    /// <summary>
    /// 技能属性
    /// </summary>
    public SkillAttribute skillAttribute;

    /// <summary>
    /// 是否已经有一个buff
    /// </summary>
    /// <returns>有返回真，反之返回假</returns>
    public bool HaveBuff()
    {
        if (skillAttribute.HaveBuff())
        {
            return true;
        }
        if ((GetComponentsInChildren<Buff>()).Length != 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 根据法强组件，加强技能伤害
    /// </summary>
    /// <param name="intensityComponent">法强组件</param>
    public override void SetDamageByIntensity(ElementIntensityAndDefenceComponent intensityComponent)
    {
        skillAttribute.SetDamageByIntensity(intensityComponent);
    }

    /// <summary>
    /// 技能释放
    /// </summary>
    public override void Release()
    {
        skillAttribute.Release(this);
    }

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(Character character)
    {
        return skillAttribute.ActOn(character);
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(Character character)
    {
        return skillAttribute.CancelActOn(character);
    }

    /// <summary>
    /// 在层级面板添加适用于战斗人物的buff
    /// </summary>
    public void AddABuffForFightCharacterInHierarchy()
    {
        GameObject newBuff = new GameObject("Buff");
        newBuff.AddComponent<ForFightCharacter>();
        Buff newBuffComponent = newBuff.AddComponent<Buff>();
        newBuff.transform.SetParent(transform);
        skillAttribute.addedBuffToTargetWhenEncounter = newBuffComponent;
    }

    /// <summary>
    /// 在层级面板添加适用于玩家的buff
    /// </summary>
    public void AddABuffForPlayerInHierarchy()
    {
        GameObject newBuff = new GameObject("Buff");
        newBuff.AddComponent<ForPlayer>();
        Buff newBuffComponent = newBuff.AddComponent<Buff>();
        newBuff.transform.SetParent(transform);
        skillAttribute.addedBuffToTargetWhenEncounter = newBuffComponent;
    }
}
