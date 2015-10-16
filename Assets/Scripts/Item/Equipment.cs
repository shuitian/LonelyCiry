using UnityEngine;
using System.Collections;
using Regame;

/// <summary>
/// 装备
/// </summary>
[RequireComponent(typeof(ForFightCharacter))]
public class Equipment : Item {

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public override RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.PERISISTENCE;
    }

    protected void Awake()
    {
        base.Awake();
        itemTypeEnum = ItemType.ItemTypeEnum.EQUIPMENT;
    }

    /// <summary>
    /// 装备类型
    /// </summary>
    public ItemType.EquipmentTypeEnum equipmentTypeEnum;

    /// <summary>
    /// 设置装备类型
    /// </summary>
    /// <param name="equipmentTypeEnum">装备类型</param>
    public void SetEquipmentType(ItemType.EquipmentTypeEnum equipmentTypeEnum)
    {
        this.equipmentTypeEnum = equipmentTypeEnum;
    }

    /// <summary>
    /// 获取装备类型
    /// </summary>
    /// <returns></returns>
    public ItemType.EquipmentTypeEnum GetEquipmentType()
    {
        return this.equipmentTypeEnum;
    }

    /// <summary>
    /// 根据装备object穿上装备
    /// </summary>
    /// <param name="obj">角色对象</param>
    public virtual void PutOnEquipment(Character character)
    {
        if (gameObject && character) 
        {
            if (!character.IsElementsCharacter())
            {
                return ;
            }
            ElementsCharacter elementsCharacter = (ElementsCharacter)character;
            if (!elementsCharacter.IsFightCharacter())
            {
                return ;
            }
            FightCharacter fightCharacter = (FightCharacter)elementsCharacter;
            if (fightCharacter.equipmentList.ContainsKey(equipmentTypeEnum))
            {
                fightCharacter.equipmentList[equipmentTypeEnum].PutOffEquipment();
            }
            try
            {
                fightCharacter.equipmentList.Add(equipmentTypeEnum, this);
            }
            catch (System.ArgumentException)
            {
                fightCharacter.equipmentList[equipmentTypeEnum].PutOffEquipment();
                fightCharacter.equipmentList[equipmentTypeEnum] = this;
            }
            finally
            {
                transform.SetParent(character.transform);
            }

        }
    }

    /// <summary>
    /// 脱下装备
    /// </summary>
    public virtual void PutOffEquipment()
    {
        if (gameObject)
        {
            ObjectPool.Destroy(gameObject);
        }
    }
}
