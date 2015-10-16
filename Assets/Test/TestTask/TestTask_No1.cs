using UnityEngine;
using System.Collections;
using Regame;

/// <summary>
/// 测试任务1
/// </summary>
public class TestTask_No1 : Task {

    protected void Start()
    {
        TaskStart(null);
        base.Start();
    }

    public override IEnumerator CheckTask()
    {
        yield return StartCoroutine(base.CheckTask());
        print("5S之后任务自动完成");
		yield return new WaitForSeconds (5);
        TaskFinish(null);
    }
}
