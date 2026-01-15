using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SessionData
{
    public List<float> band_power;
    public double avg_threshold;
    public double max_threshold;
    public double min_threshold;
    public float success_factor;
    public string date;

    public SessionData()
    {
        band_power = DisplayFrequency.listFrequency;
        avg_threshold = DisplayThreshold.listThreshold.Average();
        max_threshold = DisplayThreshold.listThreshold.Max();
        min_threshold = DisplayThreshold.listThreshold.Min();
        success_factor = TimeOfTraining.overallSuccessFactor;
        date = DateTime.Now.ToString();
    }
}
