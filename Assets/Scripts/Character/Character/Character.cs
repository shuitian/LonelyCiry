using UnityEngine;
using System.Collections;
using System.Threading;

/// <summary>
/// 人物
/// </summary>
[RequireComponent(typeof(MoveComponent))]
public class Character : MonoBehaviour {

    /// <summary>
    /// 是否是元素世界人物
    /// </summary>
    protected bool isElementsCharacter;
    /// <summary>
    /// 是否已经死亡
    /// </summary>
    //[SerializeField]
    protected bool isDead;
    /// <summary>
    /// 人物介绍
    /// </summary>
    public string introduction;
    /// <summary>
    /// 人物所挂载的移动组件
    /// </summary>
    [HideInInspector]
    public MoveComponent moveComponent;

    protected void Awake()
    {
        isElementsCharacter = false;
        moveComponent = GetComponent<MoveComponent>();
    }

	// Use this for initialization
    protected void Start()
    {

	}

    protected void OnEnable()
    {
        Birth();
    }

    protected void OnDestroy()
    {
        Die(this);
    }

	// Update is called once per frame
    protected void Update()
    {
	
	}

    /// <summary>
    /// 出生，虚函数
    /// </summary>
    public virtual void Birth()
    {
        isDead = false;
    }

    /// <summary>
    /// 重生，虚函数
    /// </summary>
    public virtual void Rebirth()
    {
        isDead = false;
    }

    /// <summary>
    /// 杀死一个人物，虚函数
    /// </summary>
    /// <param name="p_dead">被害者</param>
    public virtual void Kill(Character p_dead)
    {
        
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <param name="p_killer">杀手</param>
    /// <returns>死亡成功返回真，否则返回假</returns>
    public virtual bool Die(Character p_killer)
    {
        if (p_killer == null || isDead) 
        {
            return false;
        }
        //dieMutex.WaitOne();
        if (isDead == false)
        {
            isDead = true;
            p_killer.Kill(this);
        }
        //dieMutex.ReleaseMutex();
        return isDead;
    }

    /// <summary>
    /// 是否是元素世界人物
    /// </summary>
    /// <returns>是返回真，反之返回假</returns>
    public bool IsElementsCharacter()
    {
        return isElementsCharacter;
    }
}
