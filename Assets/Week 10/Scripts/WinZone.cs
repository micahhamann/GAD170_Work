using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{

    public GameMainMenu mainMenuReference;

    private void OnTriggerEnter(Collider other)
    {
        // check to see if the thing coming into the zone, has a script only the player might have perhaps player movement
        if (other.GetComponent<PlayerMovement>())
        {
            // winner, so lets call that load win screen function in our main menu reference
            
        }
    }

}
