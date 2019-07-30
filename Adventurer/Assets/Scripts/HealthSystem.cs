using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    public event EventHandler Death;

    private int health;
    private int healthMax;

    public HealthSystem(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            if (Death != null) Death(this, EventArgs.Empty);
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
    public void Heal(int amount)
    {
        health += amount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);

    }
}
