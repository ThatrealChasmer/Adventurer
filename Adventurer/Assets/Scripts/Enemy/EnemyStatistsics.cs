using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatistsics : MonoBehaviour
{
    public delegate void EnemyHealthCallback();
    public event EnemyHealthCallback OnEnemyHealthChanged;
    public event EnemyHealthCallback EnemyDeath;

    public GameObject sprite;
    public GameObject nameText;

    public int TurnIndex;

    public EnemySO so;

    public string enemy_name;
    public int level;

    public int strength;
    public int defense;
    public int perception;
    public int intelligence;
    public int speed;
    public int luck;

    public int max_health;
    public int max_mana;
    public int max_stamina;

    public int health;
    public int mana;
    public int stamina;

    public float range;

    private void Start()
    {
        Import();
    }

    public void Import()
    {
        strength = so.strength;
        defense = so.defense;
        perception = so.perception;
        intelligence = so.intelligence;
        speed = so.speed;
        luck = so.luck;
            
        max_health = strength;
        max_mana = intelligence;
        max_stamina = speed;

        health = max_health;
        mana = max_mana;
        stamina = max_stamina;

        level = so.level;
        enemy_name = so.enemy_name;

        sprite.GetComponent<Image>().sprite = so.art;
        nameText.GetComponent<Text>().text = so.enemy_name;
        //transform.GetChild(0).GetComponent<Healthbar>().Initiate();
    }

    public void Take_Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            if (EnemyDeath != null) EnemyDeath();
        }
       if (OnEnemyHealthChanged != null) OnEnemyHealthChanged();
        Debug.Log(health);
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > max_health) health = max_health;
        if (OnEnemyHealthChanged != null) OnEnemyHealthChanged();
    }

    public float GetHealthPercent()
    {
        return ((float)health / (float)max_health);
    }
}
