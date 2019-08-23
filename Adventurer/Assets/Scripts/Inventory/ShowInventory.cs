using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShowInventory : MonoBehaviour
{
    public GameObject descBox;
    public GameObject itemPrefab;
    public Inventory inv;
    public GameObject downArrow;
    public int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Debug.Log("Enabled!");
        RenderItems(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 && currentIndex + 4 < inv.otherItems.Count)
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
        toRender = toRender.Take(4).ToList();
        for (int i = 0; i < toRender.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, gameObject.transform.position + new Vector3(0, 85 - (85 * i), 0), Quaternion.identity, transform);
            item.GetComponent<InventoryItem>().Fill(toRender[i]);

        }
    }
}
