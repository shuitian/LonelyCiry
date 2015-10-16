using UnityEngine;
using System.Collections;
using Regame;

/// <summary>
/// 任务
/// </summary>
[RequireComponent(typeof(TaskData))]
public class Task : MonoBehaviour {

    //任务系统需要事件库的支持；特别是触发任务、(半)完成任务阶段；

    /// <summary>
    /// 人物状态
    /// </summary>
    public TaskStatus.TaskStatusEnum taskStatusEnum;

    /// <summary>
    /// 任务唯一ID
    /// </summary>
    public long taskId;

    /// <summary>
    /// 人物数据
    /// </summary>
    public TaskData taskData;

    protected void Awake()
    {
        taskData = GetComponent<TaskData>();
        taskStatusEnum = TaskStatus.TaskStatusEnum.TASK_NOT_STARTED;
        RegeditTaskMessage(TaskStatus.TaskStatusEnum.TASK_RUNNING, TaskStarted);
        RegeditTaskMessage(TaskStatus.TaskStatusEnum.TASK_FINISHED, TaskFinished);
    }

    protected void Destroy()
    {
        UnregeditTaskMessage(TaskStatus.TaskStatusEnum.TASK_RUNNING, TaskStarted);
        UnregeditTaskMessage(TaskStatus.TaskStatusEnum.TASK_FINISHED, TaskFinished);
    }

    protected void Start()
    {
        StartCoroutine(CheckTask());
    }

    /// <summary>
    /// 虚协程，任务详细过程
    /// </summary>
    /// <returns>协程返回</returns>
    public virtual IEnumerator CheckTask()
    {
        while (taskStatusEnum != TaskStatus.TaskStatusEnum.TASK_RUNNING)
        {
            yield return 0;
        }
        yield return 0;
    }

    /// <summary>
    /// 任务开始回调函数
    /// </summary>
    /// <typeparam name="TYPE">传参类型</typeparam>
    /// <param name="messageName">消息名</param>
    /// <param name="sender">消息发送者</param>
    /// <param name="taskData">消息数据</param>
    public virtual void TaskStarted<TYPE>(string messageName, object sender, TYPE taskData)
    {
        //print(typeof(TYPE));
        print(messageName);
        taskStatusEnum = TaskStatus.TaskStatusEnum.TASK_RUNNING;
    }

    /// <summary>
    /// 任务结束回调函数
    /// </summary>
    /// <typeparam name="TYPE">传参类型</typeparam>
    /// <param name="messageName">消息名</param>
    /// <param name="sender">消息发送者</param>
    /// <param name="taskData">消息数据</param>
    public virtual void TaskFinished<TYPE>(string messageName, object sender, TYPE taskData)
    {
        //print(typeof(TYPE));
        print(messageName);
        taskStatusEnum = TaskStatus.TaskStatusEnum.TASK_FINISHED;
    }

    /// <summary>
    /// 注册任务消息
    /// </summary>
    /// <param name="taskStatusEnum">消息状态</param>
    /// <param name="function">消息回调函数</param>
    public virtual void RegeditTaskMessage(TaskStatus.TaskStatusEnum taskStatusEnum, MessageHandle<TaskData> function)
    {
        Message.RegeditMessageHandle<TaskData>(taskStatusEnum.ToString() + "_ID_" + taskId.ToString(), function);
    }

    /// <summary>
    /// 取消注册任务消息
    /// </summary>
    /// <param name="taskStatusEnum">消息状态</param>
    /// <param name="function">消息回调函数</param>
    public virtual void UnregeditTaskMessage(TaskStatus.TaskStatusEnum taskStatusEnum, MessageHandle<TaskData> function)
    {
        Message.UnregeditMessageHandle<TaskData>(taskStatusEnum.ToString() + "_ID_" + taskId.ToString(), function);
    }

    /// <summary>
    /// 产生一个任务消息
    /// </summary>
    /// <param name="sender">消息发送者</param>
    /// <param name="taskData">消息数据</param>
    public virtual void RaiseTaskMessage(object sender, TaskData taskData)
    {
        Message.RaiseOneMessage<TaskData>(this.taskStatusEnum.ToString() + "_ID_" + taskId.ToString(), sender, taskData);
    }

    /// <summary>
    /// 产生一个任务消息
    /// </summary>
    /// <param name="taskStatusEnum">消息状态</param>
    /// <param name="sender">消息发送者</param>
    /// <param name="taskData">消息数据</param>
    public virtual void RaiseTaskMessage(TaskStatus.TaskStatusEnum taskStatusEnum, object sender, TaskData taskData)
    {
        Message.RaiseOneMessage<TaskData>(taskStatusEnum.ToString() + "_ID_" + taskId.ToString(), sender, taskData);
    }

    /// <summary>
    /// 开始任务
    /// </summary>
    /// <param name="taskData">任务数据</param>
    public void TaskStart(TaskData taskData)
    {
        ///FIXME Start Time 应该为服务器时间
        RaiseTaskMessage(TaskStatus.TaskStatusEnum.TASK_RUNNING, this, taskData);
    }

    /// <summary>
    /// 开始任务
    /// </summary>
    public void TaskStart()
    {
        ///FIXME Start Time 应该为服务器时间
        RaiseTaskMessage(TaskStatus.TaskStatusEnum.TASK_RUNNING, this, this.taskData);
    }

    /// <summary>
    /// 完成任务
    /// </summary>
    /// <param name="taskData"></param>
    public void TaskFinish(TaskData taskData)
    {
        RaiseTaskMessage(TaskStatus.TaskStatusEnum.TASK_FINISHED, this, taskData);
    }

    /// <summary>
    /// 完成任务
    /// </summary>
    public void TaskFinish()
    {
        RaiseTaskMessage(TaskStatus.TaskStatusEnum.TASK_FINISHED, this, this.taskData);
    }
}
