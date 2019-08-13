using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int id;
    public string name;
    public int level;
    public CustomEnums.Zones zone;
    //public StatsTemplate.Stats minStats;
    //public StatsTemplate.Stats maxStats;
    public List<EnemyAttack> attacks;

    public string TurnAI()
    {
        int i = Random.Range(0, attacks.Count);
        string pick = attacks[i].name;
        return pick;
    }
    
}
