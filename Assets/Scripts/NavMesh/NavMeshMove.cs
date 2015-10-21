using UnityEngine;
using System.Collections;

public class NavMeshMove : MonoBehaviour {

    public Transform[] NavMeshTransforms;
    private NavMeshAgent nma;//Robot的导航网格代理
    int i = 0;

    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (nma.remainingDistance < 1 && NavMeshTransforms.Length > 0)
        {
            //当导航网格代理到达了目的地时，更换目的地，且是随机的更换
            i = (i + 1) % NavMeshTransforms.Length;
            nma.SetDestination(NavMeshTransforms[i].position);
        }
    }
}
