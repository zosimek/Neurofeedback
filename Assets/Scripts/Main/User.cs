using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string firstName;
    public string lastName;
    public string birthDate;
    public string sex;

    public User()
    {
        firstName = AddPatient.firstName;
        lastName = AddPatient.lastName;
        birthDate = AddPatient.day + "-" + AddPatient.month + "-" + AddPatient.year;
        sex = AddPatient.sex;
    }
}
