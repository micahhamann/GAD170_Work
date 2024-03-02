using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access the UI library

public class Buttons : MonoBehaviour
{

    
    public void PrintMyName()
    {
        Debug.Log("Micah");
    }

    public void HealButtonIsPressed()
    {
        Debug.Log(Battle.playerHealth);
    }

    public void AttackButtonIsPressed()
    {

    }

    public void WhackButtonIsPressed()
    {

    }

    public void DodgeButtonIsPressed()
    {

    }
}
