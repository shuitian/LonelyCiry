using UnityEngine;
using System.Collections;

/// <summary>
/// 移动组件
/// </summary>
public class MoveComponent : BaseComponent
{

    void OnEnable()
    {
        CalculateCurrentMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove())
        {
            Move();
        }
    }

    /// <summary>
    /// 是否可以移动，玩家由触摸控制，怪物和NPC由AI控制
    /// </summary>
    protected bool canMove;

    /// <summary>
    /// 移动方向，动态改变
    /// </summary>
    protected Vector3 moveDirect = new Vector3(1,0,0);

    /// <summary>
    /// 最大移动速度
    /// </summary>
    public float maxMoveSpeed
    {
        get
        {
            return DataBuildIn.maxMoveSpeed;
        }
    }

    /// <summary>
    /// 最小移动速度
    /// </summary>
    [HideInInspector]
    public float minMoveSpeed = 0;

    /// <summary>
    /// 基础移动速度
    /// </summary>
    public float baseMoveSpeed = 0;

    /// <summary>
    /// 基础移动速度增加值
    /// </summary>
    public float moveSpeedAddedValue = 0;

    /// <summary>
    /// 移动速度系数
    /// </summary>
    public float moveSpeedAddedRate = 1;

    /// <summary>
    /// 移动速度
    /// </summary>
    [HideInInspector]
    public float moveSpeed;

    /// <summary>
    /// 设置是否可以移动
    /// </summary>
    /// <param name="p_canMove">是否可以移动</param>
    public void SetCanMove(bool p_canMove)
    {
        this.canMove = p_canMove;
    }

    /// <summary>
    /// 是否可以移动，虚函数
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public virtual bool CanMove()
    {
        if (canMove)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 移动，虚函数
    /// </summary>
    public virtual void Move()
    {
        gameObject.transform.position += moveDirect.normalized * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// 获取移动方向
    /// </summary>
    /// <returns>移动方向</returns>
    public Vector3 GetMoveDirect()
    {
        return moveDirect;
    }

    /// <summary>
    /// 改变移动方向
    /// </summary>
    /// <param name="p_newMoveDirect">新的移动方向</param>
    public void ChangeMoveDirect(Vector3 p_newMoveDirect)
    {
        moveDirect = p_newMoveDirect;
    }

    /// <summary>
    /// 增加移动速度
    /// </summary>
    /// <param name="p_moveSpeedAddedValue">增加的基础移动速度增加值</param>
    /// <param name="p_moveSpeedAddedRate">增加的移动速度增加百分比</param>
    /// <returns>设置是否成功</returns>
    public bool AddMoveSpeed(float p_moveSpeedAddedValue, float p_moveSpeedAddedRate)
    {
        return SetMoveSpeed(this.moveSpeedAddedValue + p_moveSpeedAddedValue, this.moveSpeedAddedRate + p_moveSpeedAddedRate);
    }

    /// <summary>
    /// 设置移动速度
    /// </summary>
    /// <param name="p_moveSpeedAddedValue">新的基础移动速度增加值</param>
    /// <param name="p_moveSpeedAddedRate">新的移动速度增加百分比</param>
    /// <returns>设置是否成功</returns>
    public bool SetMoveSpeed(float p_moveSpeedAddedValue, float p_moveSpeedAddedRate)
    {
        this.moveSpeedAddedValue = p_moveSpeedAddedValue;
        this.moveSpeedAddedRate = p_moveSpeedAddedRate;
        CalculateCurrentMoveSpeed();
        return true;
    }

    /// <summary>
    /// 根据基础移动速度和移动速度增加值与百分比，计算移动速度
    /// </summary>
    protected void CalculateCurrentMoveSpeed()
    {
        moveSpeed = (baseMoveSpeed + moveSpeedAddedValue) * moveSpeedAddedRate;
        CheckMoveSpeed();
    }

    /// <summary>
    /// 限定移动速度在最大移动速度和最小移动速度之间
    /// </summary>
    public void CheckMoveSpeed()
    {
        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }
        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
    }

    /// <summary>
    /// 获得当前移动速度
    /// </summary>
    /// <returns>移动速度</returns>
    public float GetCurrentMoveSpeed()
    {
        CheckMoveSpeed();
        return moveSpeed;
    }

    ///// <summary>
    ///// 设置最大移动速度
    ///// </summary>
    ///// <param name="p_newMaxMoveSpeed">新的最大移动速度</param>
    //public void SetMaxMoveSpeed(float p_newMaxMoveSpeed)
    //{
    //    maxMoveSpeed = p_newMaxMoveSpeed;
    //    if (maxMoveSpeed < minMoveSpeed)
    //    {
    //        maxMoveSpeed = minMoveSpeed;
    //    }
    //    CheckMoveSpeed();
    //}

    ///// <summary>
    ///// 设置新的最小移动速度
    ///// </summary>
    ///// <param name="p_newMinMoveSpeed">新的最小移动速度</param>
    //public void SetMinMoveSpeed(float p_newMinMoveSpeed)
    //{
    //    minMoveSpeed = p_newMinMoveSpeed;
    //    if (minMoveSpeed > maxMoveSpeed)
    //    {
    //        minMoveSpeed = maxMoveSpeed;
    //    }
    //    CheckMoveSpeed();
    //}
}
