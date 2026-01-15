using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class HistoryButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Button button;
    GameObject sceneController;

    private static fsSerializer serializer = new fsSerializer();    // some variables to get all users from database
    public delegate void GetSessionFocusCallBack(Dictionary<string, SessionData> sessionsFocus);
    public delegate void GetSessionRelaxCallBack(Dictionary<string, SessionData> sessionsRelax);
    Dictionary<string, SessionData> sessionsFocus = new Dictionary<string, SessionData>();
    Dictionary<string, SessionData> sessionsRelax = new Dictionary<string, SessionData>();
    List<string> focusKey = new List<string>();  // the list of separated search values
    List<string> relaxKey = new List<string>();  // the list of separated search values

    public GameObject scrollableHistory;
    public GameObject greed;
    public GameObject spawnee;

    public GameObject scrollBar;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        greed = GameObject.Find("GridHistory");
        scrollBar = GameObject.Find("Scrollbar");
        scrollableHistory = GameObject.Find("ScrollableHistory");
    }

    void TaskOnClick()
    {
        PatientSession.patientId = button.GetComponent<Spawnee>().GetId();
        sceneController = GameObject.Find("SceneController").transform.gameObject;
        sceneController.GetComponent<PatientSession>().SetPatientName();
        RetriveFromDatabase(); // get the .json grom the database

        Debug.Log(sessionsRelax.Count);

        while (greed.transform.childCount > 0)
        {
            DestroyImmediate(greed.transform.GetChild(0).gameObject);
        }

        foreach (string key in focusKey)  // for each patientKey retreved from database
        {
            spawnee.transform.Find("TypeOfTraining").GetComponent<Text>().text = "Concentration";
            spawnee.transform.Find("TypeOfTraining").GetComponent<Text>().color = new Color(238, 44, 71, 255);
            spawnee.transform.Find("ValueSessionDate").GetComponent<Text>().text = sessionsFocus[key].date;
            spawnee.transform.Find("Val_avg_threshold").GetComponent<Text>().text = sessionsFocus[key].avg_threshold.ToString();
            spawnee.transform.Find("Val_success_factor").GetComponent<Text>().text = sessionsFocus[key].success_factor.ToString().Substring(0, 2);
            spawnee.transform.Find("Val_max_threshold").GetComponent<Text>().text = sessionsFocus[key].max_threshold.ToString();
            spawnee.transform.Find("Val_min_threshold").GetComponent<Text>().text = sessionsFocus[key].min_threshold.ToString();
            if (focusKey != null)
            {
                Instantiate(spawnee).transform.parent = greed.transform;
            }
        }

        foreach (string key in relaxKey)  // for each patientKey retreved from database
        {
            spawnee.transform.Find("TypeOfTraining").GetComponent<Text>().text = "Concentration";
            spawnee.transform.Find("TypeOfTraining").GetComponent<Text>().color = new Color(54, 198, 243, 255);
            spawnee.transform.Find("ValueSessionDate").GetComponent<Text>().text = sessionsFocus[key].date;
            spawnee.transform.Find("Val_avg_threshold").GetComponent<Text>().text = sessionsFocus[key].avg_threshold.ToString();
            spawnee.transform.Find("Val_success_factor").GetComponent<Text>().text = sessionsFocus[key].success_factor.ToString().Substring(0, 2);
            spawnee.transform.Find("Val_max_threshold").GetComponent<Text>().text = sessionsFocus[key].max_threshold.ToString();
            spawnee.transform.Find("Val_min_threshold").GetComponent<Text>().text = sessionsFocus[key].min_threshold.ToString();
            if (focusKey != null)
            {
                Instantiate(spawnee).transform.parent = greed.transform;
            }
        }
    }

    private void RetriveFromDatabase()
    {
        string id = button.GetComponent<Spawnee>().GetId();
        // get .json text that contains all the data from firebase database
        RestClient.Get("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/sessions/concentration/zofiadobrowolska_33083622-d653-403e-94ca-ca51d9f0df46.json").Then(response => {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);    // turn text json to actuall json
            object deserialized = null;

            // turn the json into a dictionary, where KEY --- USER ID, VALUE --- user data in form of USER class
            serializer.TryDeserialize(data, typeof(Dictionary<string, SessionData>), ref deserialized);

            sessionsFocus = deserialized as Dictionary<string, SessionData>;
            CallBackFocus(sessionsFocus);
        });

        RestClient.Get("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/sessions/relaxation/zofiadobrowolska_33083622-d653-403e-94ca-ca51d9f0df46.json").Then(response => {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);    // turn text json to actuall json
            object deserialized = null;

            // turn the json into a dictionary, where KEY --- USER ID, VALUE --- user data in form of USER class
            serializer.TryDeserialize(data, typeof(Dictionary<string, SessionData>), ref deserialized);

            sessionsRelax = deserialized as Dictionary<string, SessionData>;
            CallBackRelax(sessionsRelax);
        });
    }

    private void CallBackFocus(Dictionary<string, SessionData> sessions)
    {
        foreach (KeyValuePair<string, SessionData> pair in sessions)   // for every USER in database get his ID
        {
            focusKey.Add(pair.Key);  // store it in a list of patient KEYS
        }
    }

    private void CallBackRelax(Dictionary<string, SessionData> sessions)
    {
        foreach (KeyValuePair<string, SessionData> pair in sessions)   // for every USER in database get his ID
        {
            relaxKey.Add(pair.Key);  // store it in a list of patient KEYS
        }
    }
}
