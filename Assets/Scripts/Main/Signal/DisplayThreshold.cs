using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayThreshold : MonoBehaviour
{
    public static string displayThreshold;

    public void Update()
    {
        GameObject.Find("ValueThreshold").GetComponent<Text>().text = displayThreshold;
    }
}
