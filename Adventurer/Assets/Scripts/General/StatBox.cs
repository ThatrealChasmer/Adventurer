using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBox : MonoBehaviour
{
    public PlayerStatistics stats;

    public Text HPText;
    public Text SPText;
    public Text MPText;
    
    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP: " + stats.currentHealth + "/" + stats.maxHealth;
        SPText.text = "SP: " + stats.currentStamina + "/" + stats.maxStamina;
        MPText.text = "MP: " + stats.currentMana + "/" + stats.maxMana;
    }
}
