using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public new string name;
    public Sprite art;
    public int id;

    public int level;

    public int strength;
    public int defense;
    public int perception;
    public int inteligence;
    public int speed;
    public int luck;
}
