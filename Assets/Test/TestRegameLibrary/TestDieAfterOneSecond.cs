using UnityEngine;
using System.Collections;
using Regame;

public class TestDieAfterOneSecond : MonoBehaviour {

    public GameObject objTobeDestroy;

    void Awake()
    {
        objTobeDestroy = gameObject;
    }

    void OnEnable()
    {
        StartCoroutine(DieAfterOneSecond());
    }

    IEnumerator DieAfterOneSecond()
    {
        yield return new WaitForSeconds(1);
        ObjectPool.Destroy(objTobeDestroy);
    }
	
}
