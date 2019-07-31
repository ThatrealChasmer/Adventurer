using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    GameObject enemy;
    public TurnSystem turn;
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        turn = GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>();
    }
    public void TestAttack1()
    {
        enemy.GetComponent<EnemyHealthSystem>().Damage(10);
        Debug.Log("skill used");
        turn.EndPlayerTurn();
    }

    public void TestAttack2()
    {
        enemy.GetComponent<EnemyHealthSystem>().Damage(15);
        Debug.Log("skill used");
        turn.EndPlayerTurn();
    }

    
}