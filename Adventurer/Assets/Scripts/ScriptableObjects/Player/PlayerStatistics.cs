using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStatistics", menuName = "PlayerStatistics")]
public class PlayerStatistics : ScriptableObject
{
    public string playerName;

    public int strength;
    public int defense;
    public int perception;
    public int intelligence;
    public int speed;
    public int luck;

    public int maxHealth;
    public int currentHealth;

    public int maxStamina;
    public int currentStamina;

    public int maxMana;
    public int currentMana;

    public int[] statArray = { 0, 0, 0, 0, 0, 0 };

    public void CalculateStats()
    {
        maxHealth = 200 + (5 * strength);
        currentHealth = maxHealth;

        maxStamina = 50 + (defense / 10);
        currentStamina = maxStamina;

        maxMana = 80 + (intelligence / 5);
        currentMana = maxMana;
    }

    public void GetStats()
    {
        statArray[0] = strength;
        statArray[1] = defense;
        statArray[2] = perception;
        statArray[3] = intelligence;
        statArray[4] = speed;
        statArray[5] = luck;
    }

    public void ChangeStats(int[] amounts)
    {
        int tmpHealth = maxHealth;
        int tmpStamina = maxStamina;
        int tmpMana = maxMana;

        strength += amounts[0];
        defense += amounts[1];
        perception += amounts[2];
        intelligence += amounts[3];
        speed += amounts[4];
        luck += amounts[5];

        maxHealth = 200 + (5 * amounts[0]);
        currentHealth += maxHealth - tmpHealth;

        maxStamina = 50 + (defense / 10);
        currentHealth += maxStamina - tmpStamina;

        maxMana = 80 + (intelligence / 5);
        currentMana += maxMana - tmpMana;
    }

    public void FillStats()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMana = maxMana;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
    }

    public void RestoreStamina(int amount)
    {
        currentStamina = Mathf.Clamp(currentStamina + amount, 0, maxStamina);
    }
}
