using UnityEngine;
using System.Collections;

/// <summary>
/// 任务状态
/// </summary>
public class TaskStatus {

    /// <summary>
    /// 任务状态枚举
    /// </summary>
    public enum TaskStatusEnum : int
    {
        /// <summary>
        /// 未开始
        /// </summary>
        TASK_NOT_STARTED = 1,

        /// <summary>
        /// 进行中
        /// </summary>
        TASK_RUNNING = 2,

        /// <summary>
        /// 已完成
        /// </summary>
        TASK_FINISHED = 3,

        /// <summary>
        /// 中途放弃
        /// </summary>
        TASK_ABORTED = 4,
    }
}
