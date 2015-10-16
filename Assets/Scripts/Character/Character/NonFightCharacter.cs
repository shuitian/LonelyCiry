using UnityEngine;
using System.Collections;

/// <summary>
/// 非战斗人物
/// </summary>
[RequireComponent(typeof(TradeComponent))]
[RequireComponent(typeof(ResourceComponent))]
public class NonFightCharacter : ElementsCharacter{

    /// <summary>
    /// 交易组件
    /// </summary>
    [HideInInspector]
    public TradeComponent tradeComponent;

    /// <summary>
    /// 资源组件
    /// </summary>
    [HideInInspector]
    public ResourceComponent resourceComponent;

    protected void Awake()
    {
        base.Awake();
        tradeComponent = GetComponent<TradeComponent>();
        resourceComponent = GetComponent<ResourceComponent>();
    }
}
