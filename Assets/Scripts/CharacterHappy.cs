using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHappy : MonoBehaviour
{

    public bool isCharacterHappy = true;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome friend");

        if(isCharacterHappy == true)
        {
            Debug.Log("Glad to see you are smiling");
        }
        else
        {
            Debug.Log("Looks like you need a hug");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
