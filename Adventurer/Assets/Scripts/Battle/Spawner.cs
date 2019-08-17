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
        TurnSystemReference.PlayerIndex = enemies.Count;
        TurnSystemReference.enemies = enemies;
        TurnSystemReference.StartTurn();
        // przyznawanie indexow
    }

}
