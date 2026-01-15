using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AutoThreshold : MonoBehaviour
{
    public static double slope;
    [HideInInspector]
    public List<double> frequencies = new List<double>();
    public double[] frequenciesArray = new double[] { };

    [HideInInspector]
    public List<double> yAxis = new List<double>{ 1, 2, 3, 4};
    public double[] yAxisArray = new double[] { };
    [HideInInspector]
    public double lastFrequency;

    // Start is called before the first frame update
    void Start()
    {
        lastFrequency = 0.0;
    }

    // Update is called once per frame
    void Update()
    {
        if (frequencies.Count < 4)
        {
            if (lastFrequency != Convert.ToDouble(DisplayFrequency.displayFrequency))
            {
                lastFrequency = Convert.ToDouble(DisplayFrequency.displayFrequency);
                frequencies.Add(lastFrequency);
            }
        }
        else
        {
            frequenciesArray = frequencies.ToArray();
            yAxisArray = yAxis.ToArray();
            LinearRegression.Program.LinearRegression(frequenciesArray, yAxisArray);
            frequencies = new List<double>();
            //Debug.Log("Slope: " + slope); Debug
        }
    }
}
