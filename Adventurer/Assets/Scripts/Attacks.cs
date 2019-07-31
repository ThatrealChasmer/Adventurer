using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    GameObject enemy;
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void TestAttack1()
    {
        enemy.GetComponent<EnemyHealthSystem>().Damage(10);
        Debug.Log("skill used");
    }

    public void TestAttack2()
    {
        enemy.GetComponent<EnemyHealthSystem>().Damage(15);
        Debug.Log("skill used");
    }
}