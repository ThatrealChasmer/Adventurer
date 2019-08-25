using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptQuest : MonoBehaviour
{
    public QuestSO quest;

    public void Accept()
    {
        GameObject.Find("Player").GetComponent<QuestManager>().PlayerData.quests.Add(quest);
    }
}
