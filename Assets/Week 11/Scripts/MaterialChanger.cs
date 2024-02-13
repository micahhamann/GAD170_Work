using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekEleven
{
    public class MaterialChanger : MonoBehaviour
    {

        public Material materialToChangeTo;

        private void OnCollisionEnter(Collision collision)
        {

            Debug.Log(collision.transform.name);
            // let's check the make sure it's the player hitting this
            if (collision.transform.GetComponent<PlayerMovement>())
            {
                Debug.Log("hit");
                // if it is, then let's search through it's children for a skin mesh renderer.
                // we can use a getcomponent in children for that
                SkinnedMeshRenderer renderer = null;

                if (renderer != null)
                {
                    // so if we get the render we'll want to access the material property and then change it to our new material
                    
                }
            }
        }
    }
}
