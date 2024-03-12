using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.Completed
{
    public class Orc : MonoBehaviour
    {
        // create variables for:
        // name, health, intelligence, agility, strength, attack damage.
        public string orcName;
        public int health;
        public int intelligence;
        public int strength;
        public int agility;
        public int attackDamge;

        public void Setup()
        {
            int randomNumber = Random.Range(0, 3);
            // set your variables to psudeo random values
            // an example of this would be if(randomNumber = 1) {name = "jack", intel = 5; etc} else if(random number = 2) {name = "Jill", intel = 6; etc.}
            if(randomNumber == 0)
            {
                orcName = "Kevin";
                health = 100;
                intelligence = 7;
                strength = 1;
                agility = 8;
                attackDamge = 4;
            }
            if (randomNumber == 1)
            {
                orcName = "Steve";
                health = 20;
                intelligence = 2;
                strength = 5;
                agility = 20;
                attackDamge = 25;
            }
            if (randomNumber == 2)
            {
                orcName = "Orcy";
                health = 60;
                intelligence = 10;
                strength = 10;
                agility = 10;
                attackDamge = 15;
            }
        }

        public void TakeDamage(float amount)
        {
            Debug.Log(amount);
            // we probs want the amount coming in, to be taken away from out health.
            health -= (int) amount;
            // if we are 0 health, let's Destroy(gameObject) to kill off this orc.
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
