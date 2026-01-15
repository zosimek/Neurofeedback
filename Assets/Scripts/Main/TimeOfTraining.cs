using Proyecto26;
using System;
using System.Globalization;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeOfTraining : MonoBehaviour
{

    public Text sessionTimeValue;
    public static float timeInSeconds;
    public float timeOverThreshold;
    public static string typeOfTraining;
    public static float overallSuccessFactor;

    [HideInInspector]
    public bool focusPacMan;
    [HideInInspector]
    public bool focusDruidWalk;
    [HideInInspector]
    public bool focusLakeRace;
    [HideInInspector]
    public bool relaxSea;
    [HideInInspector]
    public bool relaxCats;
    [HideInInspector]
    public bool relaxBird;

    public AudioSource audioOverThreshold;
    public AudioSource audioUnderThreshold;

    public AudioClip sea;
    public AudioClip storm;
    public AudioClip cat;
    public AudioClip lion;
    public AudioClip birds;
    public AudioClip raven;


    // Concentration training
    public void onClickFocusPacMan(bool clicked)
    {
        focusPacMan = clicked;
        typeOfTraining = "concentration";
    }

    public void onClickFocusDruidWalk(bool clicked)
    {
        focusDruidWalk = clicked;
        typeOfTraining = "concentration";
    }

    public void onClickFocusLakeRace(bool clicked)
    {
        focusLakeRace = clicked;
        typeOfTraining = "concentration";
    }

    // Relaxation training
    public void onClickRelaxSea(bool clicked)
    {
        relaxSea = clicked;
        typeOfTraining = "relaxation";

        audioOverThreshold.clip = sea;
        audioUnderThreshold.clip = storm;

        audioOverThreshold.Play();
        audioUnderThreshold.Play();
    }
    public void onClickRelaxCats(bool clicked)
    {
        relaxCats = clicked;
        typeOfTraining = "relaxation";

        audioOverThreshold.clip = cat;
        audioUnderThreshold.clip = lion;

        audioOverThreshold.Play();
        audioUnderThreshold.Play();
    }
    public void onClickRelaxBirds(bool clicked)
    {
        relaxBird = clicked;
        typeOfTraining = "relaxation";

        audioOverThreshold.clip = birds;
        audioUnderThreshold.clip = raven;

        audioOverThreshold.Play();
        audioUnderThreshold.Play();
    }


    private void Start()
    {
        timeInSeconds = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(focusPacMan ^ focusDruidWalk ^ focusLakeRace ^ relaxSea ^ relaxCats ^ relaxBird)
        {
            timeInSeconds += Time.deltaTime;
            var ts = TimeSpan.FromSeconds(timeInSeconds);
            //////////////////////////////////////////////////////////////////////////////////////
            //time over threshold to compyte the success factor of the whole session
            if (DisplayFrequency.displayFrequency >= float.Parse(DisplayThreshold.displayThreshold, CultureInfo.InvariantCulture.NumberFormat))
            {
                timeOverThreshold += Time.deltaTime;
            }
            //////////////////////////////////////////////////////////////////////////
            if (int.Parse(DisplayDuration.displayDuration) > ts.Minutes)
            {
                sessionTimeValue.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            }
            else
            {
                overallSuccessFactor = (timeOverThreshold / timeInSeconds) * 100;
                if (int.Parse(DisplayDuration.displayDuration) == ts.Minutes)
                {
                    PostSessionToDatabase();
                }
                sessionTimeValue.text = "00:00";
                FindObjectOfType<ChangeScene>().LoadScene("Main");
                UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    public void PostSessionToDatabase()
    {
        overallSuccessFactor = (timeOverThreshold / timeInSeconds) * 100;
        SessionData sessionData = new SessionData();
        string id = sessionData.date;
        RestClient.Post<SessionData>("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/sessions/" + typeOfTraining + "/" + PatientSession.patientId + ".json", sessionData).Then(customResponse => { Debug.Log("dodano sesjê"); });
    }

    [Obsolete]
    public void EndSession()
    {
        PostSessionToDatabase();
        FindObjectOfType<ChangeScene>().LoadScene("Main");
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
