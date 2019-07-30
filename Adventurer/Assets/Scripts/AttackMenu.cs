using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject menuItem;
    public int currentIndex;
    public int minRenderedIndex;
    public int maxRenderedIndex;
    public BattleTestPlayer.Skill currentSkill;
    
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
        RenderMenuItems(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && currentIndex - 2 >= 0)
            {
                currentIndex -= 2;
                currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex % 2 == 0 && currentIndex + 1 < player.GetComponent<BattleTestPlayer>().skills.Count)
            {
                currentIndex += 1;
                currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex + 2 < player.GetComponent<BattleTestPlayer>().skills.Count)
            {
                currentIndex += 2;
                currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex % 2 == 1)
            {
                currentIndex -= 1;
                currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
            }

            if (currentIndex > maxRenderedIndex || currentIndex < minRenderedIndex)
            {
                RenderMenuItems(currentIndex);
            }
        }
    }

    public void RenderMenuItems(int index)
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        int curIndex = index;
        float xcoord = gameObject.transform.position.x - 300;
        float ycoord = gameObject.transform.position.y + 27.5f;
        for (int i = curIndex; i < curIndex + 4; i++)
        {
            if (i % 2 == 0)
            {
                GameObject skill = Instantiate(menuItem, new Vector3(xcoord, ycoord, 0), Quaternion.identity, gameObject.transform);
                skill.transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<BattleTestPlayer>().skills[i].name;
            }
            else
            {
                GameObject skill = Instantiate(menuItem, new Vector3(xcoord + 200, ycoord, 0), Quaternion.identity, gameObject.transform);
                skill.transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<BattleTestPlayer>().skills[i].name;
                ycoord -= 55;
            }
        }
        minRenderedIndex = index;
        maxRenderedIndex = index + 3;
    }
}
