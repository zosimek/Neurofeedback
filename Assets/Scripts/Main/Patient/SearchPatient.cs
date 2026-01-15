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
    public GameObject spawnee;  // GameObject to create for every patient, that mach the search values
    public GameObject greed;

    private static fsSerializer serializer = new fsSerializer();    // some variables to get all users from database
    public delegate void GetUsersCallback(Dictionary<string, User> patients);

    public Button button;    // button which activates the search
    public GameObject scrollableList;   // just for scrollableList to appear aftef search button is pressed
    public GameObject scrollableHistory;   // just for scrollableList to appear aftef search button is pressed
    public GameObject scrollBar;

    public static string searchTxt;    // the searched value
    public InputField searchInput;    // and the field where it's provided

    char[] separators = new char[] { ' ', '.' };    // the chars that separate the search values
    List<string> patientsKey = new List<string>();  // the list of separated search values
    Dictionary<string, User> patients = new Dictionary<string, User>(); // the dictionary containing the user id as KEY and user data as USER


    private string birthDate;
    private string day;
    private string month;
    private string year;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);    // wait for the button to be pressed
    }
    void TaskOnClick()
    {
        greed = GameObject.Find("GridContent");
        searchTxt = GameObject.Find("InputSearch").GetComponent<InputField>().text; // get search vaules from it's input field
        RetriveFromDatabase(); // get the .json grom the database

        while (greed.transform.childCount > 0)
        {
            DestroyImmediate(greed.transform.GetChild(0).gameObject);
        }

        foreach (var word in searchTxt.Split(separators, StringSplitOptions.RemoveEmptyEntries)) // for every word in search value
        {
            foreach (string patientKey in patientsKey)  // for each patientKey retreved from database
            {
                if (patientKey.Contains(word)) // if both of the above match, then
                {
                    spawnee.transform.Find("PatientName").GetComponent<Text>().text = patients[patientKey].firstName + " " + patients[patientKey].lastName;

                    birthDate = patients[patientKey].birthDate;
                    int j = 0;
                    foreach (var number in birthDate.Split("-", StringSplitOptions.RemoveEmptyEntries))
                    { 
                        if(j == 0) 
                        {
                            day = number.ToString();
                        }
                        if (j == 1) 
                        {
                            switch (number)
                            {
                                case "1":
                                    month = "January";
                                    break;
                                case "2":
                                    month = "February";
                                    break;
                                case "3":
                                    month = "March";
                                    break;
                                case "4":
                                    month = "April";
                                    break;
                                case "5":
                                    month = "May";
                                    break;
                                case "6":
                                    month = "June";
                                    break;
                                case "7":
                                    month = "July";
                                    break;
                                case "8":
                                    month = "August";
                                    break;
                                case "9":
                                    month = "September";
                                    break;
                                case "10":
                                    month = "October";
                                    break;
                                case "11":
                                    month = "November";
                                    break;
                                case "12":
                                    month = "December";
                                    break;
                            }
                        }
                        if (j == 2)
                        {
                            year = number.ToString();
                        }
                        j += 1;
                    }

                    spawnee.transform.Find("PatientInfo").GetComponent<Text>().text = day + " " + month + " " + year + "    " + patients[patientKey].sex;
                    Spawnee spawneeId = spawnee.GetComponent<Spawnee>();
                    Spawnee spawneeHistory = spawnee.transform.Find("BtnHistory").GetComponent<Spawnee>();
                    Spawnee spawneeTraining = spawnee.transform.Find("BtnTraining").GetComponent<Spawnee>();

                    spawneeId.SetSpawneePatient(patientKey);
                    spawneeHistory.SetSpawneePatient(patientKey);
                    spawneeTraining.SetSpawneePatient(patientKey);

                    if(patients != null)
                    {
                        Instantiate(spawnee).transform.parent = greed.transform;
                    }
                }
            }
        }

        patientsKey.Clear();
    }


    private void RetriveFromDatabase()
    {
        // get .json text that contains all the data from firebase database
        RestClient.Get("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/patients.json").Then(response => {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);    // turn text json to actuall json
            object deserialized = null;

            // turn the json into a dictionary, where KEY --- USER ID, VALUE --- user data in form of USER class
            serializer.TryDeserialize(data, typeof(Dictionary<string, User>), ref deserialized);

            patients = deserialized as Dictionary<string, User>;
            CallBack(patients);
        });
    }

    private void CallBack(Dictionary<string, User> patients)
    {
        foreach (KeyValuePair<string, User> pair in patients)   // for every USER in database get his ID
        {
            patientsKey.Add(pair.Key);  // store it in a list of patient KEYS
        }
    }
}
