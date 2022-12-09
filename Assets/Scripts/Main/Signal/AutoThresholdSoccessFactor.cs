using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AutoThresholdSoccessFactor : MonoBehaviour
{
    public static int thresholdCoefficient;

    public static float timeOver;
    public static int timeOverSec;
    public static float timeAll;
    public static int timeAllSec;

    // Start is called before the first frame update
    void Start()
    {
        timeOver = 0.0f;
        timeAll = 0.0f;
        timeAllSec  = TimeSpan.FromSeconds(timeAll).Seconds;
        timeOverSec  = TimeSpan.FromSeconds(timeAll).Seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeAllSec < 5.0f)
        {
            timeAll += Time.deltaTime;
            timeAllSec = TimeSpan.FromSeconds(timeAll).Seconds;
            if (DisplayFrequency.displayFrequency >= float.Parse(DisplayThreshold.displayThreshold, CultureInfo.InvariantCulture.NumberFormat))
            {
                timeOver += Time.deltaTime;
                timeOverSec = TimeSpan.FromSeconds(timeOver).Seconds;
            }
            thresholdCoefficient = 0;
        }
        else
        {
            var ratio = (timeOver / timeAll)*100;
            if ((SignalPageValues.signalSuccessFactor - 5) > ratio)
            {
                thresholdCoefficient = -1;
                if(Switch.isThresholdAuto == true)
                {
                    SignalPageValues.signalEnteredThreshold = SignalPageValues.signalEnteredThreshold - 1;
                }
            }
            if ((SignalPageValues.signalSuccessFactor + 5) < ratio)
            {
                thresholdCoefficient = 1;
                if (Switch.isThresholdAuto == true)
                {
                    SignalPageValues.signalEnteredThreshold = SignalPageValues.signalEnteredThreshold + 1;
                }
            }
            else
            {
                thresholdCoefficient = 0;
            }
            timeOver = 0.0f;
            timeAll = 0.0f;
            timeAllSec = TimeSpan.FromSeconds(timeAll).Seconds;
            timeOverSec = TimeSpan.FromSeconds(timeOver).Seconds;
        }
    }
}
