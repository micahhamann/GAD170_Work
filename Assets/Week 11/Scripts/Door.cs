using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekEleven
{
    public class Door : MonoBehaviour
    {

        public Material materialToCheck;
        public Material playerStartMaterial;


        private void OnTriggerEnter(Collider other)
        {
            // check to see if it's the player entering the zone.
            if (other.GetComponent<PlayerMovement>())
            {

                // check to see if the player has the same colour material as the one needed for this door.
                // top do this first let's check to see if we can get a mesh render from the player
                SkinnedMeshRenderer renderer = null;

                // check to see if the render is not null
                if (renderer != null)
                {
                    // now let's check the color of the material of our renderer and compare it ot our material to check's color.
                    
                        // so now access the player's material through the renderer and change it back to it's starting material i.e. remove the blue.
                       
                        // if it's accepted destroy the door, so remember we are going to have to access the parent's gameobject but let's delay it by 1 second
                        
                    
                }
            }
        }

    }
}
