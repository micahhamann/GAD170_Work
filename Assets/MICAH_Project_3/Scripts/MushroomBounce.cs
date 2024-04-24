using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{

    public PlayerMovementNew playerRB;
    public float bounceForce = 10;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {

            playerRB = collision.gameObject.GetComponent<PlayerMovementNew>();

            if (playerRB != null)
            {
                playerRB.Bounce(bounceForce);
            }
        }

          
    }
}
