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
        for (int i = questManager.questList.Count - 1; i >= 0; i--)
        {
            if (questManager.questList[i].completion)
            {
                playerData.money += questManager.questList[i].reward;
                questManager.questList.Remove(questManager.questList[i]);
            }
        }
    }
}
