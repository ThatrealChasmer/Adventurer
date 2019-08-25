using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public List<ItemSO> Stock;
    public GameObject SellButton;

    private void Start()
    {
        GenerateShop();
    }

    void GenerateShop()
    {
        GameObject temp;
        for (int i = 0; i < Stock.Count; i++)
        {
            temp = Instantiate(SellButton, transform.position + new Vector3(0, 85 - (85 * i), 0), Quaternion.identity, transform);
            temp.GetComponent<ShopItem>().Fill(Stock[i]);
        }
    }
}
