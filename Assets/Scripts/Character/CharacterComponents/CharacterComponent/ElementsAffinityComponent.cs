using UnityEngine;
using System.Collections;

/// <summary>
/// 元素亲和力组件
/// </summary>
[RequireComponent(typeof(ElementIntensityAndDefenceComponent))]
public class ElementsAffinityComponent : CharacterComponent{

    void Awake()
    {
        elementIntensityAndDefenceComponent = GetComponent<ElementIntensityAndDefenceComponent>();
    }

    void Start()
    {
        CalculateElementAffinityList();
        CalculateElementBaseIntensityAndDefenceListByAffinityList();
    }

    /// <summary>
    /// 元素强度和抗性列表
    /// </summary>
    [HideInInspector]
    public ElementIntensityAndDefenceComponent elementIntensityAndDefenceComponent;

    /// <summary>
    /// 基础元素亲和力列表
    /// </summary>
    public float[] baseElementAffinityList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 元素亲和力增加值列表
    /// </summary>
    public float[] elementAffinityAddedList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 元素亲和力列表
    /// </summary>
    public float[] elementAffinityList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 最小元素亲和力
    /// </summary>
    public float minElementAffinity
    {
        get
        {
            return CharacterDataBuildIn.minElementAffinity;
        }
    }

    /// <summary>
    /// 最大元素亲和力
    /// </summary>
    public float maxElementAffinity
    {
        get
        {
            return CharacterDataBuildIn.maxElementAffinity;
        }
    }

    /// <summary>
    /// 获得元素亲和力列表
    /// </summary>
    /// <returns>元素亲和力列表</returns>
    public float[] GetElementAffinityList()
    {
        return baseElementAffinityList;
    }

    /// <summary>
    /// 获得单个元素亲和力
    /// </summary>
    /// <param name="p_element">要获取的元素</param>
    /// <returns>元素亲和力</returns>
    public float GetElementAffinity(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return -1;
        }
        return baseElementAffinityList[(int)p_element];
    }

    /// <summary>
    /// 增加元素亲和力列表
    /// </summary>
    /// <param name="p_elementAffinityAddedList">增加的元素亲和力增加值列表</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementAffinityList(float[] p_elementAffinityAddedList)
    {
        return ChangeElementAffinityList(baseElementAffinityList, p_elementAffinityAddedList);
    }

    /// <summary>
    /// 增加单个元素亲和力
    /// </summary>
    /// <param name="p_element">要增加的元素</param>
    /// <param name="p_elementAffinityAdded">增加的元素亲和力增加值</param>
    /// <returns>增加是否成功</returns>
    public bool AddElementAffinity(Elements.Element p_element, float p_elementAffinityAdded)
    {
        return ChangeElementAffinity(p_element, baseElementAffinityList[(int)p_element], p_elementAffinityAdded);
    }

    /// <summary>
    /// 改变元素亲和力列表
    /// </summary>
    /// <param name="p_baseElementAffinityList">新的基础元素亲和力列表</param>
    /// <param name="p_elementAffinityAddedList">新的元素亲和力增加值列表</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementAffinityList(float[] p_baseElementAffinityList, float[] p_elementAffinityAddedList)
    {
        if (p_baseElementAffinityList.Length != Elements.ELEMENT_NUMBER || p_elementAffinityAddedList.Length != Elements.ELEMENT_NUMBER)
        {
            return false;
        }
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            ChangeElementAffinity((Elements.Element)i, p_baseElementAffinityList[i], p_elementAffinityAddedList[i]);
        }
        return true;
    }

    /// <summary>
    /// 改变单个元素亲和力
    /// </summary>
    /// <param name="p_element">要改变的元素</param>
    /// <param name="p_baseElementAffinity">新的基础元素亲和力</param>
    /// <param name="p_elementAffinityAdded">新的元素亲和力增加值</param>
    /// <returns>改变是否成功</returns>
    public bool ChangeElementAffinity(Elements.Element p_element, float p_baseElementAffinity, float p_elementAffinityAdded)
    {
        baseElementAffinityList[(int)p_element] = p_baseElementAffinity;
        elementAffinityAddedList[(int)p_element] = p_elementAffinityAdded;
        _CalculateElementAffinity(p_element);
        return true;
    }

    /// <summary>
    /// 根据基础元素亲和力列表、元素亲和力增加值列表，计算元素亲和力列表
    /// </summary>
    public void CalculateElementAffinityList()
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            _CalculateElementAffinity((Elements.Element)i);
        }
        CalculateElementBaseIntensityAndDefenceListByAffinityList();
    }

    /// <summary>
    /// 根据单个基础元素亲和力、单个元素亲和力增加值，计算单个元素亲和力
    /// </summary>
    /// <param name="p_element">要计算的元素</param>
    private void _CalculateElementAffinity(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE || p_element == Elements.Element.ALL)
        {
            return;
        }
        elementAffinityList[(int)p_element] = baseElementAffinityList[(int)p_element] + elementAffinityAddedList[(int)p_element];

        if (elementAffinityList[(int)p_element] > maxElementAffinity)
        {
            elementAffinityList[(int)p_element] = maxElementAffinity;
        }
        if (elementAffinityList[(int)p_element] < minElementAffinity)
        {
            elementAffinityList[(int)p_element] = minElementAffinity;
        }
    }

    /// <summary>
    /// 根据亲和力列表,计算元素强度和抗性列表
    /// </summary>
    public void CalculateElementBaseIntensityAndDefenceListByAffinityList()
    {
        CharacterDataBuildIn.CalculateElementBaseIntensityAndDefenceListByAffinityList(elementAffinityList, ref elementIntensityAndDefenceComponent.baseElementIntensityList, ref elementIntensityAndDefenceComponent.baseElementDefenceList);
        if (elementIntensityAndDefenceComponent)
        {
            elementIntensityAndDefenceComponent.CalculateElementIntensityList();
            elementIntensityAndDefenceComponent.CalculateElementDefenceList();
        }
    }
}
