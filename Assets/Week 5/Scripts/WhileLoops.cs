using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoops : MonoBehaviour
{
    int maxIterations = 10;

    // Start is called before the first frame update
    void Start()
    {
        int currentValue = 0;
        while(currentValue < maxIterations)
        {
            Debug.Log("Hello Nathan");
            currentValue += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
