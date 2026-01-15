using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFrequency : MonoBehaviour
{
    public float lastFrequency;
    public static float displayFrequency;
    public static List<float> listFrequency = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        displayFrequency = 0.0f;
        lastFrequency = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("ValueFrequency").GetComponent<Text>().text = displayFrequency.ToString();
        if (lastFrequency != displayFrequency)
        {
            lastFrequency = displayFrequency;
            listFrequency.Add(lastFrequency);
        }
    }
}
