using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
public class ShowInventory : MonoBehaviour
{
    public GameObject descBox;
    public GameObject itemPrefab;
    public Inventory inv;
    public GameObject downArrow;
    public int perPage;
    public Vector3 startingPoint = new Vector3();
    public int shift;
    public int currentIndex = 0;
    public string listType;
    public bool mouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Debug.Log("Enabled!");
        currentIndex = 0;
        ChangeList(listType);
    }

    public void SetIndex(int index)
    {
        currentIndex = index;
    }

    public void ChangeList(string type)
    {
        switch (type)
        {
            case "Other":
                RenderItems(currentIndex);
                break;
            case "Consumable":
                RenderConsumables(currentIndex);
                break;
        }
        listType = type;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseHovering())
        {
            if (Input.mouseScrollDelta.y < 0 && currentIndex + 4 < inv.otherItems.Count)
            {
                currentIndex += 1;
                ChangeList(listType);
            }
            else if (Input.mouseScrollDelta.y > 0 && currentIndex > 0)
            {
                currentIndex -= 1;
                ChangeList(listType);
            }
        }
    }

    public void RenderItems(int index)
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.CompareTag("MenuItem"))
            {
                Destroy(t.gameObject);
            }
        }

        if (inv.otherItems.Count > index + 4)
        {
            downArrow.SetActive(true);
        }
        else
        {
            downArrow.SetActive(false);
        }

        List<Inventory.InventoryOtherItem> toRender = inv.otherItems.Skip(index).ToList();
        Debug.Log(toRender.Count);
        toRender = toRender.Take(perPage).ToList();
        for (int i = 0; i < toRender.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, gameObject.transform.position + startingPoint + new Vector3(0,-(shift * i), 0), Quaternion.identity, transform);
        }
    }

    public void RenderConsumables(int index)
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.CompareTag("MenuItem"))
            {
                Destroy(t.gameObject);
            }
        }

        if (inv.consumables.Count > index + 4)
        {
            downArrow.SetActive(true);
        }
        else
        {
            downArrow.SetActive(false);
        }

        List<Inventory.InventoryConsumableItem> toRender = inv.consumables.Skip(index).ToList();
        Debug.Log(toRender.Count);
        toRender = toRender.Take(perPage).ToList();
        for (int i = 0; i < toRender.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, gameObject.transform.position + new Vector3(0, 85 - (85 * i), 0), Quaternion.identity, transform);
        }
    }

    bool mouseHovering()
    {
        mouse = EventSystem.current.IsPointerOverGameObject();
        return EventSystem.current.IsPointerOverGameObject();
    }
}
