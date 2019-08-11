using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons
{
    StatsTemplate.Stats stats = new StatsTemplate.Stats(0, 0, 0, 0, 0, 0);

    public void ChangeStat(bool increment, string stat)
    {
        int amount = 1;
        if(!increment)
        {
            amount = -amount;
        }

        switch(stat)
        {
            case "strength":
                stats.strength += amount;
                break;
            case "defense":
                stats.defense += amount;
                break;
            case "perception":
                stats.perception += amount;
                break;
            case "intelligence":
                stats.inteligence += amount;
                break;
            case "speed":
                stats.speed += amount;
                break;
            case "luck":
                stats.luck += amount;
                break;
        }
    }

    public void Confirm()
    {
        PlayerStats.
    }
}
