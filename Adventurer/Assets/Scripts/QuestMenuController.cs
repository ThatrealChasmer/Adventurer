using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuController : MonoBehaviour
{
    public GameObject questField;

    public List<Quests.Quest> viableQuests = new List<Quests.Quest>();

    public List<Quests.Quest> quests = new List<Quests.Quest>();

    public int qAmount;
    public int currentIndex;
    public Quests.Quest currentQuest;
    // Start is called before the first frame update
    void Start()
    {
        questField = gameObject;
        Quests.pickableQuests = Quests.allQuests;
        viableQuests = Quests.pickableQuests;

        for(int i = 0; i < qAmount; i++)
        {
            int id = Random.Range(0, viableQuests.Count);
            quests.Add(viableQuests[id]);
            viableQuests.RemoveAt(id);
        }
        currentIndex = 0;
        currentQuest = quests[currentIndex];

        RenderQuest(currentQuest);
        Debug.Log(currentQuest.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(Input.GetKeyDown(KeyCode.RightArrow) && currentIndex + 1 < quests.Count)
            {
                currentIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex > 0)
            {
                currentIndex--;
            }

            currentQuest = quests[currentIndex];
            RenderQuest(currentQuest);
            Debug.Log(currentQuest.name);
        }
        

    }

    public void RenderQuest(Quests.Quest quest)
    {
        transform.GetChild(0).GetComponent<Text>().text = quest.name;
        transform.GetChild(1).GetComponent<Text>().text = quest.description;
        transform.GetChild(3).GetComponent<Text>().text = quest.reward.ToString();
    }
}
