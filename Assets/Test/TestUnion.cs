using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class TestUnion : MonoBehaviour {

    [StructLayout(LayoutKind.Explicit)]
    public struct A
    {
        [FieldOffset(0)]
        public int a;
        [FieldOffset(4)]
        public char b;
        [FieldOffset(4)]
        public char c;
        [FieldOffset(4)]
        public int e;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Damage
    {
        [FieldOffset(0)]
        public float damageLastTime;
        [FieldOffset(4)]
        public float damagePerSecond;
        [FieldOffset(0)]
        public double totalDamage;
    }

    A d;
	// Use this for initialization
	void Start () {
        
        print(Marshal.SizeOf(d));
        d.b = '1';
        d.c = '2';
        print(d.b);
        print(sizeof(float));
        Damage damage;
        damage.damageLastTime = 1F;
        print(damage.damageLastTime);
        damage.totalDamage = (double)(float)(-1F);
        print(damage.damageLastTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
