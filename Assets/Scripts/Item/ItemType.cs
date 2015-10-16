using UnityEngine;
using System.Collections;

/// <summary>
/// 物品类型
/// </summary>
public class ItemType {

    /// <summary>
    /// 物品类型枚举
    /// </summary>
    public enum ItemTypeEnum : int
    {
        /// <summary>
        /// 无
        /// </summary>
        NOTHING = -1,

        /// <summary>
        /// 装备
        /// </summary>
        EQUIPMENT = 0,

        /// <summary>
        /// 一次性消耗品
        /// </summary>
        CONSUMABLES = 1,
    }

    /// <summary>
    /// 装备类型枚举
    /// </summary>
    public enum EquipmentTypeEnum : int
    {
        /// <summary>
        /// 帽子
        /// </summary>
        HAT = 0,

        /// <summary>
        /// 衣服
        /// </summary>
        CLOTHES = 1,

        /// <summary>
        /// 裤子
        /// </summary>
        TROUSERS = 2,
        
        /// <summary>
        /// 鞋子
        /// </summary>
        SHOES = 3,

        /// <summary>
        /// 武器
        /// </summary>
        WEAPON = 4,

        /// <summary>
        /// 盾牌/副手
        /// </summary>
        SHIELD = 5, 

        /// <summary>
        /// 饰品
        /// </summary>
        DECORATION = 6,
    }
}
