using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuController : MonoBehaviour
{
    public class Quest
    {
        public string name;
        public string description;
        public int rewardGold;

        public Quest(string name, string desc, int gold)
        {
            this.name = name;
            this.description = desc;
            this.rewardGold = gold;
        }
    }

    public List<Quest> viableQuests = new List<Quest>();

    public int currentIndex;
    public Quest currentQuest;
    // Start is called before the first frame update
    void Start()
    {
        viableQuests.Add(new Quest("Quest1", "This is test Quest1", 10));
        viableQuests.Add(new Quest("Quest2", "This is test Quest2", 20));
        viableQuests.Add(new Quest("Quest3", "This is test Quest3", 30));
        currentIndex = 0;
        currentQuest = viableQuests[currentIndex];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(Input.GetKeyDown(KeyCode.RightArrow) && currentIndex + 1 < viableQuests.Count)
            {
                currentIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex > 0)
            {
                currentIndex--;
            }

            currentQuest = viableQuests[currentIndex];
            Debug.Log(currentQuest.name);
        }
        

    }

    public void RenderQuest(Quest quest)
    {
        
    }
}
