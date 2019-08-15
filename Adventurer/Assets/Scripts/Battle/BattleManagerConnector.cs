using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleManagerConnector", menuName = "Battle Manager Connector")]
public class BattleManagerConnector : ScriptableObject
{
    public SkillSO skill;
    public EnemyAttackSO enemyAttack;
}
