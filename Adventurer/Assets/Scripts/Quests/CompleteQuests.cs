using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuests : MonoBehaviour
{
    public PlayerData playerData;
    public void Complete()
    {
        GameObject player = GameObject.Find("Player");
        QuestManager questManager = player.GetComponent<QuestManager>();
        for (int i = questManager.PlayerData.quests.Count - 1; i >= 0; i--)
        {
            if (questManager.PlayerData.quests[i].completion)
            {
                playerData.money += questManager.PlayerData.quests[i].reward;
                questManager.PlayerData.quests.Remove(questManager.PlayerData.quests[i]);
            }
        }
    }
}
