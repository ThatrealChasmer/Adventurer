using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemySO so;

    public int level;
    public int TurnIndex;

    public int maxHealth;
    public int Health;
    public int maxStamina;
    public int currentStamina;
    public int maxMana;
    public int currentMana;

    private void Start()
    {
    }

    void Import(EnemySO so)
    {
        this.so = so;
    }
}
