using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeOne : MonoBehaviour
{
    /*
     * Write some code to do the following:
     * Variables to hold:
        * Your name
        * Your age in years.
        * Your height (to two decimal points).
        * If you're wearing a watch.
        * Your favourite number.
     *Debug out the following sentences and fill in the blanks using your variables:
        * "Hi my name is: ____"
        * "My age is:_____"
        * "I am ___ centimeters tall"
        * "The rumours going around that I am wearing a watch are: ___"
        * "My favourite number is___"
        * "If my age was added to my favourite number, and subtracted my height it would give me ____."
    */

    private string myName = "Micah";
    private int myAge = 25;
    private float myHeight = 176.54f;
    private bool ifWearingWatch = true;
    private int myFavouriteNumber = 57;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi my name is " + myName);
        Debug.Log("My age is: " + myAge);
        Debug.Log("I am " + myHeight + " centermeters tall");
        Debug.Log("The rumours going around that I am wearing a watch are " + ifWearingWatch);
        Debug.Log("My favourite number is " + myFavouriteNumber);
        Debug.Log("If my age was added to my favourite number, and subtracted my height it would give me " + (myAge + myFavouriteNumber - myHeight));
    }
}