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
    }
}
