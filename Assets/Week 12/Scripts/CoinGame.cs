using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SAE.GAD170.WeekTwelve
{
    public class CoinGame : MonoBehaviour
    {
        [SerializeField] private int coins;

        private void OnEnable()
        {
            // let's subscribe our update coins function to our change coin amount event.
           
        }

        private void OnDisable()
        {
            // let's unsubscribe our update coins function to our change coin amount event.
            
        }

        // Start is called before the first frame update
        void Start()
        {
            // set our current coins collected to 0
           
            // invoke the UpdatePlayerCoinValueEvent and pass in the current value of our coins.
           
        }

        void UpdateCoins(int amount)
        {
            // Add the amount to our coins; that way if the amount is positive it increases, but if the amount is negative it decreases.
            

            // invoke the UpdatePlayerCoinValueEvent and pass in the current value of our coins.
            
        }
    }
}