using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int TurnIndex;
    TurnSystem TurnSystemReference;
    public BattleManagerConnector connector;
    public BattleManager bm;
    public EnemySO so;

    private void Awake()
    {
        TurnSystemReference = GameObject.Find("BattleManager").GetComponent<TurnSystem>();
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }
    public void Act()
    {
        int pick = (int)Random.Range(0, so.attacks.Count - 0.01f);
        connector.enemyAttack = so.attacks[pick];
        connector.targetType = so.attacks[pick].targetType;
        if(so.attacks[pick].targetType == "Player")
        {
            GameObject toAttack = GameObject.Find("Player");
            bm.targets.Add(toAttack);
        }
        else if(so.attacks[pick].targetType == "EnemySelf")
        {
            bm.targets.Add(gameObject);
        }
        else if(so.attacks[pick].targetType == "EnemyAlly")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            List<GameObject> lenemies = new List<GameObject>();
            foreach(GameObject enemy in enemies)
            {
                lenemies.Add(enemy);
            }
            for(int i = 0; i < so.attacks[pick].targets; i++)
            {
                int toTarget;
                toTarget = (int)Random.Range(0, lenemies.Count - 0.01f);
                bm.targets.Add(lenemies[toTarget]);
                lenemies.RemoveAt(toTarget);
            }
        }
        Debug.Log("Attack by " + TurnIndex + "Attack name: " + so.attacks[pick].attackName);
        GameObject.Find("BattleManager").GetComponent<BattleManager>().ConfirmAttack();
    }
}
