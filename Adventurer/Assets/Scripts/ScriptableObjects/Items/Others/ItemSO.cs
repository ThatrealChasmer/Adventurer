using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Item/Other")]
public class ItemSO : ScriptableObject
{
    public string item_name;
    public Sprite icon;
    public int gold;
    public itemType type;

    public enum itemType{
        junk,
        quest,
        material
    }
}
