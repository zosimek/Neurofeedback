using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalPageValues : MonoBehaviour
{
    public static int signalFrequency;
    public static int signalThreshold;
    public static bool autoThreshold;
    [SerializeField]
    public static int signalEnteredThreshold;
    [SerializeField]
    public static int signalSessionDuration;

    public GameObject page3;


    public void Start()
    {
        autoThreshold = false;
        signalEnteredThreshold = 10;
        signalSessionDuration = 15;
        DisplayThreshold.displayThreshold = signalEnteredThreshold.ToString();
        DisplayDuration.displayDuration = signalSessionDuration.ToString();
    }

    public void Update()
    {
        if (page3.active.Equals(true))
        {
            GetEnteredThreshold();
            GetSessionDuration();
        } 
    }

    public void GetEnteredThreshold()
    {
        if (GameObject.Find("InputThreshold").GetComponent<InputField>().text != null & GameObject.Find("InputThreshold").GetComponent<InputField>().text != "")
        {
            signalEnteredThreshold = int.Parse(GameObject.Find("InputThreshold").GetComponent<InputField>().text);
        }
    }

    public void GetSessionDuration()
    {
        if (GameObject.Find("InputDuration").GetComponent<InputField>().text != null & GameObject.Find("InputDuration").GetComponent<InputField>().text != "")
        {
            signalSessionDuration = int.Parse(GameObject.Find("InputDuration").GetComponent<InputField>().text);
        }
    }
}