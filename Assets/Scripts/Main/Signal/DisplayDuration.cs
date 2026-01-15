using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDuration : MonoBehaviour
{
    public static string displayDuration;

    public void Update()
    {
        GameObject.Find("ValueDuration").GetComponent<Text>().text = displayDuration;
    }
}
