using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour
{
    GameObject enemy;
    public void SkillUse()
    {
        //find enemy
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //call Damage(10) from EnemyHealthSystem
        enemy.GetComponent<EnemyHealthSystem>().Damage(10);
        Debug.Log("skill used");
    }
    void Start()
    {
        SkillUse();
    }
}
