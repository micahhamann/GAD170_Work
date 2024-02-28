using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class BigScript : MonoBehaviour
{

    // declaring all text fields
    public TextMeshProUGUI playerStats;
    public TextMeshProUGUI enemyStats;
    public TextMeshProUGUI gameText;
    public TextMeshProUGUI playerCharacter;
    public TextMeshProUGUI enemyCharacter;

    // declaring player stats
    public int playerLVL = 1;
    public int playerCurrentHP = 20;
    public int playerMaxHP = 20;
    public int playerStrength = 2;
    public float playerEvasion = 30f;
    public int currentEXP = 0;
    public int maxEXP = 10;

    // declaring enemy stats
    public int enemyCurrentHP = 0;
    public int enemyMaxHP;
    public int enemyStrength;
    public float enemyBaseEvasion;
    public float enemyCurrentEvasion;
    public int enemyLVL;
    public string enemyName;
    public int potentialEXP;

    // declaring bools
    public bool readyForNewFight = true;
    public bool isPlayerTurn = false;
    public bool isEnemyTurn = false;
    public bool isPlayerDodging = false;
    public bool isPlayerDead = false;
    public bool isGameEnd = false;
    public bool isLevelingUp = false;
    public bool hasPlayerWon = false;


    // Start is called before the first frame update
    void Start()
    {
        //reset all variables to initial state for replayability
        ResetGameStats();
        //Welcome text
        gameText.text = "Welcome WARRIOR to\n <size=80><i><b>       EVASION TOWER  </b></i></size>\n\nYou will be declared the champion once you reach Level 5. Your EVASION stat is the % chance that you will dodge the incoming enemy attack. Choose your actions wisely.\n\nPress SPACEBAR to continue.";
       
    }

    // Update is called once per frame
    void Update()
    {
        // ensuring player and enemy text is showing correct info throughout the game
        if (isPlayerDodging)

        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: " + playerStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)(playerEvasion + 40) + "<size=34>%</size>\n" + "EXP: " + currentEXP + "/" + maxEXP + "\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: " + enemyStrength * 2 + "\n" + "<i><size=34>EVASION: </size></i>" + (int)enemyCurrentEvasion + "<size=34>%</size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }

        else
        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: " + playerStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)playerEvasion + "<size=34>%</size>\n" + "EXP: " + currentEXP + "/" + maxEXP + "\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: " + enemyStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)enemyCurrentEvasion + "<size=34>%</size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }
      
        if (playerCurrentHP < 1)
        {
            isPlayerDead = true;
        }

        // SPACEBAR to spawn new enemy
        if (Input.GetKeyDown(KeyCode.Space) && readyForNewFight)
        {
            readyForNewFight = false;
            //Spawn enemy with scaling stats depending on Player Level
            SpawnEnemy(Random.Range(1, playerLVL+5), Random.Range(playerLVL, playerLVL * 2 + 1));
            isPlayerTurn = true;
                        
        }

        // SPACEBAR to initiate ENEMY TURN
        if (Input.GetKeyDown(KeyCode.Space) && isEnemyTurn && isLevelingUp == false && hasPlayerWon == false)
        {
            isEnemyTurn = false;

            // Check to see if enemy is dead
            if (enemyCurrentHP<1)
            {
               EnemyDefeated();
               readyForNewFight = true;
            }

            else
            {
                EnemyAttack();
            }
            
        }

        // SPACEBAR to claim victory
        if (Input.GetKeyDown(KeyCode.Space) && hasPlayerWon)
        {
            Victory();
        }

        // SPACEBAR to Level Up
        if (Input.GetKeyDown(KeyCode.Space) && isLevelingUp && hasPlayerWon == false)
        {
            LevelUp();
            isLevelingUp = false;
        }

        // SPACEBAR to annouce player's death
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerDead)
        {
            playerCharacter.text = "<color=red>──▄────▄▄▄▄▄▄▄────▄───\n─▀▀▄─▄█████████▄─▄▀▀──\n─────██─▀███▀─██──────\n───▄─▀████▀████▀─▄────\n─▀█────██▀█▀██────█▀──</color>";
            gameText.text = "You have been slain by " + enemyName + ". \n\nYou do not have what it takes to be a champion.\n\n\nPress ESCAPE to restart the game.";
            isGameEnd = true;
        }

        // ESCAPE to restart game
        if (Input.GetKeyDown(KeyCode.Escape) && isGameEnd)
        {
            Start();
        }

        // On player's turn
        // Player selects Attack action by pressing the A key
        if (Input.GetKeyDown(KeyCode.A) && isPlayerTurn && isGameEnd == false)
        {
            PlayerAttack();
            isPlayerTurn = false;
            isEnemyTurn = true;
        }

        // Player selects Wh*ck action by pressing W key
        if (Input.GetKeyDown(KeyCode.W) && isPlayerTurn && isGameEnd == false)
        {
            PlayerWhack();
            isPlayerTurn = false;
            isEnemyTurn = true;
        }

        // Player selects Dodge action by pressing D key
        if (Input.GetKeyDown(KeyCode.D) && isPlayerTurn && isGameEnd == false)
        {
            PlayerDodge();
            isPlayerTurn = false;
            isEnemyTurn = true;
        }

    }

    // Function to spawn new enemy of random type
    void SpawnEnemy(int enemyType, int enemySpawnLevel)
    {

        //Summon enemy type depending on the random int inserted into the function

        //Summon CROCODILE
        if (enemyType == 1 || enemyType == 2)
        {
            enemyCharacter.text = "<color=green>    ▄▄▄▄▄░▄░▄░▄░▄\n▄▄▄▄██▄████▀█▀█▀█▀██▄\n▀▄▀▄▀▄████▄█▄█▄█▄█████\n▀▀▀▀▀▀▀▀██▀▀▀▀██▀ ▒▄██\n      ▀▀   ▀▀▄▄██▀</color>";
            GenerateEnemyStats(1);
            enemyName = "<color=green><size=50>CROCODILE</size></color>";
        }

        //Summon DINOSAUR
        else if (enemyType == 3 || enemyType == 4)
        {
            enemyCharacter.text = "<color=#800080>░▄▄▄▄░\n▀▀▄██►\n▀▀███►\n░▀███►░█►\n▒▄████▀▀</color>";
            GenerateEnemyStats(2);
            enemyName = "<color=#800080><size=40>DINOSAUR</size></color>";
        }

        // Summon MONSTER
        else if (enemyType == 5 || enemyType == 6)
        {
            enemyCharacter.text = "<color=red>▒▒▒▒▒▒▐███████▌\n▒▒▒▒▒▒▐░▀░▀░▀░▌\n▒▒▒▒▒▒▐▄▄▄▄▄▄▄▌\n▄▀▀▀█▒▐░▀▀▄▀▀░▌▒█▀▀▀▄\n▌▌▌▌▐▒▄▌░▄▄▄░▐▄▒▌▐▐▐▐</color>";
            GenerateEnemyStats(3);
            enemyName = "<color=red><size=40>MONSTER</size></color>";
        }

        // Summon DEATH
        else if (enemyType == 7 || enemyType == 8)
        {
            enemyCharacter.text = "<color=#A9A9A9>▒▒▒▒▒▒▒▒▄▄▄▄▄▄▄▄▒▒▒▒▒▒\n▒▒█▒▒▒▄██████████▄▒▒▒▒\n▒█▐▒▒▒████████████▒▒▒▒\n▒▌▐▒▒██▄▀██████▀▄██▒▒▒\n▐┼▐▒▒██▄▄▄▄██▄▄▄▄██▒▒▒\n▐┼▐▒▒██████████████▒▒▒\n▐▄▐████─▀▐▐▀█─█─▌▐██▄▒\n▒▒█████──────────▐███▌\n▒▒█▀▀██▄█─▄───▐─▄███▀▒\n▒▒█▒▒███████▄██████▒▒▒\n▒▒▒▒▒██████████████▒▒▒\n▒▒▒▒▒█████████▐▌██▌▒▒▒\n▒▒▒▒▒▐▀▐▒▌▀█▀▒▐▒█▒▒▒▒▒\n▒▒▒▒▒▒▒▒▒▒▒▐▒▒▒▒▌▒▒▒▒▒</color>";
            GenerateEnemyStats(10);
            enemyName = "<color=#A9A9A9><size=40>DEATH</size></color>";
        }

        // Change text to enemy encounter
        gameText.text = "A wild " + enemyName + " appears in front of you!\n\n" + "What do you do?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20 enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40 player evasion, x2 enemy damage)</color>";

        // Function to generate new enemy stats upon new encounter
        void GenerateEnemyStats(int boss)
        {
            enemyLVL = enemySpawnLevel;
            enemyMaxHP = playerLVL * enemySpawnLevel + boss;
            enemyCurrentHP = enemyMaxHP;
            enemyStrength = enemySpawnLevel + enemyType;
            enemyBaseEvasion = 10 + enemyType * 5;
            enemyCurrentEvasion = enemyBaseEvasion;
            potentialEXP = playerLVL * 2 + Random.Range(1, 5) + enemyType * 2;
        }
    }

    void PlayerAttack()
    {
        // check to see if enemy evades the hit
        if (Random.Range(0, 100) > enemyCurrentEvasion)
        {
            enemyCurrentHP -= playerStrength;

            // check to see if enemy is dead
            if (enemyCurrentHP < 1)
            {
                enemyCharacter.text = string.Empty;
                gameText.text = "Warrior chooses to <color=green>ATTACK</color>. He deals " + playerStrength + " damage.\n\n" + enemyName + " is slain. You gain " + potentialEXP + " EXP points.\n\n" + "Press SPACEBAR to face new enemy.";
            }

            else
            {
                gameText.text = "Warrior chooses to <color=green>ATTACK<c/olor>. He deals " + playerStrength + " damage.\n\n" + "Press SPACEBAR to continue fight.";

            }

        }
        else
        {
            gameText.text = "WARRIOR chooses to <color=green>ATTACK</color>. \n\nOh noooo! " + enemyName + " evaded your attack!\n\n" + "Press SPACEBAR to continue fight.";
        }
    }

    void PlayerWhack()
    {
        if (Random.Range(0,100) > enemyCurrentEvasion + 20)
        {

            enemyCurrentHP -= playerStrength * 2;

            if (enemyCurrentHP<1)
            {
                gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nHe deals a <i><b>WHOPPING</i></b> " + playerStrength * 2 + " damage.\n\n" + enemyName + " is slain. You gain " + potentialEXP + " EXP points.\n\n" + "Press SPACEBAR to face new enemy.";
                enemyCharacter.text = string.Empty;
            }

            else
            {
                gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nHe deals a <i><b>WHOPPING</i></b> " + playerStrength * 2 + " damage.\n\n" + "Press SPACEBAR to continue fight.";
            }
        }

        else
        {
            gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nOh noooo! " + enemyName + " evaded your attack!\n\n" + "Press SPACEBAR to continue fight.";
        }
    }

    void PlayerDodge()
    {
        isPlayerDodging = true;
        gameText.text = "WARRIOR chooses to <color=lightblue>DODGE</color>. \n\nYour <color=lightblue><b><i>EVASION</color></b></i> is heightened by 40%.\n\n" + "Press SPACEBAR to continue fight.";

    }

    void ResetGameStats()
    {
        isPlayerDead = false;
        isPlayerTurn = false;
        isGameEnd = false;
        isEnemyTurn = false;
        isPlayerDodging = false;
        readyForNewFight = true;
        playerLVL = 1;
        playerCurrentHP = 20;
        playerMaxHP = 20;
        playerStrength = 2;
        playerEvasion = 30f;
        currentEXP = 0;
        maxEXP = 10;
        playerCharacter.text = " <color=#02c2ab>░░░░</color>   \n <color=#02c2ab>░</color>█████  ░\n <color=#02c2ab>░</color>█-█-  ░ \n▒▒█████  ░\n▒▒<color=#02c2ab>░░░░░░</color>█▒▒\n▒▒<color=#02c2ab>░</color>  <color=#02c2ab>░░</color> ▒\n <color=#02c2ab>░░░░░</color>\n █  █";
        enemyCharacter.text = string.Empty;
        enemyCurrentHP = 0;
        enemyMaxHP = 0;
        enemyStrength = 0;
        enemyBaseEvasion = 0;
        enemyCurrentEvasion = 0;
        enemyLVL = 0;
        enemyName = string.Empty;

}

    void EnemyAttack()
    {
        //check to see if player chose to dodge because chances are different if so
        if (isPlayerDodging == false)
        {
            if (Random.Range(0, 100) > playerEvasion)
            {
                playerCurrentHP -= enemyStrength;
                gameText.text = enemyName + " lands a hit!!! You take " + enemyStrength + " damage.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x2 enemy damage)</color>";
                isPlayerTurn = true;
            }

            else
            {
                gameText.text = enemyName + " misses!! You <b><color=lightblue>EVADED</color></b> the attack.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x2 enemy damage)</color>";                
                isPlayerTurn = true;
            }
        }

        else
        {
            if (Random.Range(0, 100) > playerEvasion + 40)
            {
                playerCurrentHP -= enemyStrength * 2;

                //Player killed by critical hit
                if (playerCurrentHP < 1)
                {
                    gameText.text = enemyName + " lands a <b>CRITICAL</b> hit!!! You take " + enemyStrength * 2 + " damage.\n\n" + "<color=red>You fall to the ground...</color>\n\nPress SPACEBAR to continue.";
                    isPlayerTurn = false;
                }

                //Player hit while dodging which is rare
                else
                {
                    gameText.text = enemyName + " lands a <b>CRITICAL</b> hit!!! You take " + enemyStrength * 2 + " damage.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x2 enemy damage)</color>";
                    isPlayerDodging = false;
                    isPlayerTurn = true;
                }
                
            }

            else
            {
                gameText.text = enemyName + " misses!! You <b><color=lightblue>EVADED</color></b> the attack.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x2 enemy damage)</color>";
                isPlayerDodging = false;
                isPlayerTurn = true;
            }
        }

        //Randomise Enemy EVASION for extra strategy
        enemyCurrentEvasion = Random.Range(5, enemyBaseEvasion + 30);

        //Player is killed by non-critical attack
        if (playerCurrentHP < 1 && isPlayerDodging == false)
        {
            gameText.text = enemyName + " lands a hit!!! You take " + enemyStrength + " damage.\n\n" + "<color=red>You fall to the ground...</color>\n\nPress SPACEBAR to continue.";
            isPlayerTurn = false;
        }
    }

    void EnemyDefeated()
    {
        currentEXP += potentialEXP;       

        if(currentEXP >= maxEXP)
        {
            isLevelingUp = true;
        }

        else
        {
            isLevelingUp = false;
        }
    }

    void LevelUp()
    {
        playerLVL++;
        playerStrength = (int)(playerStrength * 1.5f + 1);
        playerEvasion += 5;
        currentEXP -= maxEXP;
        maxEXP += 10;
        playerMaxHP += 5;
        playerCurrentHP = playerMaxHP;

        gameText.text = "\n<size=60><b><color=green>LEVEL UP  </color><color=#FF00FF>LEVEL UP </color><color=yellow>LEVEL UP  </color></size></b>\n\n" + "You have increased strength, evasion and health.\n\n\n" + "Press SPACEBAR to continue";

        if(playerLVL == 5)
        {
            hasPlayerWon = true;
        }
    }

    void Victory()
    {
        playerCharacter.text = string.Empty;
        enemyCharacter.text = string.Empty;
        playerStats.text = " ";
        enemyStats.text = " ";
        gameText.text = "Congratulations! You made it to Level 5. You are our new\n\n\n\n <size=200><color=red>C</color><color=#FFA500>H</color><color=yellow>A</color><color=green>M</color><color=#00FFFF>P</color><color=blue>I</color><color=#BF40BF>O</color><color=#FF00FF>N</color></size>\n\n\n\n\n\nPress ESCAPE to play again.";
        isGameEnd = true;
        isLevelingUp = false;
        hasPlayerWon = false;
    }
}
