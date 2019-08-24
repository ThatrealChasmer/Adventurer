using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public string weapon;
    public Sprite icon;
    public string targetType;
    public int targets;
    public int damage;
    public int staminaUsage;

    public int[] statChange = { 0, 0, 0, 0, 0, 0 };
}
