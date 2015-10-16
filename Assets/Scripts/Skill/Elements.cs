using UnityEngine;
using System.Collections;

/// <summary>
/// 元素类
/// </summary>
public class Elements : MonoBehaviour {

    /// <summary>
    /// 静态成员，元素个数
    /// </summary>
    public const int ELEMENT_NUMBER = 5;

    /// <summary>
    /// 元素
    /// </summary>
    public enum Element : int
    {
        /// <summary>
        /// 金元素
        /// </summary>
        METAL = 0,
        /// <summary>
        /// 木元素
        /// </summary>
        WOOD,
        /// <summary>
        /// 水元素
        /// </summary>
        WATER,
        /// <summary>
        /// 火元素
        /// </summary>
        FIRE,
        /// <summary>
        /// 土元素
        /// </summary>
        EARTH,
    }
}
