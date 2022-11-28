using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SearchPatient : MonoBehaviour
{


    private static fsSerializer serializer = new fsSerializer();
    public delegate void GetUsersCallback(Dictionary<string, User> patients);

    public Button button;

    public static string searchTxt;
    public InputField searchInput;

    char[] separators = new char[] { ' ', '.' };
    List<string> patientsKey = new List<string>();
    Dictionary<string, User> patients = new Dictionary<string, User>();

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        searchTxt = GameObject.Find("InputSearch").GetComponent<InputField>().text;
        RetriveFromDatabase();

        foreach (var word in searchTxt.Split(separators, StringSplitOptions.RemoveEmptyEntries))
        {
            foreach (string patientKey in patientsKey)
            {
                if (patientKey.Contains(word))
                {
                    Debug.Log(patients[patientKey].firstName + " " + patients[patientKey].lastName);
                }
            }
            /*words.Add(word);
            Debug.Log(word);*/
        }

        patientsKey.Clear();
    }


    private void RetriveFromDatabase()
    {
        RestClient.Get("https://neurofeedback-5bc33-default-rtdb.europe-west1.firebasedatabase.app/patients.json").Then(response => {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, User>), ref deserialized);

            patients = deserialized as Dictionary<string, User>;
            CallBack(patients);
        });
    }

    private void CallBack(Dictionary<string, User> patients)
    {
        foreach (KeyValuePair<string, User> pair in patients)
        {
            patientsKey.Add(pair.Key);
        }
    }
}
