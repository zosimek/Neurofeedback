using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class PatientSession : MonoBehaviour
{
    public Text currentPatient;
    public static string patientId;
    public static string patientName;


    private static fsSerializer serializer = new fsSerializer();    // some variables to get all users from database

    User patient = new User(); // the dictionary containing the user id as KEY and user data as USER


    private void RetriveFromDatabase()
    {
        // get .json text that contains all the data from firebase database
        RestClient.Get("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/patients/" + patientId + ".json").Then(response => {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);    // turn text json to actuall json
            object deserialized = null;

            // turn the json into a dictionary, where KEY --- USER ID, VALUE --- user data in form of USER class
            serializer.TryDeserialize(data, typeof(User), ref deserialized);

            patient = deserialized as User;
        });
    }

    public void SetPatientName()
    {
        RetriveFromDatabase();
        if(patient != null)
        {
            patientName = patient.firstName + " " + patient.lastName;
            currentPatient.text = patientName;
        }
    }
}
