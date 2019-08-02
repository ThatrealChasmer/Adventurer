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
}
