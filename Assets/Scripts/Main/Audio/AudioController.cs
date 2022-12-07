using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioOverThreshold;
    public AudioSource audioUnderThreshold;

    void Update()
    {
        if (DisplayFrequency.displayFrequency >= float.Parse(DisplayThreshold.displayThreshold, CultureInfo.InvariantCulture.NumberFormat))
        {
            audioOverThreshold.mute = false;
            audioUnderThreshold.mute = true;
        }
        else
        {
            audioOverThreshold.mute = true;
            audioUnderThreshold.mute = false;
        }
    }
}
