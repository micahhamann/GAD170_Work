using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekEleven
{
    public class WinZone : MonoBehaviour
    {

        public List<ParticleSystem> winEffects = new List<ParticleSystem>();

        private void Start()
        {
            // let's start by turning the win effects off.
        }

        private void OnTriggerEnter(Collider other)
        {
            // check to see if the thing coming into the zone, has a script only the player might have perhaps player movement
            if (other.GetComponent<PlayerMovement>())
            {
                // then let's access the win function of the player movement, to trigger a win animation
               

                // let's turn the win effects on.

                // then destroy this gameobject
  
            }
        }

        private void TriggerWinEffects(bool enabled)
        {
            // we have a list of particle effects, let's loop through our list and call play or stop on each based on the enabled bool.

                // if the enabled bool is true, then play the effect, else we should call stop

        }

    }
}
