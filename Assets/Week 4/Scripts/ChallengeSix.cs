using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChallengeSix : MonoBehaviour
{
    public float tempInFarenheit = 50; // use this to start with, if you get 10 degrees c, then your formula works.
    public float tempInCelcius = 0;
    public TextMeshProUGUI messageOutPut;
    public TextMeshProUGUI tempDisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartConversion();
    }

    public void StartConversion()
    {
        tempInCelcius = ConvertFahrenheitToCelcius(tempInFarenheit);
        PrintTemperatureMessage(tempInCelcius);
    }

    float ConvertFahrenheitToCelcius(float temperatureInFahrenheit)
    {
        Debug.Log(temperatureInFahrenheit);
        // the formula we want to use is (50°F − 32) × 5/9 = 10°C
        // hint, when you divide two ints, you get an int back.
        // hint, parenthesis will be your friend.
        return (temperatureInFahrenheit - 32)*(float)(5f / 9f);
    }

    void PrintTemperatureMessage(float celcius)
    {
        /*
         * let's do some add some more debugs and messages for the following
         *  Temp less than 0 then Freezing weather
            Temp 0-10 then Very Cold weather
            Temp 10-20
                If it’s below 13 or it’s exactly 14 debug it’s a bit cool.
                Otherwise it’s cold weather.
            Temp 20-30 then Normal in Temp
            Temp 30-40
                If it is below 35 debug out nice qld day
                Else if it’s below 37 but more than 35 debug out getting warmer.
                Else it’s hot.
            Temp greater than or equal 40 then Its Very Hot

         */
        Debug.Log("It is " + celcius + "°C.");
        tempDisplay.text = tempInFarenheit + "°F = " + Mathf.RoundToInt(celcius) + "°C";

        if (celcius < 0)
        {
            Debug.Log("It is freezing out there!");
            messageOutPut.text = "It is freezing out there!";
        }

        else if (celcius >= 0 && celcius <= 10)
        {
            Debug.Log("It is very cold.");
            messageOutPut.text = "It is very cold.";
        }

        else if (celcius > 10 && celcius <= 20)
        {
            if (celcius < 13 || celcius == 14)
            {
                Debug.Log("It's a bit cool.");
                messageOutPut.text = "It's a bit cool.";
            }

            else
            {
                Debug.Log("It's on the cold side.");
                messageOutPut.text = "It is mild weather.";
            }

        }

        else if (celcius > 20 && celcius <= 30)
        {
            Debug.Log("It is mild weather.");
            messageOutPut.text = "It is mild weather.";
        }

        else if (celcius > 30 && celcius <= 40)
        {
            if (celcius < 35)
            {
                Debug.Log("A nice Australian summer day.");
                messageOutPut.text = "A nice Australian summer day.";
            }

            else if(celcius >= 35 && celcius <= 37)
            {
                Debug.Log("Getting a bit warm.");
                messageOutPut.text = "Getting a bit warm.";
            }

            else
            {
                Debug.Log("It is hot out there!");
                messageOutPut.text = "It is hot out there!";
            }
        }

        else
        {
            Debug.Log("It is VERY hot. Stay inside!");
            messageOutPut.text = "It is VERY hot. Stay inside!";
        }
    }
}
