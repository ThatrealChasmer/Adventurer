using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<EnemySO> enemiesSO;
    public List<GameObject> enemies;
    public GameObject enemyConstructor;

    public GameObject canvas;

    public TurnSystem TurnSystemReference;

    private void Start()
    {
        SortList(enemiesSO);
        Spawn();
    }

    private void Spawn()
    {
        int i;
        for (i = 0;  i < enemiesSO.Count; i++)
        {
            enemies.Add(Instantiate(enemyConstructor, canvas.transform.position + new Vector3(125 + (i * 250) - ((enemiesSO.Count/2) * 250), 50, 0), Quaternion.identity, canvas.transform));
            enemies[i].GetComponent<EnemyStatistsics>().so = enemiesSO[i];
            enemies[i].name = enemiesSO[i].name;
            enemies[i].GetComponent<EnemyAI>().so = enemiesSO[i];
            enemies[i].GetComponent<EnemyAI>().TurnIndex = i;
            enemies[i].GetComponent<EnemyBattleController>().SetButton();

        }
        InsertPlayerToList();
        TurnSystemReference.enemies = enemies;
        GameObject.Find("Player").GetComponent<QuestManager>().Subscribe();
        //TurnSystemReference.StartTurn();
        // przyznawanie indexow
    }

    private void SortList(List<EnemySO> list)
    {
        EnemySO tmp;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j+1 < list.Count; j++)
            {
                if (list[j].speed < list[j + 1].speed)
                {
                    tmp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = tmp;
                }
            }
        }
    }

    private int InsertPlayerToList()
    {
        int speed = GameObject.Find("Player").GetComponent<Player>().stats.speed;
        bool inserted = false;
        int i;
        for (i = 0; i < enemies.Count; i++)
        {
            if (speed > enemies[i].GetComponent<EnemyStatistsics>().so.speed)
            {
                enemies.Insert(i, GameObject.Find("Player"));
                inserted = true;
                break;
            }
        }
        if (!inserted)
        {
            enemies.Add(GameObject.Find("Player"));
            return i + 1;
        }
        return i;
    }
}
