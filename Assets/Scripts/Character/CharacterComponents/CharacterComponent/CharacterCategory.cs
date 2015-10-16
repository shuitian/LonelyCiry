using UnityEngine;
using System.Collections;

/// <summary>
/// 人物类别
/// </summary>
[System.Serializable]
public class CharacterCategory  {

    /// <summary>
    /// 人物类别枚举
    /// </summary>
    public enum Category : int
    {
        /// <summary>
        /// 都不是
        /// </summary>
        NOTHING = -1,
        /// <summary>
        /// 玩家
        /// </summary>
        PLAYER = 0,
        /// <summary>
        /// 追随者，包括魔法师
        /// </summary>
        FOLLOWER = 1,
        /// <summary>
        /// NPC
        /// </summary>
        NPC = 2,
        /// <summary>
        /// 商人
        /// </summary>
        BUSINESS_MAN = 3,
        /// <summary>
        /// 怪物
        /// </summary>
        MONSTER = 4,
        /// <summary>
        /// BOSS
        /// </summary>
        BOSS = 5,
        /// <summary>
        /// 属于追随者的召唤物
        /// </summary>
        SUMMON_BELONG_TO_FOLLOWER = 6,
        /// <summary>
        /// 属于怪物的召唤物
        /// </summary>
        SUMMON_BELONG_TO_MONSTER = 7,
        /// <summary>
        /// 控制器
        /// </summary>
        CONTROLLER = 8,
    }

    /// <summary>
    /// 人物类别枚举成员变量
    /// </summary>
    public Category category;

    /// <summary>
    /// 验证类别与本类别是否一致
    /// </summary>
    /// <param name="p_category">要验证的人物类别</param>
    /// <returns>一致返回真，否则返回假</returns>
    public bool CheckCategory(Category p_category)
    {
        if (this.category == p_category)
        {
            return true;
        }
        return false;
    }
}
