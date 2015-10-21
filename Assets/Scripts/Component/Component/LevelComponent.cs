using UnityEngine;
using System.Collections;

/// <summary>
/// 等级组件
/// </summary>
public class LevelComponent : BaseComponent
{

    /// <summary>
    /// 等级
    /// </summary>
    public int level = 1;

    /// <summary>
    /// 最大等级
    /// </summary>
    public int maxLevel;

    /// <summary>
    /// 升级所需金币
    /// </summary>
    public int[] levelUpGold;

    /// <summary>
    /// 设置等级
    /// </summary>
    /// <param name="p_level">新的等级</param>
    /// <returns>设置是否成功</returns>
    public bool SetLevel(int p_level = 1)
    {
        if (p_level < 0 || p_level > maxLevel)
        {
            return false;
        }
        this.level = p_level;
        return true;
    }

    /// <summary>
    /// 试着升级
    /// </summary>
    /// <returns>已经是最大等级返回0，升级成功返回1，升级失败返回-1</returns>
    public int TryToLevelUp()
    {
        if (Player.player.resourceComponent.TryToLoseMoney(levelUpGold[level]))
        {
            return LevelUp();
        }
        return -1;
    }

    /// <summary>
    /// 升级
    /// </summary>
    /// <returns>实际增加的等级</returns>
    int LevelUp()//返回实际增加的等级数
    {
        if (IsMaxLevel())
        {
            return 0;
        }
        level += 1;
        return 1;
    }

    /// <summary>
    /// 获取当前等级
    /// </summary>
    /// <returns>当前等级</returns>
    public float GetLevel()
    {
        return level;
    }

    /// <summary>
    /// 是否是最大等级
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public bool IsMaxLevel()
    {
        return (level == maxLevel);
    }
}
