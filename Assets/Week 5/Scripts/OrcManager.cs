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
    public Orc secondOrc;
    public Orc thirdOrc;

    // Start is called before the first frame update
    void Start()
    {
        // I've done the first orc, we need two more.
        // we can re-use same prefab, but we need a new orc reference for each one.
      
        GameObject orcClone = Instantiate(orcPrefab);
        firstOrc = orcClone.GetComponent<Orc>();
        GameObject orcCloneTwo = Instantiate(orcPrefab);
        secondOrc = orcCloneTwo.GetComponent<Orc>();
        GameObject orcCloneThree = Instantiate(orcPrefab);
        thirdOrc = orcCloneThree.GetComponent<Orc>();

        // we've got one orc set up...but there are 2 more, we might need more references.
        firstOrc.Setup();
        secondOrc.Setup();
        thirdOrc.Setup();
    }

    private void Update()
    {
        // when we press space bar
        // here let's pseudo randomly pick 2 orcs out of 3.
        // you probably should check to see if we have references to the orcs i.e. if(firstOrc !=null && other orc), if this is false, debug out to press again.
        // then let's have them "attack" each other, i.e. we want this attack damage to hurt the other
        // we can call the take damage function

        int pickFighter = Random.Range(0, 3);

        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (pickFighter == 0)
            {
                if (firstOrc != null && secondOrc != null)
                {

                    firstOrc.TakeDamage(secondOrc.orcStrength);
                    secondOrc.TakeDamage(firstOrc.orcStrength);
                }

                else
                {
                    Debug.Log("Press SPACEBAR again\n\n");
                }

            }

            if (pickFighter == 1)
            {
                if (secondOrc != null && thirdOrc != null)
                {
                    secondOrc.TakeDamage(thirdOrc.orcStrength);
                    thirdOrc.TakeDamage(secondOrc.orcStrength);
                }

                else
                {
                    Debug.Log("Press SPACEBAR again\n\n");
                }
            }

            if (pickFighter == 2)
            {
                if (firstOrc != null && thirdOrc != null)
                {
                    firstOrc.TakeDamage(thirdOrc.orcStrength);
                    thirdOrc.TakeDamage(firstOrc.orcStrength);
                }

                else
                {
                    Debug.Log("Press SPACEBAR again\n\n");
                }
            }
            
        }

       if (firstOrc == null && secondOrc == null && thirdOrc != null)
        {
            Debug.Log(thirdOrc.orcName + " is the WINNER!\n\n");
            Destroy(thirdOrc);
        }

       else if (secondOrc == null && thirdOrc == null && firstOrc != null)
        {
            Debug.Log(firstOrc.orcName + " is the WINNER!\n\n");
            Destroy(firstOrc);
        }

       else if (thirdOrc == null && firstOrc == null && secondOrc != null)
        {
            Debug.Log(secondOrc.orcName + " is the WINNER!\n\n");
            Destroy(secondOrc);
        }
                
    }
}
