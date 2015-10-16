using UnityEngine;
using System.Collections;
using Regame;

public class TestSpawnOnMouseButton : MonoBehaviour {

    public GameObject objToBeSpawned;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            ObjectPool.Instantiate(objToBeSpawned, pos, Quaternion.identity, transform);
        }
	}
}
