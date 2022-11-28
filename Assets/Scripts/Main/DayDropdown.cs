using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DayDropdown : MonoBehaviour
{
    public Text textDay;
    public string stringDay;
    [HideInInspector]
    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        // getting dropdown component (the script has to be assined to the Dropdown GameObject)
        dropdown = GameObject.Find("DropdownDay").GetComponent<Dropdown>();

        // create the list of days from 1 to 31
        int[] days = Enumerable.Range(1, 31 + 1).ToArray();

        // reset the dropdown options
         dropdown.options.Clear();

        // insert days number into dropdown components
        foreach (int day in days)
        {
            dropdown.options.Add(new Dropdown.OptionData(day.ToString()));
        }
        System.DateTime theTime = System.DateTime.Now;
        int theDay = theTime.Day;
        dropdown.value = theDay - 1;
    }

    void Update()
    {
        //textDay.text = dropdown.options[dropdown.value].text;
        stringDay = dropdown.options[dropdown.value].text;
    }
}
