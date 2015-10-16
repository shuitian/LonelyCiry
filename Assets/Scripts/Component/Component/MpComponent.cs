using UnityEngine;
using System.Collections;

/// <summary>
/// 魔法值组件
/// </summary>
public class MpComponent : BaseComponent
{

    void OnEnable()
    {
        CalculateCurrentMaxMp();
        ResetMp();
        CalculateCurrentMpRecover();
        StartCoroutine(RecoverMpPerSecond());
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// 魔法值
    /// </summary>
    [HideInInspector]
    public float mp;

    /// <summary>
    /// 基础最大魔法值
    /// </summary>
    [SerializeField]
    protected float baseMaxMp = 0;

    /// <summary>
    /// 基础最大魔法值增加值
    /// </summary>
    public float maxMpAddedValue = 0;

    /// <summary>
    /// 最大魔法值百分比
    /// </summary>
    public float maxMpRate = 1;

    /// <summary>
    /// 最大魔法值
    /// </summary>
    [HideInInspector]
    public float maxMp;

    /// <summary>
    /// 最小最大魔法值
    /// </summary>
    public static float minMaxMp
    {
        get
        {
            return DataBuildIn.minMaxMp;
        }
    }

    /// <summary>
    /// 最大最大魔法值
    /// </summary>
    public static float maxMaxMp
    {
        get
        {
            return DataBuildIn.maxMaxMp;
        }
    }

    /// <summary>
    /// 获得魔法值
    /// </summary>
    /// <param name="p_mpObtained">魔法值获得量</param>
    /// <returns>实际增加的魔法值</returns>
    public float AddMp(float p_mpObtained)
    {
        if (p_mpObtained < 0 || mp > maxMp)
        {
            p_mpObtained = 0;
        }
        float mpTemp = mp;
        mp += p_mpObtained;
        if (mp > maxMp)
        {
            mp = maxMp;
        }
        return mp - mpTemp;
    }

    /// <summary>
    /// 无条件扣除相应魔法值
    /// </summary>
    /// <param name="p_mpLost">魔法值扣除量</param>
    public void LoseMp(float p_mpLost)
    {
        if (p_mpLost < 0)
        {
            p_mpLost = 0;
        }
        mp -= p_mpLost;
        ///现在并没有写死亡
    }

    /// <summary>
    /// 试着扣除相应魔法值
    /// </summary>
    /// <param name="p_mpLost">魔法值扣除量</param>
    /// <returns>扣除成功，返回真，否则返回假</returns>
    public bool TryToLoseMp(float p_mpLost)
    {
        if (p_mpLost < 0)
        {
            p_mpLost = 0;
        }
        if (mp > p_mpLost)
        {
            mp -= p_mpLost;
            return true;
        }
        return false;
        ///现在并没有写死亡
    }

    /// <summary>
    /// 得到当前魔法值
    /// </summary>
    /// <returns>当前魔法值</returns>
    public float GetCurrentMp()
    {
        return mp;
    }

    /// <summary>
    /// 重设魔法值为最大魔法值
    /// </summary>
    /// <returns>如果最大魔法值大于0，设置成功，返回真，否则返回假</returns>
    public bool ResetMp()
    {
        if (maxMp <= 0)
        {
            return false;
        }
        mp = maxMp;
        return true;
    }

    /// <summary>
    /// 魔法值清0
    /// </summary>
    public void ClearMp()
    {
        this.mp = 0;
    }

    /// <summary>
    /// 增加最大魔法值
    /// </summary>
    /// <param name="p_maxMpAddedValue">增加的基础最大魔法值增加值</param>
    /// <param name="p_maxMpRate">增加的最大魔法值百分比</param>
    /// <returns></returns>
    public bool AddMaxMp(float p_maxMpAddedValue, float p_maxMpRate)
    {
        return ChangeMaxMp(this.maxMpAddedValue + p_maxMpAddedValue, this.maxMpRate + p_maxMpRate);
    }

    /// <summary>
    /// 改变最大魔法值
    /// </summary>
    /// <param name="p_maxMpAddedValue">新的基础最大魔法值增加值</param>
    /// <param name="p_maxMpRate">新的最大魔法值百分比</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeMaxMp(float p_maxMpAddedValue, float p_maxMpRate)
    {
        this.maxMpAddedValue = p_maxMpAddedValue;
        this.maxMpRate = p_maxMpRate;
        CalculateCurrentMaxMp();
        return true;
    }

    /// <summary>
    /// 根据基础最大魔法值、基础最大魔法值增加值和最大魔法值增加百分比，计算最大魔法值
    /// </summary>
    protected void CalculateCurrentMaxMp()
    {
        maxMp = (baseMaxMp + maxMpAddedValue) * maxMpRate;
        CheckMaxMp();
    }

    /// <summary>
    /// 限定最大魔法值在一定范围内
    /// </summary>
    public void CheckMaxMp()
    {
        if (maxMp > maxMaxMp)
        {
            maxMp = maxMaxMp;
        }
        if (maxMp < minMaxMp)
        {
            maxMp = minMaxMp;
        }
    }

    /// <summary>
    /// 基础每秒魔法恢复值
    /// </summary>
    [SerializeField]
    protected float baseMpRecover = 0;

    /// <summary>
    /// 基础每秒魔法恢复值增加量
    /// </summary>
    public float mpRecoverAddedValue = 0;

    /// <summary>
    /// 每秒魔法恢复增加百分比
    /// </summary>
    public float mpRecoverRate = 1;

    /// <summary>
    /// 当前每秒魔法恢复值
    /// </summary>
    [HideInInspector]
    public float mpRecover;

    /// <summary>
    /// 增加每秒魔法恢复值
    /// </summary>
    /// <param name="p_mpRecoverAddedValue">增加的每秒魔法恢复增加值</param>
    /// <param name="p_mpRecoverRate">增加的每秒魔法恢复百分比</param>
    /// <returns>是否增加成功</returns>
    public bool AddMpRecover(float p_mpRecoverAddedValue, float p_mpRecoverRate)
    {
        return ChangeMpRecover(this.mpRecoverAddedValue + p_mpRecoverAddedValue, this.mpRecoverRate + p_mpRecoverRate);
    }

    /// <summary>
    /// 改变每秒魔法恢复值
    /// </summary>
    /// <param name="p_mpRecoverAddedValue">新的基础每秒魔法恢复增加值</param>
    /// <param name="p_mpRecoverRate">新的每秒魔法恢复增加百分比</param>
    /// <returns>是否改变成功</returns>
    public bool ChangeMpRecover(float p_mpRecoverAddedValue, float p_mpRecoverRate)
    {
        this.mpRecoverAddedValue = p_mpRecoverAddedValue;
        this.mpRecoverRate = p_mpRecoverRate;
        CalculateCurrentMpRecover();
        return true;
    }

    /// <summary>
    /// 根据基础每秒魔法恢复值、基础每秒魔法恢复增加值和每秒魔法恢复增加百分比，计算每秒魔法恢复值
    /// </summary>
    protected void CalculateCurrentMpRecover()
    {
        mpRecover = (baseMpRecover + mpRecoverAddedValue) * mpRecoverRate;
    }

    /// <summary>
    /// 协程，魔法恢复
    /// </summary>
    /// <returns></returns>
    IEnumerator RecoverMpPerSecond()
    {
        while (true)
        {
            if (mpRecover > 0)
            {
                AddMp(mpRecover * Time.deltaTime);
            }
            else if (mpRecover < 0)
            {
                LoseMp(-mpRecover * Time.deltaTime);
            }
            yield return 0;
        }
    }

    /// <summary>
    /// 暂停魔法恢复协程
    /// </summary>
    public void PauseMpRecover()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// 重新开始魔法恢复协程
    /// </summary>
    public void ResumeMpRecover()
    {
        PauseMpRecover();
        StartCoroutine(RecoverMpPerSecond());
    }
}
