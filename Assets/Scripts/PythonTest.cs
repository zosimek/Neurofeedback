using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class PythonTest : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI pythonRcvdText = null;
    //[SerializeField] TextMeshProUGUI sendToPythonText = null;

    //string tempStr = "Sent from Python xxxx";
    int numToSendToPython = 0;
    UdpSocket udpSocket;
    public static bool isOverThreshold;
    public static float band_power;

    public void QuitApp()
    {   
        print("Quitting");
        Application.Quit();
    }

    public void UpdatePythonRcvdText(string str)
    {
        band_power = float.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
        DisplayFrequency.displayFrequency = band_power;
        if (band_power > float.Parse(DisplayThreshold.displayThreshold, CultureInfo.InvariantCulture.NumberFormat))
        {
            isOverThreshold = true;
        }
        else 
        {
            isOverThreshold = false;
        }
        Debug.Log(isOverThreshold);
    }

    public void SendToPython()
    {
        udpSocket.SendData("Sent From Unity: " + numToSendToPython.ToString());
        numToSendToPython++;
        //sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
    }

    private void Start()
    {
        udpSocket = FindObjectOfType<UdpSocket>();
        //sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
    }

    void Update()
    {
        //pythonRcvdText.text = tempStr;
        //Debug.Log(isOverThreshold);
    }
}
