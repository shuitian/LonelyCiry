using UnityEngine;
using System.Collections;
using System.Reflection;

public class Pass : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public A a;
	// Use this for initialization
	void Start () {
        Component comp = A.AddComponent<A>();
        System.Type type = comp.GetType();
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        PropertyInfo[] pinfos = type.GetProperties(flags);
        foreach (var pinfo in pinfos)
        {
            if (pinfo.CanWrite)
            {
                try
                {
                    pinfo.SetValue(comp, pinfo.GetValue(a, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] finfos = type.GetFields(flags);
        foreach (var finfo in finfos)
        {
            finfo.SetValue(comp, finfo.GetValue(a));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
