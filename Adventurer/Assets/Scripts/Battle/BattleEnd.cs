using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public GameObject first;

    private void OnEnable()
    {
        Debug.Log("Activated");
        first.SetActive(true);
    }
}
