using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInv : MonoBehaviour
{
    public GameObject invBox;

    void OnEnable()
    {
        invBox.SetActive(true);
    }
}
