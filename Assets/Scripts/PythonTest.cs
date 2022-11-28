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
    bool isOverThreshold;
    float band_power;
    public List<float> band_power_list = new List<float>();
    public List<string> time_list = new List<string>();

    public void QuitApp()
    {   
        print("Quitting");
        Application.Quit();
    }

    public void UpdatePythonRcvdText(string str)
    {
        //tempStr = str;
        string theTime = System.DateTime.Now.ToString();
        //time_list.Add(theTime);
        band_power = float.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
        //band_power_list.Add(band_power);
        Debug.Log(band_power);
        if (band_power > 10)
        {
            isOverThreshold = true;
        }
        else 
        {
            isOverThreshold = false;
        }
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
        if(ChangeScene.sceneName  == "Pac-man") 
        { 
            FindObjectOfType<PacManMenagere>().UpdatePosition(isOverThreshold);
        }
        else if (ChangeScene.sceneName == "RaceLake")
        {
            FindObjectOfType<RaceLakeController>().UpdatePosition(isOverThreshold);
        }
        //pythonRcvdText.text = tempStr;
        //Debug.Log(isOverThreshold);
    }
}
