using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 技能编辑器
/// </summary>
[CustomEditor(typeof(Skill))]
public class SkillEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Skill skill = (Skill)target;
        EditorGUILayout.LabelField("子技能个数", skill.atomicSkillsNumber.ToString());

        if (GUILayout.Button("添加一个空子技能"))
        {
            skill.AddAnEmptyAtomicSkillInHierarchy();
        }

        if (GUILayout.Button("添加一个带玩家buff的子技能"))
        {
            skill.AddAnEmptyAtomicSkillWithBuffForPlayerInHierarchy();
        }

        if (GUILayout.Button("添加一个带战斗buff的子技能"))
        {
            skill.AddAnEmptyAtomicSkillWithBuffForFightCharacterInHierarchy();
        }

        if (GUILayout.Button("更新并检查技能格式"))
        {
            skill.CheckSkillFormat();
        }
    }
}

