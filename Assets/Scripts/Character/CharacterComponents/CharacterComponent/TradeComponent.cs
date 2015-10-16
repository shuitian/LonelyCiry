using UnityEngine;
using System.Collections;

/// <summary>
/// 交易组件
/// </summary>
public class TradeComponent : CharacterComponent
{
    /// <summary>
    /// 从非战斗人物处购买物品
    /// </summary>
    /// <param name="seller">卖方</param>
    /// <param name="buyer">买方</param>
    /// <param name="item">物品</param>
    /// <param name="num">物品个数</param>
    /// <returns>交易是否成功</returns>
    public bool BuyFromNonFightCharacter(NonFightCharacter seller, Player buyer, Item item, int num)
    {
        if (seller && seller.tradeComponent && 
                buyer && buyer.tradeComponent && 
                    item && num > 0 &&
                        buyer.tradeComponent.Buy(seller, buyer, item, num))
        {
            //TODO
            //更新数据
            return true;
        }
        //提示错误信息
        return false;
    }

    public bool Buy(NonFightCharacter seller, Player buyer, Item item, int num)
    {
        //TODO
        //发送seller、buyer、item的id和num到服务器，服务器返回结果
        //为真，return true;
        //为假，return false;
        return false;
    }
}
