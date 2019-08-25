using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<GameObject> enemies;
    public List<QuestSO> questList;

    public void Subscribe()
    {
        enemies = GameObject.Find("Spawner").GetComponent<Spawner>().enemies;
        for (int i = 0; i < enemies.Count; i++)
        {
            if(!enemies[i].name.Equals("Player")) enemies[i].GetComponent<EnemyStatistsics>().EnemyDeath += Check;
        }
    }
    void Check(string name)
    {
        for(int i = 0; i< questList.Count; i++)
        {
            questList[i].Check(name);
        }
    }
}
