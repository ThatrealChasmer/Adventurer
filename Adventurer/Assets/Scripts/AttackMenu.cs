using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject menuItem;
    public GameObject indicator;
    public Vector2Int indpos = new Vector2Int();
    public int currentIndex;
    public int minRenderedIndex;
    public int maxRenderedIndex;
    public BattleTestPlayer.Skill currentSkill;
    
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];
        MoveIndicator(new Vector2Int(currentIndex%2, (currentIndex - minRenderedIndex)/2));
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
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex % 2 == 0 && currentIndex + 1 < player.GetComponent<BattleTestPlayer>().skills.Count)
            {
                currentIndex += 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex + 2 < player.GetComponent<BattleTestPlayer>().skills.Count)
            {
                currentIndex += 2;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex % 2 == 1)
            {
                currentIndex -= 1;
            }

            currentSkill = player.GetComponent<BattleTestPlayer>().skills[currentIndex];

            if (currentIndex > maxRenderedIndex)
            {
                if(currentIndex%2 == 0)
                {
                    RenderMenuItems(currentIndex - 2);
                }
                else if(currentIndex %2 == 1)
                {
                    RenderMenuItems(currentIndex - 3);
                }
            }
            else if(currentIndex < minRenderedIndex)
            {
                if (currentIndex % 2 == 0)
                {
                    RenderMenuItems(currentIndex);
                }
                else if (currentIndex % 2 == 1)
                {
                    RenderMenuItems(currentIndex - 1);
                }
            }

            indpos.x = currentIndex % 2;
            indpos.y = (currentIndex - minRenderedIndex) / 2;

            MoveIndicator(indpos);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {

        }
    }

    public void RenderMenuItems(int index)
    {
        foreach (Transform child in gameObject.transform)
        {
            if(child.gameObject.CompareTag("MenuItem"))
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        int curIndex = index;
        float xcoord = gameObject.transform.position.x - 300;
        float ycoord = gameObject.transform.position.y + 27.5f;
        int renderedItems = 0;
        for (int i = curIndex; i < curIndex + 4; i++)
        {
            if (i < player.GetComponent<BattleTestPlayer>().skills.Count)
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
                renderedItems++;
            }
        }
        minRenderedIndex = index;
        maxRenderedIndex = index + renderedItems - 1;
    }

    public void MoveIndicator(Vector2Int pos)
    {
        indicator.transform.position = new Vector3(gameObject.transform.position.x - 300 + pos.x * 200, gameObject.transform.position.y + 27.5f - pos.y * 55);
    }
}
