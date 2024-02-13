using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// So this class holds all the information for my variables activity
/// </summary>

public class Variables : MonoBehaviour
{
    #region code neatness tutorial
    [Tooltip("This Bool Holds true or false")]
    public bool myFirstBool = true;

    [Header("Movement Related Variables")]
    public bool mySecondBool = false;
    #endregion

    public int myfirstInt = 1; // an int can only hold whole numbers
    private float myHeight = 176.54f; // a float holds decimal numbers
    public double myFaveNumber = 157.45; // a double holds double a float!
    public string myName = "Micah"; // a string can only hold words
    public char myInitial = 'S'; // a char can only hold a single character
    public bool isWearingAWatch = false; // a bool can only hold true or false

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
