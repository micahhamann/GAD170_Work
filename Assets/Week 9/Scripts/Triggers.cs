using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Could be goal volume
        //lavaand do damamge while in trigger box


        Debug.Log(other.transform.name);

        if (other.transform.GetComponent<Orc2>())
        {
            other.transform.GetComponent<Orc2>().myName = "triggered";
        }

        //particle effects
        //play sounds

        Debug.Log("On Trigger Called.");

        if(other.transform.tag == "Player")
        {
            //do code
            //is case sensitive
        }
    }
}
