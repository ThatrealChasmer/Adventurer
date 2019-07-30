using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestPlayer : MonoBehaviour
{
    public int health = 100;
    public int stamina = 100;
    public int mana = 100;
    public int str = 10;
    public int intel = 10;
    public int spd = 10;
    
    public class Skill
    {
        public string name;
        public float dmg;
        public int staminaUsage;

        public Skill(string name, float dmg, int staminaUsage)
        {
            this.name = name;
            this.dmg = dmg;
            this.staminaUsage = staminaUsage;
        }
    }

    public List<Skill> skills = new List<Skill>();

    // Start is called before the first frame update
    void Start()
    {
        skills.Add(new Skill("Attack1", 0.1f, 0));
        skills.Add(new Skill("Attack2", 0.2f, 5));
        skills.Add(new Skill("Attack3", 0.3f, 10));
        skills.Add(new Skill("Attack4", 0.4f, 15));
        skills.Add(new Skill("Attack5", 0.5f, 20));
    }
}
