using UnityEngine;
using System.Collections;

/// <summary>
/// 为战斗人物而写的可修改属性组件
/// </summary>
[RequireComponent(typeof(RevisableHpComponent))]
[RequireComponent(typeof(RevisableMoveComponent))]
[RequireComponent(typeof(RevisableElementIntensityAndDefenceComponent))]
public class ForFightCharacter : RevisableAttributeComponent{

    // Use this for initialization
    protected void Awake()
    {
        base.Awake();
    }
}
