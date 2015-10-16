using UnityEngine;
using System.Collections;

/// <summary>
/// 为一些不需要移动的人物所设，比如玩家
/// </summary>
public class NeverMoveComponent : MoveComponent{

    /// <summary>
    /// 重载虚函数，判断是否可以移动
    /// </summary>
    /// <returns>恒为假</returns>
    public override bool CanMove()
    {
        return false;
    }
}
