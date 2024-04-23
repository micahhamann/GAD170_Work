using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public Animation playerAnimation;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {


        playerAnimation = collision.gameObject.GetComponent<Animation>();


    }
}
