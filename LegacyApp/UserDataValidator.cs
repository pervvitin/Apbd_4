using System;

namespace LegacyApp;

public class UserDataValidator
{
    static public bool firstNameIsValid(string firstName)
    {

        return !string.IsNullOrEmpty(firstName);
    }
    static public bool lastNameIsValid(string lastName)
    {

        return !string.IsNullOrEmpty(lastName);
    }
    static public bool ageIsValid(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;

    }
    static public bool emailIsValid(string email)
    {

        return email.Contains("@") && email.Contains(".");
    }

    static public bool userDataIsValid(string firstName, string lastName, DateTime dateOfBirth, string email)
    {
        return firstNameIsValid(firstName) && lastNameIsValid(lastName) && ageIsValid(dateOfBirth) &&
               emailIsValid(email);
    }
}