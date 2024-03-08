using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject enemyPreFab;
    public List<Enemy> allEnemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //creating variables to store position coordinates
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);
            float z = Random.Range(-10f, 10f);

            //creating a variable to store Vector3 information
            Vector3 spawnPosition = new Vector3(x, y, z);

            //Create local variable to store game object clone reference
            GameObject clone = Instantiate(enemyPreFab,spawnPosition, Quaternion.identity);

            //Add the enemy spawn clone to the enemy list. Finding an instance of the Enemy Class
            allEnemies.Add(clone.GetComponent<Enemy>());
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < allEnemies.Count; i++)
            {
                allEnemies[i].TakeDamage(20);
            }
        }
    }

    //Create a public function to passthrough Enemy instance and remove from list
    public void RemoveEnemyFromList(Enemy enemytoremove)
    {
        allEnemies.Remove(enemytoremove);
    }
}
