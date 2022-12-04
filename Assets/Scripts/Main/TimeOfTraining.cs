using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfTraining : MonoBehaviour
{

    public Text sessionTimeValue;
    public float timeInSeconds;


    public bool focusPacMan;
    public bool focusDruidWalk;
    public bool focusLakeRace;
    public bool relaxSea;
    public bool relaxCats;
    public bool relaxBird;


    // Concentration training
    public void onClickFocusPacMan(bool clicked)
    {
        focusPacMan = clicked;
    }

    public void onClickFocusDruidWalk(bool clicked)
    {
        focusDruidWalk = clicked;
    }

    public void onClickFocusLakeRace(bool clicked)
    {
        focusLakeRace = clicked;
    }

    // Relaxation training
    public void onClickRelaxSea(bool clicked)
    {
        relaxSea = clicked;
    }
    public void onClickRelaxCats(bool clicked)
    {
        relaxCats = clicked;
    }
    public void onClickRelaxBirds(bool clicked)
    {
        relaxBird = clicked;
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
            sessionTimeValue.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }
    }
}
