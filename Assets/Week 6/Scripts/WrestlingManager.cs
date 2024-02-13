using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrestlingManager : MonoBehaviour
{
    public GameObject wrestlerPrefab;
    public int numberOfWrestlers = 5;
    public List<Material> allMaterials = new List<Material>();
    public List<Wrestler> allWrestlersSpawned = new List<Wrestler>();

    // We need some lists for a collection of names for firstNames, lastNames and wrestling names

    // Start is called before the first frame update
    void Start()
    {
        AddNames();
        SpawnAllWrestlers();   
    }

    private void Update()
    {
        // here let's add in the ability to press space bar, and then call our DestroyAllWrestlers() function
    }

    // we should add some names to our first names, last names, and nick names lists so we can pull from the list later
    void AddNames()
    {
        
    }

    void SpawnAllWrestlers()
    {
        // instead of doing this once...let's change this to be the number of wrestlers
        for (int i = 0; i < 1; i++)
        {
            SpawnWrestler();
        }
    }

    private void SpawnWrestler()
    {
        // set these to random values between -10 and 10
        float x = 0;
        float y = 0;
        float z = 0;

        GameObject clone = Instantiate(wrestlerPrefab,new Vector3(x,y,z),Quaternion.identity);

        // using the clone reference, use get component to get the Wrestler Script that's on the object we spawned in.
        Wrestler wrestlerReference = null;

        // check to see it's null
        if (wrestlerReference != null)
        {
            // now we are adding the reference to the list.
            

            // you'll want to set the wrestlers name too.
            SetWrestlerName(wrestlerReference);
        }

        // now before we finish up  let's assign a random colour to the clone's mesh renderer, we are going
        // to need a reference to that.
        MeshRenderer clonesMesh = null;

        // now let's assign a random colour to it, using clonesMesh.material = random material from our list.
        // right now it's always the same
        if (clonesMesh != null)
        {
            clonesMesh.material = allMaterials[0];
        }
    }

    private void SetWrestlerName(Wrestler wrestler)
    {
        // instead of blanks,instead let's grab a random name from our lists.
        string firstName = "";
        string lastName = "";
        string wrestlingName = "";
        
        // once we have our random names, let's access our wrestler and set the first,last and wrestling name of that wrestler to the names
        // we got randomly above.

        // if you want to get really fancy and want a challenge, try only allowing a name to be used once.

    }

    void DestroyAllWrestlers()
    {
        // we should loop through all the wrestlers and use Destroy() on each.
        // we should also clear out our allspawned wrestlers list once we destroy all of them, otherwise we'll have null in our list.
    }
}
