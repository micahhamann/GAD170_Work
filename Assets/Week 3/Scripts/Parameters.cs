using UnityEngine;
using System.Collections;

public class Parameters : MonoBehaviour
{

    public string firstName = "Micah";
    public string secondName = "Hamann";

    // Use this for initialization
    void Start()
    {
        PrintMyName(firstName, secondName);

    }

    
    public void PrintMyName(string nameOne, string nameTwo)
    {
        Debug.Log(nameOne + " " + nameTwo);
    }
}
