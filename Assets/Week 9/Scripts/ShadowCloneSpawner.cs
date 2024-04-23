using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCloneSpawner : MonoBehaviour
{
    public int numberOfShadowClones = 10;
    public GameObject narutoPrefab;
    public List<Naruto> allNarutosClones = new List<Naruto>();


    public void SpawnNarutoClones(Vector3 hitPoint)
    {
        // here I want to spawn in the amount of clones based on the variable numberOfShadowClones
  
        for (int i = 0; i < numberOfShadowClones; i++)
        {
            // I also want to spawn them in with some randomness to their spawn position.
            float x = hitPoint.x + Random.Range(-10, 10);
            float y = hitPoint.y + Random.Range(-10, 10);
            float z = hitPoint.z + Random.Range(-10, 10);

            // call the spawn function
            SpawnNaruto(new Vector3(x, y, z));
        }
    }

    private void SpawnNaruto(Vector3 spawnPoint)
    {
        // spawn in the naruto prefab using the spawn point.
        Instantiate(narutoPrefab, spawnPoint, narutoPrefab.transform.rotation);
    }

    public void AddNaruto(Naruto clone)
    {
        // add the clone coming in to the list of all.
        allNarutosClones.Add(clone);
       
    }

    public void RemoveNaruto(Naruto clone)
    {
        // remove the clone coming in, from the list of all.
        allNarutosClones.Remove(clone);
        
    }
}
