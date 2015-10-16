using UnityEngine;
using System.Collections;

/// <summary>
/// 经验值和等级组件
/// </summary>
public class ExpAndLevelComponent : CharacterComponent{

    // Use this for initialization
    void Awake()
    {
        maxExpList = new float[maxLevel+1];
        CharacterDataBuildIn.SetValue<float[]>(CharacterDataBuildIn.maxExpList, ref this.maxExpList);
    }

    void Start()
    {
        SetExp(currentTotalExp, obtainExpRate);
    }

    /// <summary>
    /// 等级
    /// </summary>
    public int level = 1;

    /// <summary>
    /// 最大等级
    /// </summary>
    public int maxLevel
    {
        get
        {
            return CharacterDataBuildIn.maxLevel;
        }
    }

    /// <summary>
    /// 当前级别拥有的经验值
    /// </summary>
    protected  float currentLevelExp = 0;

    /// <summary>
    /// 拥有的总经验值
    /// </summary>
    public float currentTotalExp = 0;

    /// <summary>
    /// 经验值获取比率
    /// </summary>
    [SerializeField]
    private float obtainExpRate = 1;

    /// <summary>
    /// 最大经验值列表，列表长度与最大等级相关，数据来源于CharacterDataBuildIn.maxExpList
    /// </summary>
    public float[] maxExpList = CharacterDataBuildIn.maxExpList;

    /// <summary>
    /// 设置经验值
    /// </summary>
    /// <param name="p_totalExp">新的总经验值</param>
    /// <param name="p_expRate">新的经验值获取速率</param>
    /// <returns>是否设置成功</returns>
    public bool SetExp(float p_totalExp = 0, float p_expRate = 1)
    {
        if (p_totalExp < 0) 
        {
            return false;
        }
        this.currentTotalExp = p_totalExp;
        SetLevelAndLevelExpByTotalExp(p_totalExp);
        this.obtainExpRate = p_expRate;
        return true;
    }

    /// <summary>
    /// 根据总经验值设置等级和级别经验值
    /// </summary>
    /// <param name="p_totalExp">总经验值</param>
    /// <returns>设置是否成功</returns>
    public bool SetLevelAndLevelExpByTotalExp(float p_totalExp)
    {
        level = 1;
        while (p_totalExp >= maxExpList[level])
        {
            p_totalExp -= maxExpList[level];
            if (IsMaxLevel()) 
            {
                break;
            }
            level++;
        }
        currentLevelExp = p_totalExp;
        return true;
    }

    /// <summary>
    /// 获取当前级别经验值
    /// </summary>
    /// <returns>当前级别经验值</returns>
    public float GetCurrentLevelExp()
    {
        return currentLevelExp;
    }

    /// <summary>
    /// 获取总经验值
    /// </summary>
    /// <returns>总经验值</returns>
    public float GetCurrentTotalExp()
    {
        return currentTotalExp;
    }

    /// <summary>
    /// 获取经验值获取比率
    /// </summary>
    /// <returns>经验值获取比率</returns>
    public float GetExpRate()
    {
        if (this.obtainExpRate < 0)
        {
            return 0;
        }
        return obtainExpRate;
    }

    /// <summary>
    /// 增加经验值获取比率
    /// </summary>
    /// <param name="p_rateAdded">增加的经验值获取比率</param>
    /// <returns>增加是否成功</returns>
    public bool AddExpRate(float p_rateAdded)
    {
        obtainExpRate += p_rateAdded;
        return true;
    }

    /// <summary>
    /// 改变经验值获取比率
    /// </summary>
    /// <param name="p_rate">新的经验值获取比率</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeExpRate(float p_rate)
    {
        obtainExpRate = p_rate;
        return true;
    }

    /// <summary>
    /// 增加经验值
    /// </summary>
    /// <param name="p_exp">增加的经验值</param>
    /// <returns>增加是否成功</returns>
    public bool AddExp(float p_exp)
    {
        if (IsMaxLevel() || p_exp <= 0)
        {
            return true;
        }
        currentLevelExp += GetExpRate() * p_exp;
        currentTotalExp += GetExpRate() * p_exp;
        while (currentLevelExp >= maxExpList[level])
        {
            currentLevelExp -= maxExpList[level];
            AddLevel();
            if (IsMaxLevel())
            {
                break;
            }
        }
        return true;
    }



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

    ///// <summary>
    ///// 设置最大等级
    ///// </summary>
    ///// <param name="p_maxLevel">最大等级</param>
    ///// <returns>设置是否成功</returns>
    //public bool SetMaxLevel(int p_maxLevel)
    //{
    //    if (p_maxLevel < 0)
    //    {
    //        return false;
    //    }
    //    this.maxLevel = p_maxLevel;
    //    if (this.level > this.maxLevel)
    //    {
    //        this.level = this.maxLevel;
    //    }
    //    return true;
    //}

    /// <summary>
    /// 等价等级
    /// </summary>
    /// <param name="p_level">增加的等级</param>
    /// <returns>实际增加的等级</returns>
    public int AddLevel(int p_level = 1)//返回实际增加的等级数
    {
        if (p_level < 0)
        {
            return 0;
        }
        int levelTmp = level;
        level += p_level;
        if (level >= maxLevel)
        {
            level = maxLevel;
        }
        return level - levelTmp;
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
