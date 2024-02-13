using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinGame coinGameManager;
    private CoinSpawner coinSpawner;
    [SerializeField] private AudioClip coinCollected;
    private Coroutine movementRoutine;
    [SerializeField] private float moveDistance;
    private float startPositionY;
    [SerializeField] private float moveSpeed = 1.5f;
    private Vector3 goalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // let's set the start pos y, to be our spawned in y position.
        startPositionY = transform.position.y;

        // here let's search the scene for the coin game script.
        coinGameManager = null;

        // lets also get a reference to our coin spawner;
        coinSpawner = null;

        // check to see if we have the reference for the coin spawner
        if(coinSpawner != null)
        {
            // then call the add coin function from the coinSpawner.
            // remember we can use this to refer to this instance.
            
        }

        // set the initial goal position to be out starting pos, + our y move distance
        goalPosition = transform.position + new Vector3(0, 0, 0);

        // check that a movement routine isn't already running.
        if (movementRoutine == null)
        {
            // store and start the movement routine
            movementRoutine = StartCoroutine(Movement());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // checking to make sure it's the player hitting this
        if (other.GetComponent<PlayerMovement>())
        {
            // here we should access our coin game script and call the add coin function
            // we should check if we have a reference i.e. not null before calling it though
            if (coinGameManager != null)
            {
              
            }

            // here lets play the audio clip of the coin being collected, again we might want to use play clip at point
           

            // here let's destroy the game object
            
        }
    }

    private void OnDestroy()
    {
        // lets check if the coin spawner has a reference
        if (coinSpawner != null)
        {
            // then let's tell it this coin is gone, so remove it.
            // again we'll want to pass in ourselves.
           
        }
    }

    IEnumerator Movement()
    {
        while (this.enabled)
        {
            // while the distance between the current pos, and the goal pos is greater than a threshold, keep moving.
            // the abs element here, is effectively removing any negative values, i.e. -3, would be treated as 3.
            while ( Mathf.Abs((Vector3.Distance(transform.position, goalPosition))) >= 0.1f)
            {
                // here we are going to lerp from the current pos, to the goal pos, by the movespeed
                transform.position = Vector3.Lerp(transform.position, goalPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // now I want to wait 0.5 seconds using the yield return wait for seconds, otherwise it'll just keeping goin up and down.
           

            // then i want to check if I'm currently going up, I want to switch to going down.
            // else i want to go the other way i.e. down going up
            if (transform.position.y >= startPositionY)
            {
                // I want to set my goal position to be my curent position, minus the move distance of the y.
                // this is the opposite of what i did in start.
                goalPosition = transform.position + new Vector3(0, -moveDistance, 0);
            }
            else 
            {
                // other wise, I must be back at my starting position and so want to set my goal to be my current pos + the move distance on the y.
                goalPosition = transform.position + new Vector3(0, moveDistance, 0);
            }
            yield return null;
        }

        yield return null;
    }


  
}
