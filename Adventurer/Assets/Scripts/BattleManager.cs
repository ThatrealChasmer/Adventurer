using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> EnemyList;

    public List<GameObject> Enemies = new List<GameObject>();

    public int playerIndex;

    // Start is called before the first frame update
    void Awake()
    {
        sortList(EnemyList);
        InstantiateEnemies(EnemyList);

        int shift = 0;
        for (int i = 0; i < Enemies.Count; i++)
        {
            
            if (PlayerStats.playerStats.speed > Enemies[i].GetComponent<EnemyStats>().speed)
            {
                playerIndex = i;
                shift++;
            }
            
            Enemies[i].GetComponent<EnemyStats>().TurnIndex = i + shift;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sortList(List<GameObject> members)
    {
        List<GameObject> tmp = new List<GameObject>();

        foreach(GameObject member in members)
        {
            for(int i = 0; i <= tmp.Count; i++)
            {
                if(tmp.Count != 0)
                {
                    if (member.GetComponent<EnemyStats>().speed > tmp[i].GetComponent<EnemyStats>().speed)
                    {
                        tmp.Insert(i, member);
                        break;
                    }
                }
                else
                {
                    tmp.Insert(0, member);
                }
            }
        }
        EnemyList = tmp;
    }

    void InstantiateEnemies(List<GameObject> enemies)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            GameObject enemy = Instantiate(enemies[i], new Vector3((gameObject.transform.localPosition.x - (((enemies.Count - 1)/2) * 2)) + i * 2, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), Quaternion.identity);
            Enemies.Add(enemy);
        }
    }
}
