using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Transform spawnPoint;



    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Killed by snowball");
            GameManager3.instance.NewTurn(spawnPoint.position);
        }
    }

}
