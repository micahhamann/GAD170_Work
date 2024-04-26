using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{

    public PlayerMovementNew player;
    public float bounceForce = 10;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            //Get reference to player script through collision
            player = collision.gameObject.GetComponent<PlayerMovementNew>();

            if (player != null)
            {
                AudioManager3.instance.PlaySoundFX("boing");
                player.Bounce(bounceForce); //Apply upwards force depending on bounceForce variable
            }
        }

          
    }
}
