using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSignalSubmitChanges : MonoBehaviour
{
    [SerializeField]
    Button submitChanges;
    void Start()
    {
        submitChanges.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        DisplayThreshold.displayThreshold = SignalPageValues.signalEnteredThreshold.ToString();
        DisplayDuration.displayDuration = SignalPageValues.signalSessionDuration.ToString();
    }
}
