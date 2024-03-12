using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public EnemyManager enemyManager;

    private void Start()
    {
        //Find reference to Enemy Manager. Can't drag in as object spawns in.
        // Needs reference in order to access the RemoveFromList function
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health < 1)
        {

            //Null check
            if(enemyManager != null)
            {

                //pass through THIS instance of enemy into the function that removes from list
                enemyManager.RemoveEnemyFromList(this);
            }

            //Destroy this instance of Enemy
            Destroy(gameObject);
        }
    }
}
