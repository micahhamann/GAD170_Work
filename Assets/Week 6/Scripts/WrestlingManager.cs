using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrestlingManager : MonoBehaviour
{
    public GameObject wrestlerPrefab;
    public int numberOfWrestlers = 5;
    public List<Material> allMaterials = new List<Material>();
    public List<Wrestler> allWrestlersSpawned = new List<Wrestler>();
    public List<string> firstNameList = new List<string>();
    public List<string> lastNameList = new List<string>();
    public List<string> nickNameList = new List<string>();

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DestroyAllWrestlers();
        }
    }

    // we should add some names to our first names, last names, and nick names lists so we can pull from the list later
    void AddNames()
    {
        firstNameList.Add("Gavin");
        firstNameList.Add("Sarah");
        firstNameList.Add("Tim");
        firstNameList.Add("Brenton");
        firstNameList.Add("Tiffany");

        lastNameList.Add("Johnson");
        lastNameList.Add("Kramer");
        lastNameList.Add("Clark");
        lastNameList.Add("Lawson");
        lastNameList.Add("Davidson");

        nickNameList.Add("The Destroyer");
        nickNameList.Add("Face Muncher");
        nickNameList.Add("The Enlightened One");
        nickNameList.Add("Big D Energy");
        nickNameList.Add("Wild Eyes");
    }

    void SpawnAllWrestlers()
    {
        // instead of doing this once...let's change this to be the number of wrestlers
        for (int i = 0; i < numberOfWrestlers; i++)
        {
            SpawnWrestler();
        }
    }

    private void SpawnWrestler()
    {
        // set these to random values between -10 and 10
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);

        GameObject clone = Instantiate(wrestlerPrefab,new Vector3(x,y,z),Quaternion.identity);

        // using the clone reference, use get component to get the Wrestler Script that's on the object we spawned in.
        Wrestler wrestlerReference = clone.GetComponent<Wrestler>();

        // check to see it's null
        if (wrestlerReference != null)
        {
            // now we are adding the reference to the list.
            allWrestlersSpawned.Add(wrestlerReference);

            // you'll want to set the wrestlers name too.
            SetWrestlerName(wrestlerReference);
        }

        // now before we finish up  let's assign a random colour to the clone's mesh renderer, we are going
        // to need a reference to that.
        MeshRenderer clonesMesh = clone.GetComponent<MeshRenderer>();

        // now let's assign a random colour to it, using clonesMesh.material = random material from our list.
        // right now it's always the same
        if (clonesMesh != null)
        {
            clonesMesh.material = allMaterials[Random.Range(0, allMaterials.Count)];
        }
    }

    private void SetWrestlerName(Wrestler wrestler)
    {
        // instead of blanks,instead let's grab a random name from our lists.
        string firstName = firstNameList[Random.Range(0, firstNameList.Count)];
        string lastName = lastNameList[Random.Range(0, lastNameList.Count)];
        string wrestlingName = nickNameList[Random.Range(0, nickNameList.Count)];

        // once we have our random names, let's access our wrestler and set the first,last and wrestling name of that wrestler to the names
        // we got randomly above.

        wrestler.firstName = firstName;
        wrestler.lastName = lastName;
        wrestler.wrestlingName = wrestlingName;

        firstNameList.Remove(firstName);
        lastNameList.Remove(lastName);
        nickNameList.Remove(wrestlingName);


        // if you want to get really fancy and want a challenge, try only allowing a name to be used once.

    }

    void DestroyAllWrestlers()
    {
        // we should loop through all the wrestlers and use Destroy() on each.

        for (int i = 0; i < allWrestlersSpawned.Count; i++)
        {
            Destroy(allWrestlersSpawned[i].gameObject);
        }

        allWrestlersSpawned.Clear();
        // we should also clear out our allspawned wrestlers list once we destroy all of them, otherwise we'll have null in our list.
    }
}
