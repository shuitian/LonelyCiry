using UnityEngine;
using System.Collections;

/// <summary>
/// 全局内建数据
/// </summary>
public class DataBuildIn : MonoBehaviour {

    /// <summary>
    /// 基础最大生命值
    /// </summary>
    public const float baseMaxHp = 100;

    /// <summary>
    /// 最小最大生命值
    /// </summary>
    static public float minMaxHp = 10;

    /// <summary>
    /// 最大最大生命值
    /// </summary>
    static public float maxMaxHp = 10000;

    /// <summary>
    /// 基础每秒生命恢复值
    /// </summary>
    public const float baseHpRecover = 0;

    /// <summary>
    /// 基础最大魔法值
    /// </summary>
    public const float baseMaxMp = 100;

    /// <summary>
    /// 最小最大魔法值
    /// </summary>
    static public float minMaxMp = 10;

    /// <summary>
    /// 最大最大魔法值
    /// </summary>
    static public float maxMaxMp = 10000;

    /// <summary>
    /// 基础每秒魔法恢复值
    /// </summary>
    public const float baseMpRecover = 0;

    /// <summary>
    /// 基础移动速度
    /// </summary>
    public const float baseMoveSpeed = 1;

    /// <summary>
    /// 最大移动速度
    /// </summary>
    public const float maxMoveSpeed = 100;

    /// <summary>
    /// 最低元素抗性
    /// </summary>
    public const float minElementDefence = -50;

    /// <summary>
    /// 最高元素抗性
    /// </summary>
    public const float maxElementDefence = 100;

    ///// <summary>
    ///// 基础元素抗性列表
    ///// </summary>
    //static public float[] baseElementDefenceList = new float[Elements.ELEMENT_NUMBER]{
    //    0,0,0,0,0,0,0,0,
    //};

    /// <summary>
    /// 初始元素抗性
    /// </summary>
    static public int InitElementDefence = 50;

    /// <summary>
    /// 将前者（内建数据）赋给后者（引用数据）
    /// </summary>
    /// <typeparam name="type">泛型类型</typeparam>
    /// <param name="p_valueInCharacterDataBuildIn">ref 本类内建数据</param>
    /// <param name="p_maxLevel">引用变量</param>
    static public void SetValue<type>(type p_valueInCharacterDataBuildIn, ref type p_maxLevel)
    {
        p_maxLevel = p_valueInCharacterDataBuildIn;
    }
}
