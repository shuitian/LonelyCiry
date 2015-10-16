using UnityEngine;
using System.Collections;

/// <summary>
/// 追随者类
/// </summary>
public class Follower : FightCharacter {

    protected void Awake()
    {
        base.Awake();
        characterCategory.category = CharacterCategory.Category.FOLLOWER;
    }
}
