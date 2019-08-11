using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();

    public List<GameObject> Enemies = new List<GameObject>();

    public GameObject prefab;
    public int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        funkcja(prefab);
        funkcja(prefab);
        funkcja(prefab);


        sortList(EnemyList);
        InstantiateEnemies(EnemyList);

        /*int shift = 0;
        playerIndex = 0;
        for (int i = 0; i < Enemies.Count; i++)
        {
            
            if (PlayerStats.playerStats.speed < Enemies[i].GetComponent<EnemyStats>().speed)
            {
                playerIndex = i;
                Debug.Log("Player index =" + i);
                shift = 1;
            }
            
            Enemies[i].GetComponent<EnemyStats>().TurnIndex = i + shift;
        }*/
        playerIndex = Enemies.Count;
        int shift = 0;
        for (int i = Enemies.Count-1; i >= 0; i--)
        {
            if (PlayerStats.playerStats.speed > Enemies[i].GetComponent<EnemyStats>().speed)
            {
                playerIndex--;
                shift = 1;
            }
            Enemies[i].GetComponent<EnemyStats>().TurnIndex = i + shift;
        }

        GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>().PlayerIndex = playerIndex;
        GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>().BattleEntitiesAmount = Enemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void sortList(List<GameObject> members)
    {
        List<GameObject> tmp = new List<GameObject>();

        foreach(GameObject member in members)
        {
            Debug.Log("foreach");
            if(tmp.Count == 0)
            {
                tmp.Add(member);
            }
            else
            {
                for(int i = 0; i < tmp.Count; i++)
                {
                    if(member.GetComponent<EnemyStats>().speed > tmp[i].GetComponent<EnemyStats>().speed)
                    {
                        tmp.Insert(i, member);
                        break;
                    }
                    tmp.Add(member);
                }
            }
        }
        EnemyList = tmp;
    }*/

    void sortList(List<GameObject> toSort)
    {
        GameObject tmp;
        for (int i = 0; i < toSort.Count; i++)
        {
            for (int j = 1; j < toSort.Count - 1; j++)
            {
                if (toSort[j - 1].GetComponent<EnemyStats>().speed < toSort[j].GetComponent<EnemyStats>().speed)
                {
                    tmp = toSort[j - 1];
                    toSort[j - 1] = toSort[j];
                    toSort[j] = tmp;
                }
            }
        }
        EnemyList = toSort;
    }

    void InstantiateEnemies(List<GameObject> enemies)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            GameObject enemy = Instantiate(enemies[i], new Vector3((gameObject.transform.localPosition.x - (((enemies.Count - 1)/2) * 2)) + i * 2, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), Quaternion.identity);
            Enemies.Add(enemy);
        }
    }

    void funkcja(GameObject i)
    {
        EnemyList.Add(i);
    }
}
