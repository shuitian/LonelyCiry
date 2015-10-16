using UnityEngine;
using System.Collections;

/// <summary>
/// 物品交易属性
/// </summary>
public class ItemTradeAttribute : MonoBehaviour
{

    /// <summary>
    /// 买卖折扣
    /// </summary>
    static public float discountBetweenBuyAndSell = ItemData.discountBetweenBuyAndSell;

    /// <summary>
    /// 交易税
    /// </summary>
    static public float tradeTax = ItemData.tradeTax;

    /// <summary>
    /// 从商店购买的价格(只读)
    /// </summary>
    public float buyingPrice
    {
        get { return this.sellingPrice / discountBetweenBuyAndSell; }
    }

    /// <summary>
    /// 卖给商店的价格
    /// </summary>
    public float sellingPrice;
}
