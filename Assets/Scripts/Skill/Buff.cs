using UnityEngine;
using System.Collections;
using System.Reflection;
using Regame;

/// <summary>
/// 状态
/// </summary>
[RequireComponent(typeof(RevisableAttributeComponent))]
public class Buff : Skill{

    /// <summary>
    /// 是否是一次性消耗品
    /// </summary>
    /// <returns>是返回ONE_TIME，否返回PERISISTENCE，不明返回UNCLEAR</returns>
    public override RevisiableTypeEnum IsOneTime()
    {
        return RevisiableTypeEnum.PERISISTENCE;
    }

    protected void Awake()
    {
        revisableAttributeComponent = GetComponent<RevisableAttributeComponent>();
    }

    protected void Start()
    {
        //base.Start();
    }

    /// <summary>
    /// buff生成时间
    /// </summary>
    private float enableTime;

    /// <summary>
    /// buff持续时间
    /// </summary>
    public float lastTime;

    /// <summary>
    /// 是否已经作用于某个角色
    /// </summary>
    private bool isActed = false;

    /// <summary>
    /// 可修改属性组件
    /// </summary>
    private RevisableAttributeComponent revisableAttributeComponent;

    /// <summary>
    /// 作用于角色
    /// </summary>
    /// <param name="character">被作用的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool ActOn(Character character)
    {
        if (revisableAttributeComponent.ActOn(character))
        {
            isActed = true;
            enableTime = Time.time;
            StartCoroutine(CancelActOnWhenTimer(character));
            return true;
        }
        return false;
    }

    /// <summary>
    /// 取消作用于角色
    /// </summary>
    /// <param name="character">取消作用于的角色</param>
    /// <returns>函数执行是否成功</returns>
    public override bool CancelActOn(Character character)
    {
        if (revisableAttributeComponent.CancelActOn(character))
        {
            isActed = false;
            if (!character.IsElementsCharacter())
            {
                return false;
            }
            ElementsCharacter elementsCharacter = (ElementsCharacter)character;
            elementsCharacter.DetachBuff(this);
        }
        return false;
    }

    /// <summary>
    /// 协程 buff持续时间结果之后撤除buff
    /// </summary>
    /// <param name="character">作用于的角色</param>
    /// <returns>协程返回</returns>
    IEnumerator CancelActOnWhenTimer(Character character)
    {
        yield return new WaitForSeconds(lastTime);
        yield return CancelActOn(character);
    }

    /// <summary>
    /// 将buff对象从拷贝到角色对象下
    /// </summary>
    /// <param name="obj">角色对象</param>
    public void CopyBuffObjectToCharacterObject(GameObject characterObj)
    {
        if (gameObject)
        {
            GameObject newBuff = ObjectPool.Instantiate(gameObject);
            newBuff.transform.SetParent(characterObj.transform);
            newBuff.GetComponentInChildren<Buff>().ActOn(characterObj.GetComponentInChildren<Character>());
        }
    }

    /// <summary>
    /// 消除buff
    /// </summary>
    public void DetachBuff()
    {
        ObjectPool.Destroy(gameObject);
    }

    //public void CopyComponetToObject(GameObject obj)
    //{
    //    Component comp = obj.AddComponent<Buff>();
    //    System.Type type = comp.GetType();
    //    BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
    //    PropertyInfo[] pinfos = type.GetProperties(flags);
    //    foreach (var pinfo in pinfos)
    //    {
    //        if (pinfo.CanWrite)
    //        {
    //            try
    //            {
    //                pinfo.SetValue(comp, pinfo.GetValue(this, null), null);
    //            }
    //            catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
    //        }
    //    }
    //    FieldInfo[] finfos = type.GetFields(flags);
    //    foreach (var finfo in finfos)
    //    {
    //        finfo.SetValue(comp, finfo.GetValue(this));
    //    }
    //}
}
