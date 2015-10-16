using UnityEngine;
using System.Collections;

/// <summary>
/// 场景战斗组件
/// </summary>
public class SceneBattleComponent : CharacterComponent{
    
    /// <summary>
    /// 战斗总次数
    /// </summary>
    public int battleTotalTimes;
    //public float[] battleTotalScoreList;

    /// <summary>
    /// 战斗胜利次数
    /// </summary>
    public int battleWinTimes;
    //public float[] battleWinScoreList;

    /// <summary>
    /// 战斗失败次数
    /// </summary>
    public int battleLoseTimes;
    //public float[] battleLoseScoreList;

    /// <summary>
    /// 战斗胜率
    /// </summary>
    public float battleWinRate;

    /// <summary>
    /// 战斗力
    /// </summary>
    public float battleForce;

    /// <summary>
    /// 获取战斗总次数
    /// </summary>
    /// <returns>战斗总次数</returns>
    public int GetBattleTotalTimes()
    {
        return battleTotalTimes;
    }

    /// <summary>
    /// 获取战斗胜利次数
    /// </summary>
    /// <returns>战斗胜利次数</returns>
    public int GetBattleWinTimes()
    {
        return battleWinTimes;
    }

    /// <summary>
    /// 获取战斗失败次数
    /// </summary>
    /// <returns>战斗失败次数</returns>
    public int GetBattleLoseTimes()
    {
        return battleLoseTimes;
    }

    /// <summary>
    /// 参加一场战斗
    /// </summary>
    public void JoinInOneBattle()
    {
        //TODO:
        /**
         * I dont know whether we should do it
         * Maybe we can set a flag here 
         */
    }

    /// <summary>
    /// 结束一场战斗
    /// </summary>
    /// <param name="p_winOrLose">战斗是否胜利</param>
    /// <param name="p_score">战斗评分</param>
    public void FinishOneBattle(bool p_winOrLose, float p_score)
    {
        if (p_winOrLose)
        {
            WinOneBattle(p_score);
        }
        else
        {
            LoseOneBattle(p_score);
        }
    }

    /// <summary>
    /// 取得一场战斗的胜利
    /// </summary>
    /// <param name="p_score">战斗评分</param>
    public void WinOneBattle(float p_score)
    {
        battleWinTimes += 1;
        battleTotalTimes += 1;
        CalculateBattleWinRateAndForce();
        //TODO: 
        /**
         * do something with score
         * maybe you have a scoreList
         * maybe you just use it to calc battleforce
         */
    }

    /// <summary>
    /// 输了一场战斗
    /// </summary>
    /// <param name="p_score">战斗评分</param>
    public void LoseOneBattle(float p_score)
    {
        battleLoseTimes += 1;
        battleTotalTimes += 1;
        CalculateBattleWinRateAndForce();
        //TODO: 
        /**
         * do something with score
         * maybe you have a scoreList
         * maybe you just use it to calc battleforce
         */
    }

    /// <summary>
    /// 计算战斗胜率和战斗力
    /// </summary>
    protected void CalculateBattleWinRateAndForce()
    {
        battleWinRate = (float)battleWinTimes / battleTotalTimes;
        //TODO:计算战斗力
    }

    /// <summary>
    /// 获取战斗胜率
    /// </summary>
    /// <returns>战斗胜率</returns>
    public float GetBattleWinRate()
    {
        CalculateBattleWinRateAndForce();
        return battleWinRate;
    }

    /// <summary>
    /// 获取战斗力
    /// </summary>
    /// <returns>战斗力</returns>
    public float GetBattleForce()
    {
        CalculateBattleWinRateAndForce();
        return battleForce;
    }

    /// <summary>
    /// 设置战斗胜率，一般在初始化时，从网络获取数据
    /// </summary>
    /// <param name="p_winRate">新的战斗胜率</param>
    public void SetBattleWinRate(float p_winRate)
    {
        this.battleWinRate = p_winRate;
    }

    /// <summary>
    /// 设置战斗力，一般在初始化时，从网络获取数据
    /// </summary>
    /// <param name="p_force">新的战斗力</param>
    public void SetBattleForce(float p_force)
    {
        this.battleForce = p_force;
    }
}
