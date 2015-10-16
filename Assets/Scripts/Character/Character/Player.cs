using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家类
/// </summary>
[RequireComponent(typeof(NeverMoveComponent))]
[RequireComponent(typeof(ExpAndLevelComponent))]
//[RequireComponent(typeof(BattleComponent))]
public class Player : NonFightCharacter{

    /// <summary>
    /// 经验值和等级组件
    /// </summary>
    [HideInInspector]
    public ExpAndLevelComponent expAndLevelComponent;
    
    /// <summary>
    /// 战斗组件
    /// </summary>
    [HideInInspector]
    public BattleComponent battleComponent;

    protected void Awake()
    {
        base.Awake();
        characterCategory.category = CharacterCategory.Category.PLAYER;
        expAndLevelComponent = GetComponent<ExpAndLevelComponent>();
        //battleComponent = GetComponent<BattleComponent>();
    }
	
}
