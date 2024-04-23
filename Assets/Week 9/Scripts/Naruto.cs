using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naruto : MonoBehaviour
{
    private ShadowCloneSpawner cloneSpawner;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        // we want to do a couple of things here.
        // first we need a reference to our shadow clone spawner, cause we want to keep track of this clone.
        cloneSpawner = FindObjectOfType<ShadowCloneSpawner>();

        // from here we then want to call the add Naruto. remember this function will get called when the clone is "spawned" in
        if (cloneSpawner != null)
        {

            cloneSpawner.AddNaruto(this);
            // the trick with the add naruto function is it's asking for a reference to this particular clone.
            // you can use the this keyword to refer to itself.
            
        }

        // here we want to call the destroy function but give it a delay of a random number between 2-7
        Destroy(gameObject, Random.Range(2f, 7f));
    }
    
    // this is a Unity specific function, that is called when the gameobject is destroyed.
    private void OnDestroy()
    {
        // here we want to use our reference to our clone spawner to remove us from our list.
        // that way we keep our list clean!
        if (cloneSpawner != null)
        {

            cloneSpawner.RemoveNaruto(this);
            // the trick with the remove naruto function is it's asking for a reference to this particular clone.
            // you can use the this keyword to refer to itself.
           
        }

        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        // lets play our "death sound" again probably best to use play clip at point.
    }
}
