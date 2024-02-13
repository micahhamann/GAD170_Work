using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekTwelve
{
    public class WinZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // check to see if the thing coming into the zone, has a script only the player might have perhaps player movement
            if (other.GetComponent<PlayerMovement>())
            {
                // here let's invoke the GameCompletedEvent from our coin game events.
               
            }
        }

    }
}