using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningGameObjectsOnAndOff : MonoBehaviour
{

    public MeshRenderer[] allMeshes;
    public List<GameObject> allShapes = new List<GameObject>();
    public List<MeshRenderer> allMeshList = new List<MeshRenderer>();



    // Start is called before the first frame update
    void Start()
    {

        allShapes.AddRange(FindObjectsOfType<GameObject>());

        for (int i = 0; i < allShapes.Count; i++)
        {
            allShapes[i].SetActive(true);
        }

        allMeshes = FindObjectsOfType<MeshRenderer>();

        for (int i = 0; i < allShapes.Count; i++)
        {
            allShapes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < allShapes.Count; i++)
            {
                allShapes[i].SetActive(true);
                allMeshList.Add(allShapes[i].GetComponent<MeshRenderer>());
            }

            for (int i = 0; i < allMeshes.Length; i++)
            {
                allMeshes[i].enabled = false;
            }
        }
    }
}
