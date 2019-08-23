using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleQuest : MonoBehaviour
{
    bool completion = false;
    int amount = 0;
    private List<GameObject> enemies;

    void Subscribe()
    {
        enemies = GameObject.Find("Spawner").GetComponent<Spawner>().enemies;
        for (int i = 0; i< enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyStatistsics>().EnemyDeath += Check;
        }
    }

    void Check(string name)
    {
        if (!completion && name.Equals("Doggo"))
        {
            amount++;
            if (amount >= 5)
            {
                completion = true;
            }
        }
    }
}
