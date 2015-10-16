using UnityEngine;
using System.Collections;

/// <summary>
/// 物品
/// </summary>
[RequireComponent(typeof(RevisableAttributeComponent))]
[RequireComponent(typeof(ItemTradeAttribute))]
public class Item : MonoBehaviour ,IForRevisableComponent{

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public virtual RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.UNCLEAR;
    }

    protected void Awake()
    {
        revisableAttributeComponent = GetComponent<RevisableAttributeComponent>();
        itemTradeAttribute = GetComponent<ItemTradeAttribute>();
    }

    protected void Start()
    {
        //just for test
        this.ActOn(characterToBeActOn);
    }

    /// <summary>
    /// 作用于的角色, For Test
    /// </summary>
    public Character characterToBeActOn;

    /// <summary>
    /// 物品拥有者
    /// </summary>
    public Player owner;

    /// <summary>
    /// 可修改属性组件
    /// </summary>
    protected RevisableAttributeComponent revisableAttributeComponent;

    /// <summary>
    /// 物品附带的交易属性
    /// </summary>
    protected ItemTradeAttribute itemTradeAttribute;

    /// <summary>
    /// 物品唯一ID
    /// </summary>
    public long itemId;

    /// <summary>
    /// 物品名字
    /// </summary>
    public string name;

    /// <summary>
    /// 物品介绍
    /// </summary>
    public string introduction;

    /// <summary>
    /// 物品类型
    /// </summary>
    protected ItemType.ItemTypeEnum itemTypeEnum;

    /// <summary>
    ///  设置物品类别
    /// </summary>
    /// <param name="itemTypeEnum">物品类别</param>
    public void SetItemTypeEnum(ItemType.ItemTypeEnum itemTypeEnum)
    {
        this.itemTypeEnum = itemTypeEnum;
    }

    /// <summary>
    /// 是否是装备
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public bool IsEquipment()
    {
        return (itemTypeEnum == ItemType.ItemTypeEnum.EQUIPMENT);
    }

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public virtual bool ActOn(Character character)
    {
        if (!character)
        {
            return false;
        }
        if (IsEquipment())
        {
            ((Equipment)this).PutOnEquipment(character);
        }
        return revisableAttributeComponent.ActOn(character);
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public virtual bool CancelActOn(Character character)
    {
        if (!character)
        {
            return false;
        }
        if (IsEquipment())
        {
            ((Equipment)this).PutOffEquipment();
        }
        return revisableAttributeComponent.CancelActOn(character);
    }
}
