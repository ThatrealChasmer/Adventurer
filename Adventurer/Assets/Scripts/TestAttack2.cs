using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack2 : MonoBehaviour
{
    public void SkillUse()
    {
        //find enemy
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        //call Damage(10) from EnemyHealthSystem
        enemy.GetComponent<EnemyHealthSystem>().Damage(15);
        Debug.Log("skill used");
    }
}
