using UnityEngine;
using System.Collections;

public class TestSkillRelease : MonoBehaviour {

    public FightCharacter owner;
    public Skill skill;

    bool flag = true;
    void Update()
    {
        if (flag)
        {
            owner.ReleaseSkill(skill);
            flag = false;
            owner.GetSkillDamaged(skill.atomicSkills[0]);
        }
    }
	
}
