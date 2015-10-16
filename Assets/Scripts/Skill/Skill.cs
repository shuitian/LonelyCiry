using UnityEngine;
using System.Collections;
using Regame;

/// <summary>
/// 技能
/// </summary>
public class Skill : MonoBehaviour, IForRevisableComponent
{

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public virtual RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.ONE_TIME;
    }

    /// <summary>
    /// for test
    /// </summary>
    public Character character;

    protected void Start()
    {
        CheckSkillFormat();
        this.ActOn(character);
    }

    /// <summary>
    /// 技能唯一ID
    ///     创建技能的时候，技能ID由服务器分配
    ///     技能释放或者击中，网络传输技能ID而非技能本身
    /// </summary>
    public long skillID;

    /// <summary>
    /// 原子技能列表
    /// </summary>
    [HideInInspector]
    public AtomicSkill[] atomicSkills;

    /// <summary>
    /// 原子技能个数（只读）
    /// </summary>
    public int atomicSkillsNumber
    {
        get
        {
            if (atomicSkills != null)
            {
                return atomicSkills.Length;
            }
            else
            {
                return 0;
            }
            
        }
    }

    /// <summary>
    /// 施法者
    /// </summary>
    [HideInInspector]
    public Character owner;

    /// <summary>
    /// 根据法强组件，加强技能伤害
    /// </summary>
    /// <param name="intensityComponent">法强组件</param>
    public virtual void SetDamageByIntensity(ElementIntensityAndDefenceComponent intensityComponent)
    {
        foreach (AtomicSkill t_atomicSkill in atomicSkills)
        {
            if (t_atomicSkill)
            {
                t_atomicSkill.SetDamageByIntensity(intensityComponent);
            }
        }
    }

    /// <summary>
    /// 释放技能
    /// </summary>
    public virtual void Release()
    {
        foreach (AtomicSkill t_atomicSkill in atomicSkills)
        {
            if (t_atomicSkill)
            {
                t_atomicSkill.Release();
            }
        }
    }

    /// <summary>
    /// 作用于角色，虚函数
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public virtual bool ActOn(Character character)
    {
        foreach (AtomicSkill t_atomicSkill in atomicSkills)
        {
            if (t_atomicSkill)
            {
                t_atomicSkill.ActOn(character);
            }
        }
        return true;
    }

    /// <summary>
    /// 取消作用于角色，虚函数
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public virtual bool CancelActOn(Character character)
    {
        foreach (AtomicSkill t_atomicSkill in atomicSkills)
        {
            if (t_atomicSkill)
            {
                t_atomicSkill.CancelActOn(character);
            }
        }
        return true;
    }

    /// <summary>
    /// 在层级面板添加一个空的原子技能
    /// </summary>
    public void AddAnEmptyAtomicSkillInHierarchy()
    {
        GameObject newAtomicSkill =  new GameObject("AtomicSkill");
        newAtomicSkill.AddComponent<AtomicSkill>();
        newAtomicSkill.transform.SetParent(transform);

        atomicSkills = GetComponentsInChildren<AtomicSkill>();
    }

    /// <summary>
    /// 在层级面板添加一个带有玩家buff的原子技能
    /// </summary>
    public void AddAnEmptyAtomicSkillWithBuffForPlayerInHierarchy()
    {
        GameObject newAtomicSkill = new GameObject("AtomicSkill");
        newAtomicSkill.transform.SetParent(transform);
        AtomicSkill newAtomicSkillComponent = newAtomicSkill.AddComponent<AtomicSkill>();

        atomicSkills = GetComponentsInChildren<AtomicSkill>();

        GameObject newBuff = new GameObject("Buff");
        newBuff.transform.SetParent(newAtomicSkill.transform);
        newBuff.AddComponent<ForPlayer>();
        newBuff.AddComponent<Buff>();
    }

    /// <summary>
    /// 在层级面板添加一个带有战斗人物buff的原子技能
    /// </summary>
    public void AddAnEmptyAtomicSkillWithBuffForFightCharacterInHierarchy()
    {
        GameObject newAtomicSkill = new GameObject("AtomicSkill");
        newAtomicSkill.transform.SetParent(transform);
        AtomicSkill newAtomicSkillComponent = newAtomicSkill.AddComponent<AtomicSkill>();

        atomicSkills = GetComponentsInChildren<AtomicSkill>();

        GameObject newBuff = new GameObject("Buff");
        newBuff.transform.SetParent(newAtomicSkill.transform);
        newBuff.AddComponent<ForFightCharacter>();
        newBuff.AddComponent<Buff>();
    }

    /// <summary>
    /// 检查并修正技能格式
    /// </summary>
    public void CheckSkillFormat()
    {
        atomicSkills = GetComponentsInChildren<AtomicSkill>();
        foreach (AtomicSkill t_atomicSkill in atomicSkills)
        {
            if (t_atomicSkill)
            {
                t_atomicSkill.skillAttribute.addedBuffToTargetWhenEncounter = t_atomicSkill.GetComponentInChildren<Buff>();
            }
        }
    }
}
