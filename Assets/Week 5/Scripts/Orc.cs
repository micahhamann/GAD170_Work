using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    // create variables for:
    // name, health, intelligence, agility, strength, attack damage.

    public void Setup()
    {
        int randomNumber = Random.Range(0, 3);
        // set your variables to psudeo random values
        // an example of this would be if(randomNumber = 1) {name = "jack", intel = 5; etc} else if(random number = 2) {name = "Jill", intel = 6; etc.}
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
        // we probs want the amount coming in, to be taken away from out health.
        // if we are 0 health, let's Destroy(gameObject) to kill off this orc.
        Destroy(gameObject);
    }
}
