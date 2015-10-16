using UnityEngine;
using System.Collections;

/// <summary>
/// 怪物类
/// </summary>
public class Monster : FightCharacter {

    protected void Awake()
    {
        base.Awake();
        characterCategory.category = CharacterCategory.Category.MONSTER;
    }
}
