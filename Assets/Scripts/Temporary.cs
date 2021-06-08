using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public Dictionary<string, int> dictionary;

    private void Start()
    {
        dictionary = new Dictionary<string, int>();
        dictionary.Add("1",5);
        dictionary.Add("2",7);
        dictionary.Add("3",9);

    }
}
