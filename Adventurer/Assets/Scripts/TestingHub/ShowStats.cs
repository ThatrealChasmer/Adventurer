using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Strength: " + PlayerStats.playerStats.strength);
        Debug.Log("Defense: " + PlayerStats.playerStats.defense);
        Debug.Log("Perception: " + PlayerStats.playerStats.perception);
        Debug.Log("Inteligence: " + PlayerStats.playerStats.inteligence);
        Debug.Log("Speed: " + PlayerStats.playerStats.speed);
        Debug.Log("Luck: " + PlayerStats.playerStats.luck);
        Debug.Log("Max mana: " + PlayerStats.playerStats.maxMana);
        Debug.Log("Current mana: " + PlayerStats.playerStats.currentMana);
        Debug.Log("Max hp: " + PlayerStats.playerStats.maxHealth);
        Debug.Log("current hp: " + PlayerStats.playerStats.currentHealth);
        Debug.Log("Max stamina: " + PlayerStats.playerStats.maxStamina);
        Debug.Log("current stamina: " + PlayerStats.playerStats.currentStamina);
    }
}
