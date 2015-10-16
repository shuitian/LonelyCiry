using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

/// <summary>
/// 伤害静态类
/// </summary>
public class Damage {

    ///// <summary>
    ///// 技能属性中的伤害数据结构
    ///// </summary>
    //[StructLayout(LayoutKind.Explicit)]
    //public struct SkillAttributeDamage
    //{
    //    [FieldOffset(0)]
    //    public float damageLastTime;
    //    [FieldOffset(4)]
    //    public float damagePerSecond;
    //    [FieldOffset(0)]
    //    public double totalDamage;
    //}

    ///// <summary>
    ///// 设置一次性伤害
    ///// </summary>
    ///// <param name="damage">被设置的伤害数据结构</param>
    ///// <param name="totalDamage">一次性伤害值</param>
    //static public void SetTotalSkillAttributeDamage(SkillAttributeDamage damage, float totalDamage)
    //{
    //    damage.totalDamage = (double)(float)(totalDamage);
    //}

    ///// <summary>
    ///// 设置持续伤害
    ///// </summary>
    ///// <param name="damage">被设置的伤害数据结构</param>
    ///// <param name="damageLastTime">持续伤害持续时间</param>
    ///// <param name="damagePerSecond">持续伤害每秒伤害</param>
    //static public void SetContinuousSkillAttributeDamage(SkillAttributeDamage damage, float damageLastTime, float damagePerSecond)
    //{
    //    damage.damageLastTime = damageLastTime;
    //    damage.damagePerSecond = damagePerSecond;
    //}

    /// <summary>
    /// 伤害类
    /// </summary>
    [System.Serializable]
    public class SkillDamage
    {
        /// <summary>
        /// 元素伤害数组
        /// </summary>
        public float[] elementsDamage = new float[Elements.ELEMENT_NUMBER];

        /// <summary>
        /// 物理伤害
        /// </summary>
        public float physicalDamage;

        /// <summary>
        /// 获取总伤害
        /// </summary>
        /// <returns></returns>
        public float GetTotalDamage()
        {
            float sum = 0;
            foreach (float t_damage in elementsDamage)
            {
                sum += t_damage;
            }
            return sum + physicalDamage;
        }

        /// <summary>
        /// 作用于某个角色
        /// </summary>
        /// <param name="character">被作用于的角色</param>
        public void ActOn(Character character)
        {
            if (!character || !character.IsElementsCharacter()) 
            {
                return;
            }
            ElementsCharacter elementsCharacter = (ElementsCharacter)character;
            if (!elementsCharacter.IsFightCharacter())
            {
                return;
            }
            FightCharacter fightCharacter = (FightCharacter)elementsCharacter;
            fightCharacter.GetDamaged(this);
        }
    }

    /// <summary>
    /// 伤害核心计算公式
    /// </summary>
    /// <param name="fightCharacter">作用于的角色</param>
    /// <param name="skillDamage">已经过法强加成的伤害类</param>
    /// <returns>计算抗性后的伤害值</returns>
    static public float CalculateDamage(FightCharacter fightCharacter, Damage.SkillDamage skillDamage)
    {
        ///FIXME 物理组件
        if (!fightCharacter.elementIntensityAndDefenceComponent)
        {
            return skillDamage.GetTotalDamage();
        }
        float[] elementDefenceList = fightCharacter.elementIntensityAndDefenceComponent.GetElementDefenceList();
        float sum = 0;
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            ///当前版本不存在将伤害小于0的效果
            if (skillDamage.elementsDamage[i] < 0)
            {
                skillDamage.elementsDamage[i] = 0;
            }
            ///当前版本不存在将伤害转化成治疗的效果
            float p = 1 - elementDefenceList[i] / 100;
            if (p < 0)
            {
                p = 0;
            }
            sum += skillDamage.elementsDamage[i] * p;
        }
        ///FIXME 物理组件存在物理抗性，物理抗性还需计算
        return sum + skillDamage.physicalDamage;
    }
}


