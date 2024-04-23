using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public GameObject respawnPoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Triggered");

        if(other.CompareTag("Player"))
        {
            Debug.Log("Moving player to respawn point");
            Debug.Log("Respawn Point Position: " + respawnPoint.transform.position);

            other.transform.position = respawnPoint.transform.position;

            Debug.Log("Current position is" + other.transform.position);

        
        }
                
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(player != null)
            {
                player.transform.position = respawnPoint.transform.position;
            }

           else
            {
                Debug.Log("why tho..");

            }
        }
    }

}
