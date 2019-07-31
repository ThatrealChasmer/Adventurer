using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealthSystem : MonoBehaviour
{
    public event EventHandler OnEnemyHealthChanged;
    public event EventHandler EnemyDeath;

    public int health;
    public int healthMax;

    public EnemyHealthSystem(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return ((float)health/(float)healthMax);
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            if (EnemyDeath != null) EnemyDeath(this, EventArgs.Empty);
        }
        if (OnEnemyHealthChanged != null) OnEnemyHealthChanged(this, EventArgs.Empty);
        Debug.Log(health);
    }
    public void Heal(int amount)
    {
        health += amount;
        if (health > healthMax) health = healthMax;
        if (OnEnemyHealthChanged != null) OnEnemyHealthChanged(this, EventArgs.Empty);

    }
}
