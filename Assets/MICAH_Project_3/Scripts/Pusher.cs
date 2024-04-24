using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public PlayerMovementNew playerRB;
    public float pushForce = 10;
    public Vector3 pushDirection;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            ContactPoint contact = collision.contacts[0]; // Assuming only one contact point
            Vector3 contactPoint = contact.point;
            Vector3 contactNormal = contact.normal;
            pushDirection = -contactNormal;

            playerRB = collision.gameObject.GetComponent<PlayerMovementNew>();

            if (playerRB != null)
            {
                playerRB.Push(pushForce, pushDirection);
            }
        }


    }
}
