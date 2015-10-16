using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 快速创建编辑器类
/// </summary>
public class FastCreateEditor
{
    /// <summary>
    /// 快速创建角色
    /// </summary>

    [MenuItem("FastCreate/角色/玩家")]
    public static void CreatePlayer()
    {
        GameObject obj = new GameObject("玩家");
        obj.AddComponent<Player>();
    }

    [MenuItem("FastCreate/角色/魔法师")]
    public static void CreateMagician()
    {
        GameObject obj = new GameObject("魔法师");
        obj.AddComponent<Magician>();
    }

    [MenuItem("FastCreate/角色/怪物")]
    public static void CreateMonster()
    {
        GameObject obj = new GameObject("怪物");
        obj.AddComponent<Monster>();
    }

    /// <summary>
    /// 快速创建物品
    /// </summary>

    [MenuItem("FastCreate/物品/一次性消耗品/适用于玩家")]
    public static void CreateConsumablesForPlayer()
    {
        GameObject obj = new GameObject("玩家一次性消耗品");
        obj.AddComponent<ForPlayer>();
        obj.AddComponent<Consumables>();
    }

    [MenuItem("FastCreate/物品/一次性消耗品/适用于战斗人物")]
    public static void CreateConsumablesForFightCharacter()
    {
        GameObject obj = new GameObject("战斗人物一次性消耗品");
        obj.AddComponent<ForFightCharacter>();
        obj.AddComponent<Consumables>();
    }

    [MenuItem("FastCreate/物品/永久性消耗品/适用于玩家")]
    public static void CreateConsumablesForeverForForPlayer()
    {
        GameObject obj = new GameObject("(慎)玩家永久增加XX");
        obj.AddComponent<ForPlayer>();
        obj.AddComponent<ConsumablesForever>();
    }

    [MenuItem("FastCreate/物品/永久性消耗品/适用于战斗人物")]
    public static void CreateConsumablesForeverForFightCharacter()
    {
        GameObject obj = new GameObject("(慎)战斗人物永久增加XX");
        obj.AddComponent<ForFightCharacter>();
        obj.AddComponent<ConsumablesForever>();
    }

    [MenuItem("FastCreate/物品/装备/上衣")]
    public static void CreateClothes()
    {
        GameObject obj = new GameObject("上衣");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.CLOTHES);
    }

    [MenuItem("FastCreate/物品/装备/饰品")]
    public static void CreateDecoration()
    {
        GameObject obj = new GameObject("饰品");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.DECORATION);
    }

    [MenuItem("FastCreate/物品/装备/帽子")]
    public static void CreateHat()
    {
        GameObject obj = new GameObject("帽子");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.HAT);
    }

    [MenuItem("FastCreate/物品/装备/副手")]
    public static void CreateShield()
    {
        GameObject obj = new GameObject("副手");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.SHIELD);
    }

    [MenuItem("FastCreate/物品/装备/鞋子")]
    public static void CreateShoes()
    {
        GameObject obj = new GameObject("鞋子");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.SHOES);
    }

    [MenuItem("FastCreate/物品/装备/裤子")]
    public static void CreateTrousers()
    {
        GameObject obj = new GameObject("裤子");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.TROUSERS);
    }

    [MenuItem("FastCreate/物品/装备/武器")]
    public static void CreateWeapon()
    {
        GameObject obj = new GameObject("武器");
        Equipment equipment = obj.AddComponent<Equipment>();
        equipment.SetEquipmentType(ItemType.EquipmentTypeEnum.WEAPON);
    }

   /// <summary>
    /// 快速创建技能
   /// </summary>

    [MenuItem("FastCreate/技能/空技能")]
    public static void CreateEmptySkill()
    {
        GameObject obj = new GameObject("技能");
        obj.AddComponent<Skill>();
    }

    [MenuItem("FastCreate/技能/非空技能")]
    public static void CreateSkill()
    {
        GameObject obj = new GameObject("技能");
        Skill skill = obj.AddComponent<Skill>();
        skill.AddAnEmptyAtomicSkillWithBuffForFightCharacterInHierarchy();
    }

    [MenuItem("FastCreate/技能/战斗人物BUFF")]
    public static void CreateBuffForFightCharacter()
    {
        GameObject obj = new GameObject("战斗人物BUFF");
        obj.AddComponent<ForFightCharacter>();
        obj.AddComponent<Buff>();
    }

    [MenuItem("FastCreate/技能/玩家BUFF")]
    public static void CreateBuffForPlayer()
    {
        GameObject obj = new GameObject("玩家BUFF");
        obj.AddComponent<ForPlayer>();
        obj.AddComponent<Buff>();
    }
}
