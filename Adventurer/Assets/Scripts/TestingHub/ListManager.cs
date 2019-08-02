using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager: MonoBehaviour
{
    void Start()
    {
        LoadQuests();
        /*for(int i = 0; i < Quests.allquests.Count; i++)
        {
            Debug.Log(Quests.allquests[i].id + " " + Quests.allquests[i].name + " " + Quests.allquests[i].description + " " + Quests.allquests[i].reward + " " + Quests.allquests[i].goal.goaltype.ToString() + " " + Quests.allquests[i].goal.goal + " " + Quests.allquests[i].goal.target + " " + Quests.allquests[i].state.ToString());
        }*/
    }

    void LoadQuests()
    {
        TextAsset quests = Resources.Load<TextAsset>("Lists/Quests");

        string[] data = quests.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            Quests.Quest quest = new Quests.Quest();

            int.TryParse(row[0], out quest.id);
            quest.name = row[1];
            quest.description = row[2];
            int.TryParse(row[3], out quest.reward);
            int goalNum;
            int.TryParse(row[5], out goalNum);
            quest.goal = new Quests.Quest.Goal((CustomEnums.GoalTypes)System.Enum.Parse(typeof(CustomEnums.GoalTypes), row[4]), goalNum, row[6]);
            quest.questState = CustomEnums.QuestStates.ToPick;

            Quests.allQuests.Add(quest);
        }
    }
}
