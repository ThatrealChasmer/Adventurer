using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy attack", menuName = "Enemy Attack")]
public class EnemyAttackSO : ScriptableObject
{
    public string attackName;
    public string targetType;
    public int targets;
    public int damage;
    public int staminaUsage;
}
