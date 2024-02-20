using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFour : MonoBehaviour
{
    /*
     * Write some code to do the following:
        * Create variables for the following information:
            * strength, agility and intelligence, and a variable for stat pool of 20
        * For each stat, let?s assign a random value between 0-10.
        * Update your stat allocation and make it a random number between 0 and your current stat pool value.
        * Finally each time we assign a random value to a stat pool, let?s remove that from our stat pool:
            * i.e. strength gets the random number 7; we take this away from our statpool, there are now 13 stat points left, agility now gets a random number between 0 and 13.
        * Debug out the following:
            * Each value of your stats and the current value of stat pool.
        * Bonus
            * Let?s assign another 20 points of stats to our statpool and assign these stats using a key input.
     */

    int statPool = 20;
    int randomNumber;
    int strength = 0;
    int agility = 0;
    int intelligence = 0;

    // Start is called before the first frame update
    void Start()
    {
        // we want to get a random amount
        randomNumber = Random.Range(0, statPool);
        strength = randomNumber;
        statPool -= randomNumber;

        randomNumber = Random.Range(0, statPool);
        agility = randomNumber;
        statPool -= randomNumber;

        randomNumber = Random.Range(0, statPool);
        intelligence = randomNumber;
        statPool -= randomNumber;

        Debug.Log("Current stats: Strength " + strength + ", Agility " + agility + ", Intelligence " + intelligence);

        // then set out stat to that value.

        // don't forget to take the amount assinged away from the stat pool.
        // we want to make sure we can distripute the 20 points amoungst the stats.
        // it'd be a good idea to debug out the current value of each stat, and the current value of the statpool to confirm it's working.

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // add 20 more stats to our stat pool.

            statPool += 20;
            Debug.Log("statpool = " + statPool);

            randomNumber = Random.Range(0, statPool);
            strength += randomNumber;
            statPool -= randomNumber;

            randomNumber = Random.Range(0, statPool);
            agility += randomNumber;
            statPool -= randomNumber;

            randomNumber = Random.Range(0, statPool);
            intelligence += randomNumber;
            statPool -= randomNumber;

            Debug.Log("Current stats: Strength " + strength + ", Agility " + agility + ", Intelligence " + intelligence);

            // this time when assign stats, we are going to have to make sure we add the new amount on top of the current for each stat.
        }

    }

}
