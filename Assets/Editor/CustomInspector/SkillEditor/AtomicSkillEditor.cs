using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 原子技能编辑器
/// </summary>
[CustomEditor(typeof(AtomicSkill))]
public class AtomicSkillEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AtomicSkill atomicSkill = (AtomicSkill)target;

        if (!atomicSkill.HaveBuff())
        {
            if (GUILayout.Button("增加战斗人物buff"))
            {
                atomicSkill.AddABuffForFightCharacterInHierarchy();
            }
            if (GUILayout.Button("增加玩家buff"))
            {
                atomicSkill.AddABuffForPlayerInHierarchy();
            }
        }
    }
}