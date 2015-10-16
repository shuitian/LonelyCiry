using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 任务数据
/// </summary>
public class TaskData : MonoBehaviour {

    /// <summary>
    /// 任务开始时间
    /// </summary>
    public DateTime startTime;

    /// <summary>
    /// 任务完成时间
    /// </summary>
    public DateTime finishTime;

    /// <summary>
    /// 任务奖励
    /// </summary>
    public TaskReward taskReward;

}
