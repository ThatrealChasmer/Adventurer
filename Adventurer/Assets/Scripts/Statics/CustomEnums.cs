using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomEnums
{
    public enum TestMenuOptions
    {
        QuestHall,
        Battle,
        ItemCrafting,
        SpellCrafting,
        PlayerCreation
    }

    public enum GoalTypes
    {
        Kill,
        Collect
    }

    public enum QuestStates
    {
        ToPick,
        Active,
        Completed
    }

    public enum Zones
    {
        Forest
    }

    public enum AttackTypes
    {
        Damage,
        Heal,
        Utility
    }
}
