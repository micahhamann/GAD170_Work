using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{

    public int myHealth = 0;
    public int myMaxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log((3f / 4f) * 100 + "%");
        myHealth -= 20;
        Debug.Log(((float)myHealth) / ((float)myMaxHealth) * 100 + "%");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
