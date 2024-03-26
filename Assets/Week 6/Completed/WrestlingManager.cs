using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.Completed
{
    public class WrestlingManager : MonoBehaviour
    {
        public GameObject wrestlerPrefab;
        public int numberOfWrestlers = 5;
        public List<Material> allMaterials = new List<Material>();
        public List<Wrestler> allWrestlersSpawned = new List<Wrestler>();

        // We need some lists for a collection of names for firstNames, lastNames and wrestling names
        public List<string> firstNames = new List<string>();
        public List<string> lastNames = new List<string>();
        public List<string> wrestlerNames = new List<string>();

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

        // we should add some names to our first names, last names, and wrestling names lists so we can pull from the list later
        void AddNames()
        {
            firstNames.Add("Nathan");
            firstNames.Add("Barry");
            firstNames.Add("Bruce");
            firstNames.Add("Tony");
            firstNames.Add("Clint");

            lastNames.Add("Jensen");
            lastNames.Add("Allen");
            lastNames.Add("Wayne");
            lastNames.Add("Stark");
            lastNames.Add("Barton");

            wrestlerNames.Add("The Lecturer");
            wrestlerNames.Add("The Flash");
            wrestlerNames.Add("Batman");
            wrestlerNames.Add("Ironman");
            wrestlerNames.Add("Hawkeye");
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
            float x = Random.Range(-10f,10f);
            float y = Random.Range(-10f, 10f);
            float z = Random.Range(-10f, 10f);

            GameObject clone = Instantiate(wrestlerPrefab, new Vector3(x, y, z), Quaternion.identity);

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

            // now before we finish up  let's assign a random colour to the clone's renderer, we are going
            // to need a reference to that.
            MeshRenderer clonesMesh = clone.GetComponent<MeshRenderer>();

            // now let's assign a random colour to it, using clonesMesh.material = random material from our list.
            // right now it's always the same
            clonesMesh.material = allMaterials[Random.Range(0,allMaterials.Count)];
        }

        private void SetWrestlerName(Wrestler wrestler)
        {
            // instead of blanks,instead let's grab a random name from our lists.
            string firstName = firstNames[Random.Range(0, firstNames.Count)];
            string lastName = lastNames[Random.Range(0, lastNames.Count)];
            string wrestlingName = wrestlerNames[Random.Range(0, wrestlerNames.Count)];

            // once we have our random names, let's access our wrestler and set the first,last and wrestling name of that wrestler to the names
            // we got randomly above.
            wrestler.firstName = firstName;
            wrestler.lastName = lastName;
            wrestler.wrestlingName = wrestlingName;

            // if you want to get really fancy and want a challenge, try only allowing a name to be used once.
            firstNames.Remove(firstName);
            lastNames.Remove(lastName);
            wrestlerNames.Remove(wrestlingName);
        }

        void DestroyAllWrestlers()
        {
            // we should loop through all the wrestlers and use Destroy() on each.
            // we should also clear out our allspawned wrestlers list once we destroy all of them, otherwise we'll have null in our list.
            for (int i = 0; i < allWrestlersSpawned.Count; i++)
            {
                Destroy(allWrestlersSpawned[i].gameObject);
            }

            allWrestlersSpawned.Clear();
        }
    }
}