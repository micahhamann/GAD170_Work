using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekTwelve
{
    public class DeadZone : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // lets check the collision, for a script only the player has, perhaps player movement
            if (collision.transform.GetComponent<PlayerMovement>())
            {
                // here let's invoke the game over event from our coin game events.
                
            }
        }
    }
}