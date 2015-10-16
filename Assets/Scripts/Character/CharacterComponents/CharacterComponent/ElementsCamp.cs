using UnityEngine;
using System.Collections;

/// <summary>
/// 元素世界人物阵营
/// </summary>
[System.Serializable]
public class ElementsCamp {

    
    /// <summary>
    /// 元素阵营布尔值列表
    /// </summary>
    public bool[] elementsCampList = new bool[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 构造函数，默认为无阵营
    /// </summary>
    public ElementsCamp()
    {
        QuitAllCamp();
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="p_element">要加入的阵营</param>
    public ElementsCamp(Elements.Element p_element)
    {
        if (p_element == Elements.Element.ALL)
        {
            JoinInAllCamp();
            return;
        }
        else
        {
            QuitAllCamp();
            if (p_element != Elements.Element.NONE)
            {
                elementsCampList[(int)p_element] = true;
            }
        }
    }

    /// <summary>
    /// 脱离所有阵营，即无阵营，元素阵营列表全为假
    /// </summary>
    public void QuitAllCamp()
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            elementsCampList[i] = false;
        }
    }

    /// <summary>
    /// 加入所有阵营,元素阵营列表全为真
    /// </summary>
    public void JoinInAllCamp()
    {
        for (int i = 0; i < Elements.ELEMENT_NUMBER; i++)
        {
            elementsCampList[i] = true;
        }
    }

    /// <summary>
    /// 设置阵营
    /// </summary>
    /// <param name="p_element">要改变的阵营</param>
    /// <param name="p_inOut">加入还是脱离</param>
    public void SetElementCamp(Elements.Element p_element, bool p_inOut)
    {
        if (p_element == Elements.Element.NONE)
        {
            if (p_inOut)
            {
                QuitAllCamp();
            }
        }
        else if (p_element == Elements.Element.ALL)
        {
            if (p_inOut)
            {
                JoinInAllCamp();
            }
            else
            {
                QuitAllCamp();
            }
        }
        else
        {
            elementsCampList[(int)p_element] = p_inOut;
        }
    }

    /// <summary>
    /// 是否在某一阵营
    /// </summary>
    /// <param name="p_element">要判断的阵营</param>
    /// <returns>是返回真，否返回假</returns>
    public bool InElementCamp(Elements.Element p_element)
    {
        if (p_element == Elements.Element.NONE)
        {
            return true;
        }
        if (p_element == Elements.Element.ALL)
        {
            foreach (bool t_query in elementsCampList)
            {
                if (!t_query)
                {
                    return false;
                }
            } return true;
        }
        return elementsCampList[(int)p_element];
    }
}
