using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //Declare  Player stat variables
    static public int playerHealth = 100;
    static public int playerStrength = 1;
    static public int playerLevel = 1;
    static public float playerBaseEvade = 20f;

    //Declare Enemy stat variables
    public int enemyHealth;
    public int enemyStrength;
    public int enemyLevel;
    public float enemyEvade;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<size=24>Welcome to EVASION. You are declared champion once you reach LV5. Do you have what it takes? Press SPACEBAR to begin fighting.</size>\n\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnterBattle();
        }
    }

    void EnterBattle()
    {
        //Display Player Stats
    }

    
}
