using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class YearDropdown : MonoBehaviour
{
    public Text textYear;
    public string stringYear;
    [HideInInspector]
    private Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        System.DateTime theTime = System.DateTime.Now;
        int theYear = theTime.Year;

        // create the list of years from 150 years ago to this date
        int[] years = Enumerable.Range(theYear - 150, 151).ToArray();
        Array.Reverse(years);
        //Fetch the Dropdown GameObject the script is attached to
        dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();
        //Add the options created in the List above
        foreach (int year in years)
        {
            dropdown.options.Add(new Dropdown.OptionData(year.ToString()));
        }
    }

    void Update()
    {
        //textYear.text = dropdown.options[dropdown.value].text;
        stringYear = dropdown.options[dropdown.value].text;
    }
}
