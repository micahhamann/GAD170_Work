using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinGame : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI playerCoinText;

    // Start is called before the first frame update
    void Start()
    {
        // set our current coins collected to 0
        
        // then update the player text to show these coins.
        
    }

    public void AddCoin()
    {
        // increase our coin count by one.
        
        // we should update our UI to match this too.

    }

    public void RemoveCoins()
    {
        // decrease our coins by one.

        // again we should update our ui.
     
    }

    public bool HasCoins()
    {
        // here let's check if we have any coins, if we do return true, else return false.
        return false;
    }

    public int ReturnNumberOfCoinsCollected()
    {
        // debug out how many coins we have
      
        // then return the coins current value
        return 0;
    }
}
