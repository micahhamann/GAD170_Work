using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour
{
    public GameObject smokeEffect;
    public AudioClip bombImpact;
    private ShadowCloneSpawner shadowCloneSpawner;

    private void Awake()
    {
        // here I want to get a reference to the shadow clone spawner in the scene.
        // as there's only one of them I could search the scene for it.
    }

    private void OnCollisionEnter(Collision collision)
    {
        // here I want to do a couple things.
        // spawn in the smoke effect so it looks cool, but I want to destroy the smoke clone after say 3 seconds.
        GameObject smokeClone = null;  
        // tell the clone maker to start spawning in clones of Naruto
        
        if(shadowCloneSpawner != null)
        {
            // here I want to call the call the spawn naruto clones, and pass in the first collision point the bomb hits as it's "orgin"
            shadowCloneSpawner.SpawnNarutoClones(collision.contacts[0].point);
        }

        // let's play a sound effect here, best to use the play clip at point function

        // then I want to destroy this game object to hide the bomb model.
    }
}
