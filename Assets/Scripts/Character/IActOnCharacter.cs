using UnityEngine;
using System.Collections;

/// <summary>
/// 可以作用于角色的接口
/// </summary>
public interface IActOnCharacter  {

    bool ActOn(Character character);
    bool CancelActOn(Character character);
}
