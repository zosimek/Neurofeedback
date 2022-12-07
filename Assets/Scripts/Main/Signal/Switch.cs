using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image On;
    public Image Off;
    [SerializeField]
    GameObject setThreshold;
    public static bool isThresholdAuto;


    void Update()
    {
        if (SignalPageValues.autoThreshold == true)
        {
            setThreshold.SetActive(false);
            isThresholdAuto = true;
        }
        if (SignalPageValues.autoThreshold == false)
        {
            setThreshold.SetActive(true);
            isThresholdAuto = false;
        }
    }

    public void ON()
    {
        SignalPageValues.autoThreshold = true;
        Off.gameObject.SetActive(false);
        On.gameObject.SetActive(true);
    }

    public void OFF()
    {
        SignalPageValues.autoThreshold = false;
        Off.gameObject.SetActive(true);
        On.gameObject.SetActive(false);
    }
}
