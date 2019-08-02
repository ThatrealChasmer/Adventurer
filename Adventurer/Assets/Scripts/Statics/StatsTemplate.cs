using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsTemplate
{
    public class Stats
    {
        public int lvl;

        public int maxHealth;
        public int currentHealth;

        public int maxStamina;
        public int currentStamina;

        public int maxMana;
        public int currentMana;

        public int strength;
        public int defense;
        public int perception;
        public int inteligence;
        public int speed;
        public int luck;

        public Stats(int str, int def, int per, int intel, int spd, int luck)
        {
            this.strength = str;
            this.defense = def;
            this.perception = per;
            this.inteligence = intel;
            this.speed = spd;
            this.luck = luck;
        }
    }
}
