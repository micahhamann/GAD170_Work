using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{

    public int randomNumber = 0;
    public float randomNumberFloat = 0f;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 10);
        randomNumberFloat = Random.Range(0.00f, 10.00f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
