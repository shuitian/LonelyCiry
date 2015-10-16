using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

/// <summary>
/// 伤害静态类
/// </summary>
public class Damage {

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
        /// <param name="monster">怪物</param>
        public void ActOn(Monster monster)
        {
            monster.GetDamaged(this);
        }
    }

    /// <summary>
    /// 伤害核心计算公式
    /// </summary>
    /// <param name="monster">怪物</param>
    /// <param name="skillDamage">已经过法强加成的伤害类</param>
    /// <returns>计算抗性后的伤害值</returns>
    static public float CalculateDamage(Monster monster, Damage.SkillDamage skillDamage)
    {
        ///当前版本不存在神圣伤害or物理伤害
        if (!monster.armorComponent)
        {
            return skillDamage.GetTotalDamage();
        }
        float[] elementDefenceList = monster.armorComponent.GetElementDefenceList();
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


