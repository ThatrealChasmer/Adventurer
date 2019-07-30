using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour
{
    public void SkillUse()
    {
        //find enemy
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        //call Damage(10) from EnemyHealthSystem
        enemy.GetComponent<EnemyHealthSystem>().Damage(10);
        Debug.Log("skill used");
    }
}
