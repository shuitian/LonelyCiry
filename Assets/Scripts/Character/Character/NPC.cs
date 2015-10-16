using UnityEngine;
using System.Collections;

/// <summary>
/// NPC类
/// </summary>
public class NPC : NonFightCharacter{

    protected void Awake()
    {
        base.Awake();
        characterCategory.category = CharacterCategory.Category.NPC;
    }
}
