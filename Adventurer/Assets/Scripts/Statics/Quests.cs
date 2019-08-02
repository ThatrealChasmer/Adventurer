using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Quests
{
    public class Quest
    {
        public class Goal
        {
            public CustomEnums.GoalTypes goaltype;
            public int goal;
            public string target;

            public Goal (CustomEnums.GoalTypes goaltype, int goal, string target)
            {
                this.goaltype = goaltype;
                this.goal = goal;
                this.target = target;
            }

        }
        public int id;
        public string name;
        public string description;
        public int reward;
        public Goal goal;
        public CustomEnums.QuestStates questState;

        public Quest()
        {

        }

        public Quest(int id, string name, string desc, int reward, Goal goal)
        {
            this.name = name;
            this.description = desc;
            this.reward = reward;
            this.goal = goal;
        }
    }

    public static List<Quest> allQuests = new List<Quest>();

    public static List<Quest> pickableQuests = new List<Quest>();

    public static List<Quest> playerQuests = new List<Quest>();

}
