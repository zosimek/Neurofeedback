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
    [SerializeField]
    bool autoThreshold;

    void Update()
    {
        if (autoThreshold == true)
        {
            setThreshold.SetActive(false);
        }
        if (autoThreshold == false)
        {
            setThreshold.SetActive(true);
        }
    }

    public void ON()
    {
        autoThreshold = true;
        Off.gameObject.SetActive(true);
        On.gameObject.SetActive(false);
        Debug.Log(autoThreshold);
    }

    public void OFF()
    {
        autoThreshold = false;
        Off.gameObject.SetActive(false);
        On.gameObject.SetActive(true);
        Debug.Log(autoThreshold);
    }
}
