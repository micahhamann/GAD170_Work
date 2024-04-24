using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCollider : MonoBehaviour
{
    public Transform respawnPoint;
    public string deathType = "Death";

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint")?.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponentInParent<Animation>().Stop();
            Debug.Log("Killed by obstacle");
            GameManager3.instance.NewTurn(respawnPoint.position, deathType);
        }
        


    }
}
