using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    // create variables for:
    // name, health, intelligence, agility, strength, attack damage.
    public string orcName;
    public int orcHealth;
    public float orcStrength;
    public int orcIntelligence;
    public int attackDamage;

    public void Setup()
    {
        int randomNumber = Random.Range(0, 3);
        // set your variables to psudeo random values
        // an example of this would be if(randomNumber = 1) {name = "jack", intel = 5; etc} else if(random number = 2) {name = "Jill", intel = 6; etc.}

        if(randomNumber == 0)
        {
            orcName = "Malcom";
            orcHealth = 20;
            orcStrength = 5f;
            orcIntelligence = 7;
        }

        else if(randomNumber == 1)
        {
            orcName = "Patty";
            orcHealth = 10;
            orcStrength = 10f;
            orcIntelligence = 5;
        }

        else if(randomNumber == 2)
        {
            orcName = "Biggus Dickus";
            orcHealth = 30;
            orcStrength = 3f;
            orcIntelligence = 2;
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(orcName + " takes " + amount + " damage!\n\n");
        orcHealth -= (int)amount;

        if(orcHealth < 1)
        {
            Debug.Log(orcName + " has been slain!\n\n");
            Destroy(this);
        }


    }
}
