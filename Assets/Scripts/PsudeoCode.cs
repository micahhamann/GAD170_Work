using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsudeoCode : MonoBehaviour
{

    // physical stats needed strength, agility, intel
    public int strength;
    public int agility;
    public int intelligence;
     
    // Start is called before the first frame update
    void Start()
    {

        // physical stats gets some random nummbers
        strength = Random.Range(0, 10);

        // physical stats get converted into dancing stats

        // print out the values of stats
        Debug.Log("strength is: " + strength);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
