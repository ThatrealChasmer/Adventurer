using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public static class PlayerStats
{
    public static StatsTemplate.Stats playerStats = new StatsTemplate.Stats(1,1,1,1,10,1);

    public static void TakeDamage(int dmg)
    {
        playerStats.currentHealth -= dmg;
    }

    public static void ChangeStat(string stat, int amount)
    {

    }

    public static void CalculateStats()
    {
        playerStats.maxHealth = 200 + (5 * playerStats.strength);
        playerStats.currentHealth = playerStats.maxHealth;

        playerStats.maxStamina = 50 + (playerStats.defense / 10);
        playerStats.currentStamina = playerStats.maxStamina;

        playerStats.maxMana = 80 + (playerStats.inteligence / 5);
        playerStats.currentMana = playerStats.maxMana;
    }

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
