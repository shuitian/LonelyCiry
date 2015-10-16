using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务奖励
/// </summary>
public class TaskReward : MonoBehaviour {

    /// <summary>
    /// 奖励的物品列表
    ///     所有的奖励都是以物品形式发出
    ///     包括金币、经验、装备、消耗品、技能
    ///     Item:物品
    ///     int:个数
    ///     人物奖励是给玩家还是给魔法师？
    ///     这得根据背包组件是挂载在玩家身上还是魔法师身上
    /// </summary>
    public Dictionary<Item, int> itemList= new Dictionary<Item,int>();
}
