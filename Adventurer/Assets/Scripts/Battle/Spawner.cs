using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<EnemySO> enemies;
    public GameObject enemyConstructor;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject tmp;
        for (int i = 0; i< enemies.Count; i++)
        {
            tmp = Instantiate(enemyConstructor, new Vector3(i, 0, 0), Quaternion.identity);
            tmp.GetComponent<EnemyStatistsics>().so = enemies[i];
        }
    }

}
