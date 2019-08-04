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
        GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>().PlayerIndex = playerIndex;
        GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>().BattleEntitiesAmount = Enemies.Count;
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
            Debug.Log("foreach");
            int i = 0;
            do
            {
                Debug.Log("for");
                Debug.Log(members[i].name);
                if (tmp.Count != 0)
                {
                    if (member.GetComponent<EnemyStats>().speed > tmp[i].GetComponent<EnemyStats>().speed)
                    {
                        Debug.Log(member.name);
                        tmp.Insert(i, member);
                        break;
                    }
                }
                else
                {
                    Debug.Log(member.name);
                    tmp.Insert(0, member);
                }
                i++;
            } while (i < tmp.Count);
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

    void funkcja(GameObject i)
    {
        EnemyList.Add(i);
    }
}
