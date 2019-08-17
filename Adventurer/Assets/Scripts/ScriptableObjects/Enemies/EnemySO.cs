using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemy_name;
    public Sprite art;
    public int id;

    public int level;

    public int strength;
    public int defense;
    public int perception;
    public int intelligence;
    public int speed;
    public int luck;

    public float range;

    public List<EnemyAttackSO> attacks;
}
