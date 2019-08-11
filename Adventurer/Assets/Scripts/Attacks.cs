using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    GameObject enemy;
    public TurnSystem turn;
    private void Start()
    {
        turn = GameObject.FindGameObjectWithTag("Box").GetComponent<TurnSystem>();
    }
    public void TestAttack1()
    {
        //List<Gameobject> enemiesToDamage = selectenemies(1);
        //enemyToDamge.takedamage(10)
        Debug.Log("skill used");
        turn.EndTurn();
    }

    public void TestAoeAttack()
    {
        // List<Gameobject> enemiesToDamage = selectenemy(3)
        // 
        Debug.Log("skill used");
        turn.EndTurn();
    }

    public void TestAttack3()
    {
        // List<Gameobject> enemiesToDamage = selectenemy(3)
        // 
        Debug.Log("skill used");
        turn.EndTurn();
    }


}