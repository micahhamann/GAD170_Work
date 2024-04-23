using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{

    public bool isCharmander = false;
    public Material bulbasaur;
    public Material charmander;
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isCharmander)
            {
                isCharmander = false;
                meshRenderer.material = bulbasaur;
            }

            else
            {
                isCharmander = true;
                meshRenderer.material = charmander;
            }
        }
    }
}
