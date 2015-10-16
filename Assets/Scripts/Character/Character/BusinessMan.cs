using UnityEngine;
using System.Collections;

/// <summary>
/// 商人类
/// </summary>
[RequireComponent(typeof(NeverMoveComponent))]
[RequireComponent(typeof(UnLimitedResourceComponent))]
public class BusinessMan : NPC {

    protected void Awake()
    {
        base.Awake();
        characterCategory.category = CharacterCategory.Category.BUSINESS_MAN;
    }
}
