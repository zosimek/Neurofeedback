using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnee : MonoBehaviour
{
    [SerializeField]
    string patientKey;

    public void SetSpawneePatient(string id)
    {
        patientKey = id;
    }

    public string GetId()
    {
        return patientKey;
    }
}
