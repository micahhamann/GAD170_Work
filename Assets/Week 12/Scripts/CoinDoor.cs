using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.GAD170.WeekTwelve
{
    public class CoinDoor : MonoBehaviour
    {
        private bool playerInRange;
        [SerializeField] private int coinsNeeded = 5;
        private Coroutine coinCheckerRoutine;
        private int playerCoinsTotal = 0;

        private void OnEnable()
        {
            // here we are going to be cheeky, we are going to subscribe to the function that updates
            // the players coin total on their UI, and steal the total amount on the screen.
            // to do this we want to subscribe our UpdateLocalPlayerCoinCount to our UpdatePlayerCoinValueEvent.
           
        }


        private void OnDisable()
        {
            // here we want to unsub our Update Local player coin count function from the update player coin value event.
            

            coinCheckerRoutine = null;
        }

        private void Start()
        {
            // lets start by setting the player in range to false by default
            

            // lets also set the coin ui text to be the current value of the coins needed.
            

            if (coinCheckerRoutine == null)
            {
                coinCheckerRoutine = StartCoroutine(CoinChecker());
            }
        }  

        void UpdateLocalPlayerCoinCount(int amount)
        {
            // here have our playercoinstotal equal our amount coming in.
            
        }

        private IEnumerator CoinChecker()
        {
            while (this.enabled)
            {
                // if the player is in range, then let's check if they've also pressed the E button.
                // let's also check that we haven't already "opened the door" so check if coins are still needed
                if (playerInRange == true && Input.GetKey(KeyCode.E))
                {
                    // we should also check that we've collected any coins too so let's use that has coins function from our coin game
                    if (PlayerHasCoins())
                    {
                        // let's invoke our ChangeCoinAmountEvent and pass in -1
                       
                        // then let's remove a coin from our coins needed
                        
                        // then let's update the amount of coins we have to the Ui of our door.
                        

                        // we should then check if that's the last coin needed.
                        // if it is the last one needed, destroy this door to clear the way.
                        
                            // here we need to get the parent, as this trigger volume is a child of the door.
                            // so getting the parent transform, then getting the gameobject of it means we can destroy it.
                            Destroy(transform.parent.gameObject);
                        
                        // then let's wait a second.
                        yield return new WaitForSeconds(1);
                    }
                }
                yield return null;
            }
        }

        private bool PlayerHasCoins()
        {
            // here we want to do what we use to do in our coingame script, but instead, we want to return
            // true or false, if our playerCoinsTotal has coins or not.
            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            // here let's check if the thing coming into this zone has a script only the player has, say their movement script.
            if (other.GetComponent<PlayerMovement>())
            {
                // then if so set the player in range to true!
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // here let's check if the thing coming into this zone has a script only the player has, say their movement script.
            if (other.GetComponent<PlayerMovement>())
            {
                // then if so set the player in range to false!
               
            }
        }
    }
}
