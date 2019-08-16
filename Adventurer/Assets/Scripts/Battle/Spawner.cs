using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<EnemySO> enemiesSO;
    public List<GameObject> enemies;
    public GameObject enemyConstructor;

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
            enemies.Add(Instantiate(enemyConstructor, new Vector3(i, 0, 0), Quaternion.identity));
            enemies[i].GetComponent<EnemyStatistsics>().so = enemiesSO[i];
            enemies[i].GetComponent<EnemyAI>().TurnIndex = i;

        }
        TurnSystemReference.PlayerIndex = enemies.Count;
        TurnSystemReference.enemies = enemies;
        TurnSystemReference.StartTurn();
        // przyznawanie indexow
    }

}
