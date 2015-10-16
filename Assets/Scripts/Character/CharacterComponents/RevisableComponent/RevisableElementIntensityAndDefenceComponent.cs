using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改元素强度和抗性组件
/// </summary>
public class RevisableElementIntensityAndDefenceComponent : RevisableComponent {

    /// <summary>
    /// 元素强度增加值列表
    /// </summary>
    public float[] elementIntensityAddedValueList = new float[Elements.ELEMENT_NUMBER];

    /// <summary>
    /// 元素抗性增加值列表
    /// </summary>
    public float[] elementDefenceAddedValueList = new float[Elements.ELEMENT_NUMBER];
}
