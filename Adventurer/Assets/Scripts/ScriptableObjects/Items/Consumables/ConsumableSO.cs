using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Item/Consumable")]
public class ConsumableSO : ScriptableObject
{
    public string itemName;
    public string type;
    public string description;
    public Sprite icon;

    public int[] restoration;
    public int[] buff;
}
