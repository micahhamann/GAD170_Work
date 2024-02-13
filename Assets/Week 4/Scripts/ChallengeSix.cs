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
        return 0;
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
    }
}
