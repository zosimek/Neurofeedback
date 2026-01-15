using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthDropdown : MonoBehaviour
{
    public Text textMonth;
    public string stringMonth;
    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        //Fetch the Dropdown GameObject the script is attached to
        dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();
        //Add the options created in the List above
        dropdown.AddOptions(months);

        System.DateTime theTime = System.DateTime.Now;
        int theMonth = theTime.Month;
        dropdown.value = theMonth - 1;
    }

    void Update()
    {
        //textMonth.text = dropdown.options[dropdown.value].text;
        stringMonth = dropdown.options[dropdown.value].text;
    }
}
