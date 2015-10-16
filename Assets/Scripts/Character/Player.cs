using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家类
/// </summary>
[RequireComponent(typeof(ResourceComponent))]
public class Player : Character{

    /// <summary>
    /// 资源组件
    /// </summary>
    [HideInInspector]
    public ResourceComponent resourceComponent;

    void Awake()
    {
        resourceComponent = GetComponent<ResourceComponent>();
    }
}
