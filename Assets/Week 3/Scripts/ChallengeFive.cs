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

    bool isKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<size=16>Welcome to <color=yellow><b>SIMPLE TEXT BATTLE!</b></color> New challengers have entered the arena.</size>\n\n");
        SetPlayerOneStats();
        SetPlayerTwoStats();

        Debug.Log("Press the B key to continue the battle.\n\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isKeyPressed = true;
        }

        Battle();
    }

    void SetPlayerOneStats()
    {
        // set our health to 100
        playerOneHealth = 100;
        // set our stats to random numbers between 0 - 10
        playerOneStrength = Random.Range(5,11);
        playerOneAgility = Random.Range(5, 11);
        playerOneIntelligence = Random.Range(5, 11);      
    }

    void SetPlayerTwoStats()
    {
        // set our health to 100
        playerTwoHealth = 100;
        // set our stats to random numbers between 0 - 10
        playerTwoStrength = Random.Range(5, 11);
        playerTwoAgility = Random.Range(5, 11);
        playerTwoIntelligence = Random.Range(5, 11);        
    }

    void Battle()
    {
        
        
        if (isKeyPressed == true)
        {
                isKeyPressed = false;
                playerOnePowerLevel = GeneratePowerLevel(playerOneIntelligence, playerOneAgility, playerOneStrength);
                playerTwoPowerLevel = GeneratePowerLevel(playerTwoIntelligence, playerTwoAgility, playerTwoStrength);
                Debug.Log("Player One POWER = " + playerOnePowerLevel + "\n" + "                    Player Two POWER = " + playerTwoPowerLevel + "\n");

                DetermineWinner(playerOnePowerLevel, playerTwoPowerLevel);
           
        }

    }

    int GeneratePowerLevel(int intel, int agil, int strength)
    {
        // let's do some sort of algorithm here i.e. intel + agil  + strength, it's probably a good idea to add some randomness here too,
        // otherwise the same player will always win most likely.
        int powerLevel = intel + agil + strength + Random.Range(0,30);

        return powerLevel;
    }

    void DetermineWinner(int playerOnePower, int playerTwoPower)
    {
        if(playerOnePower > playerTwoPower)
        {
            // player one has more power.
            Debug.Log("<color=cyan><b>Player One attacks!</b></color>\n\n");
            // deal a random amount of damage to the other player.
            int tempPlayerOneAttack = GenerateAttackPower(playerOnePower);
            playerTwoHealth -= tempPlayerOneAttack;
            Debug.Log("Player One deals " + tempPlayerOneAttack + " damage!\n\n");
            // check if the other player has health left over, if not, tell us player one has won the game.
               if(playerTwoHealth <= 0)
                {
                    Debug.Log("Player Two has fainted. <b><color=cyan>Player One is the WINNER!</color></b>\n\n");
                    Start();
                }

                else
                {
                    Debug.Log("Press B to continue fight.\n\n");
                    Battle();
                }
        }
        else if(playerTwoPower > playerOnePower)
        {
            // player two has more power
            Debug.Log("<color=magenta><b>Player Two attacks!</b></color>\n\n");
            // deal a random amount of damage to the other player.
            int tempPlayerTwoAttack = GenerateAttackPower(playerTwoPower);
            playerOneHealth -= tempPlayerTwoAttack;
            Debug.Log("Player Two deals " + tempPlayerTwoAttack + " damage!\n\n");
            // check if the other player has health left over, if not, tell us player two has won the game.
                if(playerOneHealth <= 0)
                {
                    Debug.Log("Player One has fainted. <b><color=magenta>Player Two is the WINNER!</color></b>\n\n");
                    Start();
                }

                else
                {
                    Debug.Log("Press B to continue fight.\n\n");
                    Battle();
                }

            
        }
        else if(playerOnePower == playerTwoPower)
        {
            // should we do anything if it's a draw? maybe they both take damage
            Debug.Log("Neither player has the advantage. They both sit in defence waiting for the next strike.\n\n");
            Debug.Log("Press B to continue fight.\n\n");
            Battle();
        }      
    }

    int GenerateAttackPower(int tempStrength)
    {
        return tempStrength + Random.Range(0, 3);
    }
}
