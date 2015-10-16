using UnityEngine;
using System.Collections;

/// <summary>
/// 元素强度抗性组件
/// </summary>
public class ElementIntensityAndDefenceComponent : CharacterComponent
{
    void OnEnable()
    {
        CalculateElementIntensityList();
        CalculateElementDefenceList();
    }

    /// <summary>
    /// 基础元素强度列表
    /// </summary>
    [HideInInspector]
    public float[] baseElementIntensityList = new float[Elements.ELEMENT_NUMBER]{
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
        CharacterDataBuildIn.InitElementIntensity,
    };

    /// <summary>
    /// 元素强度增加值列表
    /// </summary>
    public float[] elementIntensityAddedList = new float[Elements.ELEMENT_NUMBER]{
        0,0,0,0,0,0,0,0,  
    };

    /// <summary>
    /// 元素强度列表
    /// </summary>
    public float[] elementIntensityList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 最小元素强度
    /// </summary>
    public float minElementIntensity
    {
        get
        {
            return CharacterDataBuildIn.minElementIntensity;
        }
    }

    /// <summary>
    /// 最大元素强度
    /// </summary>
    public float maxElementIntensity
    {
        get
        {
            return CharacterDataBuildIn.maxElementIntensity;
        }
    }
    /// <summary>
    /// 获得元素强度列表
    /// </summary>
    /// <returns>元素强度列表</returns>
    public float[] GetElementIntensityList()
    {
        return baseElementIntensityList;
    }

    /// <summary>
    /// 获得单个元素强度
    /// </summary>
    /// <param name="p_element">要获取的元素</param>
    /// <returns>元素强度</returns>
    public float GetElementIntensity(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return -1;
        }
        return baseElementIntensityList[(int)p_element];
    }

    /// <summary>
    /// 增加元素强度列表
    /// </summary>
    /// <param name="p_elementIntensityAddedList">增加的元素强度增加值列表</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementIntensityList(float[] p_elementIntensityAddedList)
    {
        return ChangeElementIntensityList(baseElementIntensityList, p_elementIntensityAddedList);
    }

    /// <summary>
    /// 增加单个元素强度
    /// </summary>
    /// <param name="p_element">要增加的元素</param>
    /// <param name="p_elementIntensityAdded">增加的元素强度增加值</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementIntensity(Elements.Element p_element,float p_elementIntensityAdded)
    {
        return ChangeElementIntensity(p_element, baseElementIntensityList[(int)p_element], p_elementIntensityAdded);
    }

    /// <summary>
    /// 改变元素强度列表
    /// </summary>
    /// <param name="p_baseElementIntensityList">新的基础元素强度列表</param>
    /// <param name="p_elementIntensityAddedList">新的元素强度增加值列表</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementIntensityList(float[] p_baseElementIntensityList, float[] p_elementIntensityAddedList)
    {
        if (p_baseElementIntensityList.Length != Elements.ELEMENT_NUMBER || p_elementIntensityAddedList.Length != Elements.ELEMENT_NUMBER)
        {
            return false;
        }
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            ChangeElementIntensity((Elements.Element)i, p_baseElementIntensityList[i], p_elementIntensityAddedList[i]);
        }
        return true;
    }

    /// <summary>
    /// 改变单个元素强度
    /// </summary>
    /// <param name="p_element">要改变的元素</param>
    /// <param name="p_baseElementIntensity">新的基础元素强度</param>
    /// <param name="p_elementIntensityAdded">新的元素强度增加值</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementIntensity(Elements.Element p_element, float p_baseElementIntensity, float p_elementIntensityAdded)
    {
        baseElementIntensityList[(int)p_element] = p_baseElementIntensity;
        elementIntensityAddedList[(int)p_element] = p_elementIntensityAdded;
        _CalculateElementIntensity(p_element);
        return true;
    }

    /// <summary>
    /// 根据基础元素强度列表、元素强度增加值列表，计算元素强度列表
    /// </summary>
    public void CalculateElementIntensityList()
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            _CalculateElementIntensity((Elements.Element)i);
        }
    }

    /// <summary>
    /// 根据单个基础元素强度、单个元素强度增加值，计算单个元素强度
    /// </summary>
    /// <param name="p_element">要计算的元素</param>
    private void _CalculateElementIntensity(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return;
        }
        elementIntensityList[(int)p_element] = baseElementIntensityList[(int)p_element]+elementIntensityAddedList[(int)p_element];

        if (elementIntensityList[(int)p_element] > maxElementIntensity)
        {
            elementIntensityList[(int)p_element] = maxElementIntensity;
        }
        if (elementIntensityList[(int)p_element] < minElementIntensity)
        {
            elementIntensityList[(int)p_element] = minElementIntensity;
        }
    }

    /// <summary>
    /// 基础元素抗性列表
    /// </summary>
    [HideInInspector]
    public float[] baseElementDefenceList = new float[Elements.ELEMENT_NUMBER]{
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence,
        CharacterDataBuildIn.InitElementDefence, 
    };

    /// <summary>
    /// 元素抗性增加值列表
    /// </summary>
    public float[] elementDefenceAddedList = new float[Elements.ELEMENT_NUMBER]{
        0,0,0,0,0,0,0,0,   
    };

    /// <summary>
    /// 元素抗性列表
    /// </summary>
    public float[] elementDefenceList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 最小元素抗性
    /// </summary>
    public float minElementDefence
    {
        get
        {
            return CharacterDataBuildIn.minElementDefence;
        }
    }

    /// <summary>
    /// 最大元素抗性
    /// </summary>
    public float maxElementDefence
    {
        get
        {
            return CharacterDataBuildIn.maxElementDefence;
        }
    }

    /// <summary>
    /// 获得元素抗性列表
    /// </summary>
    /// <returns>元素抗性列表</returns>
    public float[] GetElementDefenceList()
    {
        return elementDefenceList;
    }

    /// <summary>
    /// 获得单个元素抗性
    /// </summary>
    /// <param name="p_element">要获取的元素</param>
    /// <returns>元素抗性</returns>
    public float GetElementDefence(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return -1;
        }
        return baseElementDefenceList[(int)p_element];
    }

    /// <summary>
    /// 增加元素抗性列表
    /// </summary>
    /// <param name="p_elementDefenceAddedList">增加的元素抗性增加值列表</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementDefenceList(float[] p_elementDefenceAddedList)
    {
        return ChangeElementDefenceList(baseElementDefenceList, p_elementDefenceAddedList);
    }

    /// <summary>
    /// 增加单个元素抗性
    /// </summary>
    /// <param name="p_element">要增加的元素</param>
    /// <param name="p_elementDefenceAdded">增加的元素抗性增加值</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementDefence(Elements.Element p_element, float p_elementDefenceAdded)
    {
        return ChangeElementDefence(p_element, baseElementDefenceList[(int)p_element], p_elementDefenceAdded);
    }

    /// <summary>
    /// 改变元素抗性列表
    /// </summary>
    /// <param name="p_baseElementDefenceList">新的基础元素抗性列表</param>
    /// <param name="p_elementDefenceAddedList">新的元素抗性增加值列表</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementDefenceList(float[] p_baseElementDefenceList, float[] p_elementDefenceAddedList)
    {
        if (p_baseElementDefenceList.Length != Elements.ELEMENT_NUMBER || p_elementDefenceAddedList.Length != Elements.ELEMENT_NUMBER)
        {
            return false;
        }
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            ChangeElementDefence((Elements.Element)i, p_baseElementDefenceList[i], p_elementDefenceAddedList[i]);
        }
        return true;
    }

    /// <summary>
    /// 改变单个元素抗性
    /// </summary>
    /// <param name="p_element">要改变的元素</param>
    /// <param name="p_baseElementDefence">新的基础元素抗性</param>
    /// <param name="p_elementDefenceAdded">新的元素抗性增加值</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementDefence(Elements.Element p_element, float p_baseElementDefence, float p_elementDefenceAdded)
    {
        baseElementDefenceList[(int)p_element] = p_baseElementDefence;
        elementDefenceAddedList[(int)p_element] = p_elementDefenceAdded;
        _CalculateElementDefence(p_element);
        return true;
    }

    /// <summary>
    /// 根据基础元素抗性列表、元素抗性增加值列表，计算元素抗性列表
    /// </summary>
    public void CalculateElementDefenceList()
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            _CalculateElementDefence((Elements.Element)i);
        }
    }

    /// <summary>
    /// 根据单个基础元素抗性、单个元素抗性增加值，计算单个元素抗性
    /// </summary>
    /// <param name="p_element">要计算的元素</param>
    private void _CalculateElementDefence(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return;
        }
        elementDefenceList[(int)p_element] = baseElementDefenceList[(int)p_element] + elementDefenceAddedList[(int)p_element];

        if (elementDefenceList[(int)p_element] > maxElementDefence)
        {
            elementDefenceList[(int)p_element] = maxElementDefence;
        }
        if (elementDefenceList[(int)p_element] < minElementDefence)
        {
            elementDefenceList[(int)p_element] = minElementDefence;
        }
    }
}
