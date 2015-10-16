using UnityEngine;
using System.Collections;

/// <summary>
/// 战斗组件，直接挂载在角色身上，包含PvP和PvE场景战斗组件
/// </summary>
[RequireComponent(typeof(PvPComponent))]
[RequireComponent(typeof(PvEComponent))]
public class BattleComponent : CharacterComponent{

    void Awake()
    {
        pvPComponent = GetComponent<PvPComponent>();
        pvEComponent = GetComponent<PvEComponent>();
    }

    /// <summary>
    /// PvP战斗组件
    /// </summary>
    public PvPComponent pvPComponent;

    /// <summary>
    /// PvE战斗组件
    /// </summary>
    public PvEComponent pvEComponent;

    /// <summary>
    /// 战斗力
    /// </summary>
    public float battleForce;

    /// <summary>
    /// 战斗胜率
    /// </summary>
    public float battleWinRate;

    /// <summary>
    /// 计算战斗力
    /// </summary>
    public void CalculateBattleForce()
    {
        //TODO:根据战斗力计算公式(未定)计算战斗力
    }

    /// <summary>
    /// 计算战斗胜率
    /// </summary>
    public void CalculateBattleWinRate()
    {
        int t_battleTotalWinTimes = 0;
        int t_battleTotalTimes = 0;
        if (pvPComponent)
        {
            t_battleTotalWinTimes += pvPComponent.GetBattleWinTimes();
            t_battleTotalTimes += pvPComponent.GetBattleTotalTimes();
        }
        if (pvEComponent)
        {
            t_battleTotalWinTimes += pvEComponent.GetBattleWinTimes();
            t_battleTotalTimes += pvEComponent.GetBattleTotalTimes();
        }
        this.battleWinRate = t_battleTotalWinTimes / t_battleTotalTimes;
    }

    /// <summary>
    /// 获取战斗力
    /// </summary>
    /// <returns>战斗力</returns>
    public float GetBattleForce()
    {
        CalculateBattleForce();
        return battleForce;
    }

    /// <summary>
    /// 获取战斗胜率
    /// </summary>
    /// <returns>战斗胜率</returns>
    public float GetBattleWinRate()
    {
        CalculateBattleWinRate();
        return battleWinRate;
    }
}
