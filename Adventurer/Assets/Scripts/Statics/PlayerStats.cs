using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static StatsTemplate.Stats playerStats = new StatsTemplate.Stats();

    public static void CreateReset()
    {
        playerStats.strength = 1;
        playerStats.defense = 1;
        playerStats.perception = 1;
        playerStats.inteligence = 1;
        playerStats.speed = 1;
        playerStats.luck = 1;
    }

}
