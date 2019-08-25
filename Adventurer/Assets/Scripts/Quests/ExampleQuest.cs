﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleQuest : MonoBehaviour
{
    public bool completion = false;
    public int amount = 0;


    public void Check(string name)
    {
        if (!completion && name.Equals("Doggo"))
        {
            amount++;
            if (amount >= 5)
            {
                completion = true;
            }
        }
    }
}
