using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDoor : MonoBehaviour
{
    private bool playerInRange;
    private CoinGame coinGame;

    [SerializeField] private int coinsNeeded = 5;
    [SerializeField] private TextMeshProUGUI coinUIText;

    private Coroutine coinCheckerRoutine;

    private void Start()
    {
        // lets start by setting the player in range to false by default
      
        // lets find a reference to the coin game script
        

        // lets also set the coin ui text to be the current value of the coins needed.
     

        if(coinCheckerRoutine == null)
        {
            coinCheckerRoutine = StartCoroutine(CoinChecker());
        }
    }

    private void OnDisable()
    {
        coinCheckerRoutine = null;
    }

    private IEnumerator CoinChecker()
    {
        while(this.enabled)
        {
            // if the player is in range, then let's check if they've also pressed the E button.
            // let's also check that we haven't already "opened the door" so check if coins are still needed
            if (playerInRange == true && Input.GetKey(KeyCode.E))
            {
                // we should also check that we've collected any coins too so let's use that has coins function from our coin game
                if (coinGame != null && coinGame.HasCoins())
                {
                    // then let's remove a coin from the amount of coins collected in our coin game.
                    
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

    private void OnTriggerEnter(Collider other)
    {
        // here let's check if the thing coming into this zone has a script only the player has, say their movement script.
        if(other.GetComponent<PlayerMovement>())
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
