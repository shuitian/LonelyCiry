using UnityEngine;
using System.Collections;

/// <summary>
/// 可修改移动组件
/// </summary>
public class RevisableMoveComponent : RevisableComponent{

    /// <summary>
    /// 移动速度增加值，适用于buff，装备
    /// </summary>
    public float moveSpeedAddedValue;

    /// <summary>
    /// 移动速度增加百分比，适用于buff，装备
    /// </summary>
    public float moveSpeedAddedRate;

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(Character character)
    {
        if (!base.ActOn(character))
        {
            return false;
        }
        return this.ActOn(character.moveComponent);
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(Character character)
    {
        if (!base.CancelActOn(character))
        {
            return false;
        }
        return this.CancelActOn(character.moveComponent);
    }

    /// <summary>
    /// 作用于组件
    /// </summary>
    /// <param name="characterComponent">作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(CharacterComponent characterComponent)
    {
        if (!base.ActOn(characterComponent))
        {
            return false;
        }
        return ((MoveComponent)characterComponent).AddMoveSpeed(moveSpeedAddedValue, moveSpeedAddedRate);
    }

    /// <summary>
    /// 取消作用于组件
    /// </summary>
    /// <param name="characterComponent">取消作用于的组件</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(CharacterComponent characterComponent)
    {
        if (!base.CancelActOn(characterComponent))
        {
            return false;
        }
        return ((MoveComponent)characterComponent).AddMoveSpeed(-moveSpeedAddedValue, -moveSpeedAddedRate);
    }
}
