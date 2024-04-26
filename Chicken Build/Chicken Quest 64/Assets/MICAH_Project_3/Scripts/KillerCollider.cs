using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCollider : MonoBehaviour
{
    public Transform respawnPoint; //reference to respawn point

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint")?.transform;
    }


    //Trigger respawn/death function when hit by obstacle game object
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponentInParent<Animation>().Stop(); //Stop turning obstacle to help identify what killed the player
            Debug.Log("Killed by obstacle");
            GameManager3.instance.NewTurn(respawnPoint.position);
        }
        


    }
}
