using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcManager : MonoBehaviour
{

    /*
     * so in this script, what we want to do is to have 3 orcs in our scene, and
     * have this script be able to tell them what to do, i.e. setting up some starting stats.
     * Then we want to do a kind of battle, until there is only one orc left alive.
     * we are basically re-creating the first brief, but using multiple scripts :).
     * This is good practice to improve on what you did in brief one, making it more organised.
     *  Bonus, determine an overall winner i.e. when 1 orc is left alive tell me which one.
     */

    public GameObject orcPrefab;
    public Orc firstOrc;

    // Start is called before the first frame update
    void Start()
    {
        // I've done the first orc, we need two more.
        // we can re-use same prefab, but we need a new orc reference for each one.
        GameObject orcClone = Instantiate(orcPrefab);
        firstOrc = orcClone.GetComponent<Orc>();

        // we've got one orc set up...but there are 2 more, we might need more references.
        firstOrc.Setup();
    }

    private void Update()
    {
        // when we press space bar
            // here let's pseudo randomly pick 2 orcs out of 3.
            // you probably should check to see if we have references to the orcs i.e. if(firstOrc !=null && other orc), if this is false, debug out to press again.
                // then let's have them "attack" each other, i.e. we want this attack damage to hurt the other
                // we can call the take damage function
        if(firstOrc != null)
        {
           // firstOrc.TakeDamage(-5);
        }
                
    }
}
