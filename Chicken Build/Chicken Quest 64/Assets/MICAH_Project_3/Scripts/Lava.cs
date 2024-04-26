using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public GameObject respawnPoint;

    //When player hits the lava, trigger the respawn/death sequence
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Triggered");

        if (other.CompareTag("Player"))
        {

            AudioManager3.instance.PlaySoundFX("lava");
            GameManager3.instance.NewTurn(respawnPoint.transform.position);
        }

    }

}
