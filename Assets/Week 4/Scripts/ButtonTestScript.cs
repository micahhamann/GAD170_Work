using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ButtonTestScript : MonoBehaviour
{
    public int timesPressed = 0;
    
    public TextMeshProUGUI buttonText;
    public void MicahButtonOnClick()
    {
        timesPressed++;
        if( timesPressed == 1) 
        {
            buttonText.text = "Bad boy";
        }

        else if (timesPressed == 2)
        {
            buttonText.text = "Don't do it!";
        }
        
        else if (timesPressed == 3)
        {
            buttonText.text = "Stooop Plz!";
        }
        
        else if (timesPressed == 4)
        {
            buttonText.text = "You jerk";
        }

        else
        {
            buttonText.text = ("Ahhh");
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
