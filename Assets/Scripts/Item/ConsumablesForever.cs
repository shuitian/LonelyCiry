using UnityEngine;
using System.Collections;

/// <summary>
/// 永久状态消耗品
/// </summary>
public class ConsumablesForever : Consumables{

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public override RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.FOREVER;
    }
}
