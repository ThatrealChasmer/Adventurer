using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffects : ScriptableObject
{
    public List<SkillSO> allSkills = new List<SkillSO>();

    public void Focus(GameObject target)
    {
        target.GetComponent<Player>().stats.RestoreStamina(30);
    }

    public void Steal(GameObject target)
    {

    }
}
