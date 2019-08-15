﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem2 : MonoBehaviour
{
    int index = 0;
    int shift = 0;

    public int PlayerIndex;
    public List<GameObject> enemies;

    public void StartTurn()
    {
        if (index != PlayerIndex)
        {
            if (index < PlayerIndex) shift = 0;
            else shift = -1;

            enemies[index+shift].GetComponent<EnemyAI>().Act();
        }
    }
    public void EndTurn()
    {
        if (index < enemies.Count) index++;
        else index = 0;

        StartTurn();
    }
}