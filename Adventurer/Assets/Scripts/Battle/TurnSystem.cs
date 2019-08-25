using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    public int index = 0;

    public int PlayerIndex;
    public List<GameObject> enemies;
    public GameObject mainMenu;
    public BattleManager bm;
    public bool FirstTurn = true;

    public void StartTurn()
    {
        if (!enemies[index].name.Equals("Player")) enemies[index].GetComponent<EnemyAI>().Act();

    }
    public void EndTurn()
    {
        FirstTurn = false;
        if (index+1 < enemies.Count) index++;
        else index = 0;

        if(enemies.Count <= 1)
        {
            bm.EndBattle(true);
        }
        else
        {
            StartTurn();
        }
        
        
    }

    public void RemoveFromEnemies(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
