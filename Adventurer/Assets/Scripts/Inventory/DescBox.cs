using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescBox : MonoBehaviour
{
    public Text itemName;
    public Text type;
    public Text desc;
    public void Fill(ItemSO so)
    {
        itemName.text = so.item_name;
        type.text = so.type.ToString();
    }
}
