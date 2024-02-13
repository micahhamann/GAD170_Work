using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameMainMenu mainMenuReference;
    private void OnCollisionEnter(Collision collision)
    {
        // lets check the collision, for a script only the player has, perhaps player movement
        if(collision.transform.GetComponent<PlayerMovement>())
        {
            // we died, so lets call that game over function in our main menu reference
           
        }
    }
}
