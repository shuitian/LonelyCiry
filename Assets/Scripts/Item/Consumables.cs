using UnityEngine;
using System.Collections;

/// <summary>
/// 消耗品
/// </summary>
public class Consumables : Item {

    /// <summary>
    /// FIXME 消耗品应该还包括
    ///     增加移动速度等BUFF
    ///     获得某些技能、物品等礼包
    ///     
    /// </summary>

    protected void Awake()
    {
        base.Awake();
        itemTypeEnum = ItemType.ItemTypeEnum.CONSUMABLES;
    }

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public override RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.ONE_TIME;
    }

    /// <summary>
    /// 消耗该物品
    /// </summary>
    /// <param name="character">消耗者</param>
    public void Consum(Character character)
    {
        this.ActOn(character);
    }
}
