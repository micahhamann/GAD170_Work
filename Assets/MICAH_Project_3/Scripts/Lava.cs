using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public GameObject respawnPoint;
    public string deathType = "Death";


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Triggered");

        if (other.CompareTag("Player"))
        {

            GameManager3.instance.NewTurn(respawnPoint.transform.position, deathType);
        }

    }

}
