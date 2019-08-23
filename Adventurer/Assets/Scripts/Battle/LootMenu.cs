using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LootMenu : MonoBehaviour
{
    public GameObject downArrow;
    public List<GameObject> items;

    public GameObject itemPrefab;
    public BattleInfoSO battleInfo;

    public int currentIndex = 0;
    
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 && currentIndex + 4 < battleInfo.items.Count)
        {
            currentIndex += 1;
            RenderItems(currentIndex);
        }
        else if (Input.mouseScrollDelta.y > 0 && currentIndex > 0)
        {
            currentIndex -= 1;
            RenderItems(currentIndex);
        }
    }

    void OnEnable()
    {
        RenderItems(currentIndex);
    }

    public void RenderItems(int index)
    {
        foreach(Transform t in transform)
        {
            if(t.gameObject.CompareTag("MenuItem"))
            {
                Destroy(t.gameObject);
            }
        }

        if(battleInfo.items.Count > index + 4)
        {
            downArrow.SetActive(true);
        }
        else
        {
            downArrow.SetActive(false);
        }

        List<ItemSO> toRender = battleInfo.items.Skip(index).ToList();
        toRender = toRender.Take(4).ToList();
        for (int i = 0; i < toRender.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, gameObject.transform.position + new Vector3(0, 85 - (85 * i), 0), Quaternion.identity, transform);
            item.GetComponent<DropItemButton>().Fill(toRender[i], 1);
            items.Add(item);

        }
    }
    
}
