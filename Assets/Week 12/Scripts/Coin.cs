using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekTwelve
{
    public class Coin : MonoBehaviour
    {
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

            //here let's invoke the Coinspawner Event to let it know that our coin has been spawned and pass itself into the event invocation
            

            // set the initial goal position to be out starting pos, + our y move distance
            goalPosition = transform.position + new Vector3(0, moveDistance, 0);

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
                // here let's invoke our coin change amount event, and pass in the value of the coin i.e. one.
                

                // here lets play the audio clip of the coin being collected, again we might want to use play clip at point
                

                // here let's destroy the game object
                
            }
        }

        private void OnDestroy()
        {
            // so here let's Invoke our despawn event from the coin game events script don't forget to pass in ourself.
            
        }

        IEnumerator Movement()
        {
            while (this.enabled)
            {
                // while the distance between the current pos, and the goal pos is greater than a threshold, keep moving.
                // the abs element here, is effectively removing any negative values, i.e. -3, would be treated as 3.
                while (Mathf.Abs((Vector3.Distance(transform.position, goalPosition))) >= 0.1f)
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
}
