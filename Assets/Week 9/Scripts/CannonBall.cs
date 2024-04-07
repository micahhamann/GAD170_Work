using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private List<GameObject> allThingsTouching = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allThingsTouching.Count; i++) //this is a more effective way to run code whilst objects are touching
        {
            //do some code
        }
    }

    private void OnCollisionEnter(Collision objectIHit)
    {
        Debug.Log("I hit: " + objectIHit.transform.name);

        if (objectIHit.transform.GetComponent<Orc2>()) //check if object has certain script
        {
            objectIHit.transform.GetComponent<Orc2>().myName = "damaged"; //can do what you want to the object your hit
        }

        if(objectIHit.gameObject.tag == "Floor") //Check if object hit has floor tag
        {
            Debug.Log("I hit the floor");
        }

        allThingsTouching.Add(objectIHit.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        //occers on the first frame object is no longer touching
        allThingsTouching.Remove(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        //occurs whilst the collision is still occuring
        //doesn't check every frame.  Only evey fixed update.
        //Very processor heavy and memory heavy
    }
}
