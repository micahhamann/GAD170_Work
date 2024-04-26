using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMushroom : MonoBehaviour
{
 
    public Animator mushroomCap;  // Reference to the mushroom cap (the object interacting with the player)


    private bool playerOnMushroom = false;


    void Start()
    {
        mushroomCap = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerOnMushroom)
        {
            mushroomCap.SetBool("isPlayerOnMushroom", true);
        }
        else
        {
            mushroomCap.SetBool("isPlayerOnMushroom", false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touching");

        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnMushroom = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnMushroom = false;
        }
    }

}