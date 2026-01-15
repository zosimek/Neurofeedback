using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DisplayThreshold : MonoBehaviour
{
    public static string displayThreshold;
    public static List<float> listThreshold = new List<float>();

    public void Update()
    {
        GameObject.Find("ValueThreshold").GetComponent<Text>().text = displayThreshold;
        listThreshold.Add(float.Parse(displayThreshold, CultureInfo.InvariantCulture.NumberFormat));
    }
}
