﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int TurnIndex;
    public int strength;
    public int defense;
    public int perception;
    public int inteligence;
    public int speed;
    public int luck;

    public StatsTemplate.Stats stats;

    private void Start()
    {
        stats = new StatsTemplate.Stats(strength, defense, perception, inteligence, speed, luck);
    }

}
