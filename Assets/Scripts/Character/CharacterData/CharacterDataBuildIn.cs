using UnityEngine;
using System.Collections;

/// <summary>
/// 角色的一些全局内建数据
/// </summary>
public class CharacterDataBuildIn : MonoBehaviour {

    /// <summary>
    /// 最大等级
    /// </summary>
    public const int maxLevel = 100;

    /// <summary>
    /// 每级升级所需要的经验值
    /// </summary>
    static public float[] maxExpList = new float[maxLevel+1]{
        10,10,10,10,10,10,10,10,10,10,     //0~9
        10,10,10,10,10,10,10,10,10,10,     //10~19
        10,10,10,10,10,10,10,10,10,10,     //20~29
        10,10,10,10,10,10,10,10,10,10,     //30~39
        10,10,10,10,10,10,10,10,10,10,     //40~49
        10,10,10,10,10,10,10,10,10,10,     //50~59
        10,10,10,10,10,10,10,10,10,10,     //60~69
        10,10,10,10,10,10,10,10,10,10,     //70~79
        10,10,10,10,10,10,10,10,10,10,     //80~89
        10,10,10,10,10,10,10,10,10,10,     //90~99
        10,                                //100
    };

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
    /// 基础移动速度
    /// </summary>
    public const float baseMoveSpeed = 1;

    /// <summary>
    /// 最大移动速度
    /// </summary>
    public const float maxMoveSpeed = 100;

    /// <summary>
    /// 最大疲劳值
    /// </summary>
    public const float maxTiredValue = 100;

    /// <summary>
    /// 最低元素强度
    /// </summary>
    public const float minElementIntensity = 0;

    /// <summary>
    /// 最高元素强度
    /// </summary>
    public const float maxElementIntensity = 150;

    /// <summary>
    /// 基础元素强度列表
    /// </summary>
    static public float[] baseElementIntensityList = new float[Elements.ELEMENT_NUMBER]{
        0,0,0,0,0,0,0,0,
    };

    /// <summary>
    /// 最低元素抗性
    /// </summary>
    public const float minElementDefence = -50;

    /// <summary>
    /// 最高元素抗性
    /// </summary>
    public const float maxElementDefence = 100;

    /// <summary>
    /// 基础元素抗性列表
    /// </summary>
    static public float[] baseElementDefenceList = new float[Elements.ELEMENT_NUMBER]{
        0,0,0,0,0,0,0,0,
    };

    /// <summary>
    /// 最低元素亲和力
    /// </summary>
    public const float minElementAffinity = 0;

    /// <summary>
    /// 最高元素亲和力
    /// </summary>
    public const float maxElementAffinity = 100;

    ///// <summary>
    ///// 基础元素亲和力列表
    ///// </summary>
    //static public float[] baseElementAffinityList = new float[Elements.ELEMENT_NUMBER]{
    //    0,0,0,0,0,0,0,0,
    //};

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

    /// <summary>
    /// 亲和力对元素强度的影响数组
    ///     数据来自于
    ///         Note/元素相生相克_0914.xlsx
    /// </summary>
    static public float[,] elementsIntensityAffinityInfluenceList = new float[Elements.ELEMENT_NUMBER, Elements.ELEMENT_NUMBER]{
        {   1,  .5f,    0,    0,    0,    0,  .5f,    0, },
        {   0,    1,  .5f,    0,    0,    0,    0,  .5f, },
        { .5f,    0,    1,  .5f,    0,    0,    0,    0, },
        {   0,  .5f,    0,    1,  .5f,    0,    0,    0, },
        {   0,    0,  .5f,    0,    1,  .5f,    0,    0, },
        {   0,    0,    0,  .5f,    0,    1,  .5f,    0, },
        {   0,    0,    0,    0,  .5f,    0,    1,  .5f, },
        { .5f,    0,    0,    0,    0,  .5f,    0,    1, },

    };

    /// <summary>
    /// 亲和力对元素抗性的影响数组
    ///     数据来自于
    ///         Note/元素相生相克_0914.xlsx
    /// </summary>
    static public float[,] elementsDefenceAffinityInfluenceList = new float[Elements.ELEMENT_NUMBER, Elements.ELEMENT_NUMBER]{
        {   1,    0,    0, -.5f,    0,    0, -.5f,    0, },
        {   0,    1,    0,    0, -.5f,    0,    0, -.5f, },
        {-.5f,    0,    1,    0,    0, -.5f,    0,    0, },
        {   0, -.5f,    0,    1,    0,    0, -.5f,    0, },
        {   0,    0, -.5f,    0,    1,    0,    0, -.5f, },
        {-.5f,    0,    0, -.5f,    0,    1,    0,    0, },
        {   0, -.5f,    0,    0, -.5f,    0,    1,    0, },
        {   0,    0, -.5f,    0,    0, -.5f,    0,    1, },
    };

    /// <summary>
    /// 初始元素法强
    ///     怪物
    ///     魔法师
    /// </summary>
    static public int InitElementIntensity  = 50;

    /// <summary>
    /// 初始元素抗性
    ///     怪物
    ///     魔法师
    /// </summary>
    static public int InitElementDefence  = 50;

    /// <summary>
    /// 根据元素亲和力列表计算基础元素强度和基础元素抗性
    /// </summary>
    /// <param name="p_elementAffinityList">元素亲和力列表</param>
    /// <param name="p_baseElementIntensityList">ref 基础元素强度</param>
    /// <param name="p_baseElementDefenceList">ref 基础元素抗性</param>
    static public void CalculateElementBaseIntensityAndDefenceListByAffinityList(float[] p_elementAffinityList, ref float[] p_baseElementIntensityList, ref float[] p_baseElementDefenceList)
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            p_baseElementIntensityList[i] = InitElementIntensity;
            p_baseElementDefenceList[i] = InitElementDefence;
        }
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            for (int j = 0; j < Elements.ELEMENT_NUMBER; j++)
            {
                p_baseElementIntensityList[j] += p_elementAffinityList[i] * elementsIntensityAffinityInfluenceList[i,j];
                p_baseElementDefenceList[j] += p_elementAffinityList[i] * elementsDefenceAffinityInfluenceList[i, j];
            }
        }
    }
}
