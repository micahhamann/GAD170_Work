using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFive : MonoBehaviour
{
    int playerOneHealth = 0;
    int playerOneStrength = 0;
    int playerOneAgility = 0;
    int playerOneIntelligence = 0;
    int playerOnePowerLevel = 0;

    int playerTwoHealth = 0;
    int playerTwoStrength = 0;
    int playerTwoAgility = 0;
    int playerTwoIntelligence = 0;
    int playerTwoPowerLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerOneStats();
        SetPlayerTwoStats();
    }

    // Update is called once per frame
    void Update()
    {
        Battle();
    }

    void SetPlayerOneStats()
    {
        // set our health to 100
       
        // set our stats to random numbers between 0 - 10
      
    }

    void SetPlayerTwoStats()
    {
        // set our health to 100
       
        // set our stats to random numbers between 0 - 10
        
    }

    void Battle()
    {
        // if you want to get really fancy here, only let me "battle" if both characters have health left.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerOnePowerLevel = GeneratePowerLevel(playerOneIntelligence, playerOneAgility, playerOneStrength);
            playerTwoPowerLevel = GeneratePowerLevel(playerTwoIntelligence, playerTwoAgility, playerTwoStrength);
            DetermineWinner(playerOnePowerLevel, playerTwoPowerLevel);
        }
    }

    int GeneratePowerLevel(int intel, int agil, int strength)
    {
        // let's do some sort of algorithm here i.e. intel + agil  + strength, it's probably a good idea to add some randomness here too,
        // otherwise the same player will always win most likely.
        int powerLevel = 0;

        return powerLevel;
    }

    void DetermineWinner(int playerOnePower, int playerTwoPower)
    {
        if(playerOnePowerLevel > playerTwoPowerLevel)
        {
            // player one has more power.
            // deal a random amount of damage to the other player.
           
            // check if the other player has health left over, if not, tell us player one has won the game.
            
        }
        else if(playerTwoPowerLevel > playerOnePowerLevel)
        {
            // player two has more power
            // deal a random amount of damage to the other player.
           
            // check if the other player has health left over, if not, tell us player two has won the game.
            
        }
        else
        {
            // should we do anything if it's a draw? maybe they both take damage
        }    
    }
}
