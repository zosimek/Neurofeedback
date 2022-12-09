using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using System;
using UnityEditor;
using UnityEngine.EventSystems;

public class AddPatient : MonoBehaviour
{

    public Button button;

    public static string firstName;
    public static string lastName;
    public static string day;
    public static string month;
    public static string year;
    public static string sex;

    public Dropdown dayDropdown;
    public Dropdown monthDropdown;
    public Dropdown yearDropdown;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        firstName = GameObject.Find("InputFirstName").GetComponent<InputField>().text;
        lastName = GameObject.Find("InputLastName").GetComponent<InputField>().text;

        day = dayDropdown.options[dayDropdown.value].text;
        month = (monthDropdown.value + 1).ToString();
        year = yearDropdown.options[yearDropdown.value].text;

        sex = SetSex.sexSelected;

        //Debug.Log(firstName + "--" + lastName + "--" + day + "--" + month + "--" + year + "--" + sex);
        PostToDatabase();
        GameObject.Find("InputFirstName").GetComponent<InputField>().text = "";
        GameObject.Find("InputLastName").GetComponent<InputField>().text = "";
    }

    private void PostToDatabase()
    {
        User user = new User();

        string guid = Guid.NewGuid().ToString();

        string id = user.firstName.ToLower() + user.lastName.ToLower() + "_" + guid;
        //RestClient.Put("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/" + id + ".json", user);

        RestClient.Put<User>("https://neurofeedback-10031975-default-rtdb.europe-west1.firebasedatabase.app/patients/" + id + ".json", user).Then(customResponse => {
            GameObject.Find("InputFirstName").GetComponent<InputField>().Select();
            GameObject.Find("InputFirstName").GetComponent<InputField>().text = "";
            GameObject.Find("InputLastName").GetComponent<InputField>().Select();
            GameObject.Find("InputLastName").GetComponent<InputField>().text = "";
        });
    }
}
