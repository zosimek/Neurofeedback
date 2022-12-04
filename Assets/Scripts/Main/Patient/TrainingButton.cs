using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingButton : MonoBehaviour
{
    [SerializeField]
    Button button;
    GameObject sceneController;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        PatientSession.patientId = button.GetComponent<Spawnee>().GetId();
        sceneController = GameObject.Find("SceneController");
        sceneController.GetComponent<PatientSession>().SetPatientName();
    }
}