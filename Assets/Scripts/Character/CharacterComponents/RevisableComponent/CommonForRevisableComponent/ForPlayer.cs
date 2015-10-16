using UnityEngine;
using System.Collections;

/// <summary>
/// 为玩家而设定的可修改属性组件
/// </summary>
[RequireComponent(typeof(RevisableExpAndLevelComponent))]
[RequireComponent(typeof(RevisableResourceComponent))]
public class ForPlayer : RevisableAttributeComponent{

	// Use this for initialization
    protected void Awake()
    {
        base.Awake();
	}
}
