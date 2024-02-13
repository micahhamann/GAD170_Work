using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{

    public string myName = "Micah Hamann";
    public int myAge = 25;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log("" + myAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
