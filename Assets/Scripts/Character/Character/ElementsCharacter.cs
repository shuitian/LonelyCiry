using UnityEngine;
using System.Collections;

/// <summary>
/// 元素世界人物
/// </summary>
public class ElementsCharacter : Character
{
    /// <summary>
    /// 元素阵营,保留字段
    /// </summary>
    public ElementsCamp elementsCamp { get; set; }

    /// <summary>
    /// 人物类别
    /// </summary>
    public CharacterCategory characterCategory;

    protected void Awake()
    {
        base.Awake();
        isElementsCharacter = true;
    }

    /// <summary>
    /// 设置元素阵营
    /// </summary>
    /// <param name="p_element">要改变的元素阵营</param>
    /// <param name="p_inOut">加入或者退出</param>
    public void SetElementsCamp(Elements.Element p_element, bool p_inOut)
    {
        this.elementsCamp.SetElementCamp(p_element, p_inOut);
    }

    /// <summary>
    /// 是否是玩家
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool IsPlayer()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.PLAYER);
    }

    /// <summary>
    /// 是否是追随者
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool IsFollower()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.FOLLOWER);
    }

    /// <summary>
    /// 是否是NPC
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool IsNPC()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.NPC)
                || characterCategory.CheckCategory(CharacterCategory.Category.BUSINESS_MAN);
    }

    /// <summary>
    /// 是否是怪物
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool IsMonster()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.MONSTER)
                || characterCategory.CheckCategory(CharacterCategory.Category.BOSS)
                    || characterCategory.CheckCategory(CharacterCategory.Category.SUMMON_BELONG_TO_MONSTER);
    }

    /// <summary>
    /// 是否是追随者召唤物
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool IsSummonBelongToFollower()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.SUMMON_BELONG_TO_FOLLOWER);
    }

    /// <summary>
    /// 是否需要经验和等级
    /// </summary>
    /// <returns>是则返回真，反之返回假</returns>
    public bool NeedExpAndLevel()
    {
        return characterCategory.CheckCategory(CharacterCategory.Category.PLAYER);
    }

    /// <summary>
    /// 是否是战斗人物
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public bool IsFightCharacter()
    {
        return IsFollower() || IsMonster();
    }

    /// <summary>
    /// 附加buff，拷贝buff对象
    /// </summary>
    /// <param name="buffToBeAttached">要被附加的buff</param>
    public void AttachBuff(Buff buffToBeAttached)
    {
        if (buffToBeAttached)
        {
            buffToBeAttached.CopyBuffObjectToCharacterObject(gameObject);
        }
    }

    /// <summary>
    /// 移除buff，删除buff对象
    /// </summary>
    /// <param name="buffToBeDetached">要被移除的buff</param>
    public void DetachBuff(Buff buffToBeDetached)
    {
        if (buffToBeDetached)
        {
            buffToBeDetached.DetachBuff();
        }
    }
}
