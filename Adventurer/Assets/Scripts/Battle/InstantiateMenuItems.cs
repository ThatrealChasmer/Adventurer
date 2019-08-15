using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InstantiateMenuItems : MonoBehaviour
{
    public GameObject prefab;

    public PlayerData playerData;

    public string menu;

    public List<SkillSO> skills;

    public int currentIndex;

    Vector3[] menuSpots = {
        new Vector3(-680, 60, 0),
        new Vector3(-230, 60, 0),
        new Vector3(-680, -60, 0),
        new Vector3(-230, -60, 0)
    };

    private void OnEnable()
    {
        currentIndex = 0;
        switch(menu)
        {
            case "Attack":
                skills = playerData.skills;
                InstantiateMenu(skills, currentIndex);
                break;
            case "Spells":
                break;
            case "Items":
                break;
        }

        
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y < 0 && currentIndex + 4 < skills.Count)
        {
            currentIndex += 2;
            InstantiateMenu(skills, currentIndex);
        }
        else if(Input.mouseScrollDelta.y > 0 && currentIndex > 0)
        {
            currentIndex -= 2;
            InstantiateMenu(skills, currentIndex);
        }
    }

    public void InstantiateMenu(List<SkillSO> items, int index)
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.name != "ReturnButton")
            {
                Destroy(child.gameObject);
            }
        }

        int perPage = 4;
        List<SkillSO> toCreate = items.Skip(index).ToList();
        toCreate = toCreate.Take(perPage).ToList();

        foreach(SkillSO skill in toCreate)
        {
            Debug.Log(skill.skillName);
        }

        for (int i = 0; i < toCreate.Count; i++)
        {
            GameObject position = Instantiate(prefab, gameObject.transform);
            position.transform.position = transform.position + menuSpots[i];
            position.name = toCreate[i].name;
            position.GetComponent<MenuItem>().Fill(toCreate[i]);
        }
    }

}
