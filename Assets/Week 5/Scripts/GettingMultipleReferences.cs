using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingMultipleReferences : MonoBehaviour
{

    public List<Collider> allColliders = new List<Collider>();

    public GameObject cubeReference;
    public BoxCollider[] allCollidersOnCube; 

    // Start is called before the first frame update
    void Start()
    {
        Collider[] allCollidersFound = FindObjectsOfType<Collider>();

        for (int i = 0; i < allCollidersFound.Length; i++)
        {
            Debug.Log(allCollidersFound[i].name);
        }

        // adds all the colliders to an array
        allColliders.AddRange(allCollidersFound);

        allCollidersOnCube = GetComponentsInChildren<BoxCollider>(); // will search parent and then all children for components
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
