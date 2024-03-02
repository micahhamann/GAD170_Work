using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ProjectOneScript : MonoBehaviour
{
    //Declaring Variables
    #region
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
    public bool isPlayerWhacking = false;
    public bool isPlayerDead = false;
    public bool isGameEnd = false;
    public bool isLevelingUp = false;
    public bool hasPlayerWon = false;
    public bool isStatIncrease = false;
    public bool isGainingEXP = false;
    #endregion


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
        //This collecetion of if statements run the Player/Enemy Stat text fields
        #region
        // show increase evasion while dodging
        if (isPlayerDodging)

        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: " + playerStrength + "\n" + "<i><size=34>EVASION: </size></i><color=yellow>" + (int)(playerEvasion + 40) + "<size=34>%</color></size>\n" + "EXP: " + currentEXP + "/" + maxEXP + "\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: <color=yellow>" + Mathf.RoundToInt(enemyStrength * 1.5f) + "</color>\n" + "<i><size=34>EVASION: </size></i>" + (int)enemyCurrentEvasion + "<size=34>%</size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }

        //Show stat increase during LEVEL UP scene
        else if (isStatIncrease)

        {
            playerStats.text = "<size=28>LVL: " + (playerLVL - 1) + "<color=green> +1 LVL</color>\n" + "Health: " + (playerCurrentHP - 5) + "/" + (playerMaxHP - 5) + "<color=green> +5 max HP</color>\n" + "Strength: <color=green>+increased to " + playerStrength + "</color>!" + "\n" + "<i><size=34>EVASION: </size></i>" + (int)(playerEvasion - 5) + "%<color=green> +5% </color><size=34></size>\n" + "EXP: " + currentEXP + "/" + (maxEXP - 10) + "<color=green> +10max</color></size>";
            enemyStats.text = " ";
        }

        //Show stat increase while Whacking
        else if (isPlayerWhacking && isGainingEXP == false)
        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: <color=yellow>" + playerStrength*2 + "</color>\n" + "<i><size=34>EVASION: </size></i>" + (int)playerEvasion + "<size=34>%</size>\n" + "EXP: " + currentEXP + "/" + maxEXP + "\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: " + enemyStrength + "\n" + "<i><size=34>EVASION: </size></i><color=yellow>" + (int)(enemyCurrentEvasion+20) + "<size=34>%</color></size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }

        //Show EXP increase after killing enemy
        else if (isGainingEXP)
        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: " + playerStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)playerEvasion + "<size=34>%</size>\n" + "EXP: " + (currentEXP - potentialEXP) + "/" + maxEXP + "<color=green> +" + potentialEXP + " EXP</color>\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: " + enemyStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)enemyCurrentEvasion + "<size=34>%</size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }

        //Turn of stats when player is dead or victorious
        else if (isGameEnd)
        {
            playerStats.text = string.Empty;
            enemyStats.text = string.Empty;
        }
        //ensuring player and enemy text is showing correct info throughout the game

        else
        {
            playerStats.text = "LVL: " + playerLVL + "\n" + "Health: " + playerCurrentHP + "/" + playerMaxHP + "\n" + "Strength: " + playerStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)playerEvasion + "<size=34>%</size>\n" + "EXP: " + currentEXP + "/" + maxEXP + "\n\n<color=#00FFFF><size=60>WARRIOR</size></color>";
            enemyStats.text = "LVL: " + enemyLVL + "\n" + "Health: " + enemyCurrentHP + "/" + enemyMaxHP + "\n" + "Strength: " + enemyStrength + "\n" + "<i><size=34>EVASION: </size></i>" + (int)enemyCurrentEvasion + "<size=34>%</size>\n" + "Potential EXP: " + potentialEXP + "\n\n" + enemyName;
        }

        #endregion

        //Game always checking whether player is dead
        if (playerCurrentHP < 1)
        {
            isPlayerDead = true;
        }

        //SPACEBAR ACTIONS - Bools decide what happens when player presses the spacebar
        #region

        // SPACEBAR to spawn new enemy when player is ready for a new fight
        if (Input.GetKeyDown(KeyCode.Space) && readyForNewFight)
        {
            
            //Spawn enemy with scaling stats depending on Player Level
            SpawnEnemy(Random.Range(1, playerLVL+5), Random.Range(playerLVL, (playerLVL * 2) + 1)); //first int determines the type of enemy, second determines their stats

            isPlayerTurn = true;
            isGainingEXP = false;
            isStatIncrease = false;
            isPlayerWhacking = false;
            readyForNewFight = false;

            Debug.Log("New Level " + enemyLVL + " enemy spawned: <size=12>" + enemyName + ".</size>\n\n");

        }

        // SPACEBAR to initiate ENEMY TURN
        if (Input.GetKeyDown(KeyCode.Space) && isEnemyTurn && isLevelingUp == false && hasPlayerWon == false)
        {
            //return to idle sprite
            DefaultAnimation();
            isEnemyTurn = false;

            // Check to see if enemy is dead
            if (enemyCurrentHP<1)
            {
               // Distribute EXP and ready player for new fight
               EnemyDefeated();
               readyForNewFight = true;
               isGainingEXP = true;
            }

            //if enemy is not dead, they attack player
            else
            {
                EnemyAttack();
            }
            
        }

        // SPACEBAR to claim victory
        if (Input.GetKeyDown(KeyCode.Space) && hasPlayerWon)
        {
            isStatIncrease = false;
            isGainingEXP = false;
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
            //show death sprite and text
            playerCharacter.text = "<color=red>──▄────▄▄▄▄▄▄▄────▄───\n─▀▀▄─▄█████████▄─▄▀▀──\n─────██─▀███▀─██──────\n───▄─▀████▀████▀─▄────\n─▀█────██▀█▀██────█▀──</color>";
            gameText.text = "You have been slain by " + enemyName + ". \n\nYou do not have what it takes to be a champion.\n\n\nPress ESCAPE to restart the game.";
            isGameEnd = true;
        }
        #endregion

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

        //Summon CROCODILE easiest enemy
        if (enemyType == 1 || enemyType == 2)
        {
            enemyCharacter.text = "<color=green>    ▄▄▄▄▄░▄░▄░▄░▄\n▄▄▄▄██▄████▀█▀█▀█▀██▄\n▀▄▀▄▀▄████▄█▄█▄█▄█████\n▀▀▀▀▀▀▀▀██▀▀▀▀██▀ ▒▄██\n      ▀▀   ▀▀▄▄██▀</color>";
            GenerateEnemyStats(1);
            enemyName = "<color=green><size=50>CROCODILE</size></color>";
        }

        //Summon DINOSAUR
        else if (enemyType == 3 || enemyType == 6)
        {
            enemyCharacter.text = "<color=#800080>░▄▄▄▄░\n▀▀▄██►\n▀▀███►\n░▀███►░█►\n▒▄████▀▀</color>";
            GenerateEnemyStats(2);
            enemyName = "<color=#800080><size=40>DINOSAUR</size></color>";
        }

        // Summon MONSTER
        else if (enemyType == 5 || enemyType == 4)
        {
            enemyCharacter.text = "<color=red>▒▒▒▒▒▒▐███████▌\n▒▒▒▒▒▒▐░▀░▀░▀░▌\n▒▒▒▒▒▒▐▄▄▄▄▄▄▄▌\n▄▀▀▀█▒▐░▀▀▄▀▀░▌▒█▀▀▀▄\n▌▌▌▌▐▒▄▌░▄▄▄░▐▄▒▌▐▐▐▐</color>";
            GenerateEnemyStats(1);
            enemyName = "<color=red><size=40>MONSTER</size></color>";
        }

        // Summon DEATH which is the hardest enemy. Only appears in LVL 3 & 4
        else if (enemyType == 7 || enemyType == 8)
        {
            enemyCharacter.text = "<color=#A9A9A9>▒▒▒▒▒▒▒▒▄▄▄▄▄▄▄▄▒▒▒▒▒▒\n▒▒█▒▒▒▄██████████▄▒▒▒▒\n▒█▐▒▒▒████████████▒▒▒▒\n▒▌▐▒▒██▄▀██████▀▄██▒▒▒\n▐┼▐▒▒██▄▄▄▄██▄▄▄▄██▒▒▒\n▐┼▐▒▒██████████████▒▒▒\n▐▄▐████─▀▐▐▀█─█─▌▐██▄▒\n▒▒█████──────────▐███▌\n▒▒█▀▀██▄█─▄───▐─▄███▀▒\n▒▒█▒▒███████▄██████▒▒▒\n▒▒▒▒▒██████████████▒▒▒\n▒▒▒▒▒█████████▐▌██▌▒▒▒\n▒▒▒▒▒▐▀▐▒▌▀█▀▒▐▒█▒▒▒▒▒\n▒▒▒▒▒▒▒▒▒▒▒▐▒▒▒▒▌▒▒▒▒▒</color>";
            GenerateEnemyStats(10);
            enemyName = "<color=#A9A9A9><size=40>DEATH</size></color>";
        }

        // Change text to enemy encounter
        gameText.text = "A wild " + enemyName + " appears in front of you!\n\n" + "What do you do?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20 enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x1.5 enemy damage)</color>";

        // Function to generate new enemy stats upon new encounter
        // boss int allows me to beef up the DEATH enemy to make him more menacing
        void GenerateEnemyStats(int boss)
        {
            enemyLVL = enemySpawnLevel;
            enemyMaxHP = playerLVL * enemySpawnLevel + boss;
            enemyCurrentHP = enemyMaxHP;
            enemyStrength = enemySpawnLevel + enemyType;
            enemyBaseEvasion = 10 + enemyType * 3;
            enemyCurrentEvasion = enemyBaseEvasion;
            potentialEXP = playerLVL * 2 + Random.Range(1, 5) + enemyType * 2;
        }
    }

    //Player Turn functions: Attack, Wh*ck & Dodge
    #region
    void PlayerAttack()
    {

        // check to see if enemy evades the hit
        if (Random.Range(0, 100) > enemyCurrentEvasion)
        {
            enemyCurrentHP -= playerStrength; //do the damage

            DebugOutAttackStats("ATTACK", 1, "hit", playerStrength);
            AttackAnimation(playerStrength, "<color=green>Hit!!</color>");

            // check to see if enemy is dead
            if (enemyCurrentHP < 1)
            {
                enemyCharacter.text = "<color=#A9A9A9>──▄────▄▄▄▄▄▄▄────▄───\n─▀▀▄─▄█████████▄─▄▀▀──\n─────██─▀███▀─██──────\n───▄─▀████▀████▀─▄────\n─▀█────██▀█▀██────█▀──</color>";
                gameText.text = "Warrior chooses to <color=green>ATTACK</color>. He deals " + playerStrength + " damage.\n\n" + enemyName + " is slain. You gain " + potentialEXP + " EXP points.\n\n" + "Press SPACEBAR to face new enemy.";
            }

            // if enemy is still living, move onto enemy's turn
            else
            {
               gameText.text = "Warrior chooses to <color=green>ATTACK</color>. He deals " + playerStrength + " damage.\n\n" + "Press SPACEBAR to continue fight.";
            }

        }

        // When the player misses. No damage done and print miss text
        else
        {
            AttackAnimation(0, "<color=#00FFFF>miss</color>");
            DebugOutAttackStats("ATTACK", 1, "miss", 0);
            gameText.text = "WARRIOR chooses to <color=green>ATTACK</color>. \n\nOh noooo! " + enemyName + " evaded your attack!\n\n" + "Press SPACEBAR to continue fight.";
        }
    }

    void PlayerWhack()
    {
        isPlayerWhacking = true;

        //check to see if enemy avoids attack        
        if (Random.Range(0,100) > enemyCurrentEvasion + 20)
        {

            enemyCurrentHP -= playerStrength * 2; //WH*CK deals double damage
            DebugOutAttackStats("WHACK", 2, "hit", playerStrength);

            //If WH*CK kills the enemy
            if (enemyCurrentHP<1)
            {
                gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nHe deals a <i><b>WHOPPING</i></b> " + playerStrength * 2 + " damage.\n\n" + enemyName + " is slain. You gain " + potentialEXP + " EXP points.\n\n" + "Press SPACEBAR to face new enemy.";
                enemyCharacter.text = "<color=#A9A9A9>──▄────▄▄▄▄▄▄▄────▄───\n─▀▀▄─▄█████████▄─▄▀▀──\n─────██─▀███▀─██──────\n───▄─▀████▀████▀─▄────\n─▀█────██▀█▀██────█▀──</color>";
                WhackAnimation(playerStrength*2, "Whaaack!!");
            }

            //If enemy is still alive
            else
            {
                gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nHe deals a <i><b>WHOPPING</i></b> " + playerStrength * 2 + " damage.\n\n" + "Press SPACEBAR to continue fight.";
                WhackAnimation(playerStrength * 2, "Whaaack!!");
            }
        }

        //If WH*CK misses
        else
        {
            gameText.text = "WARRIOR chooses to <color=yellow>WHACK</color>. \n\nOh noooo! " + enemyName + " <b><i><color=lightblue>EVADED</color></i></b> your attack!\n\n" + "Press SPACEBAR to continue fight.";
            WhackAnimation(0, "<color=#00FFFF>miss</color>");
            DebugOutAttackStats("WHACK", 2, "miss", 0);
        }
    }

    void PlayerDodge()
    {

        DebugOutAttackStats("DODGE", 0, "dodges", 0);
        DodgeAnimation();
        isPlayerDodging = true; // The dodge benefit is applied in the EnemyAttack function
        gameText.text = "WARRIOR chooses to <color=lightblue>DODGE</color>. \n\nYour <color=lightblue><b><i>EVASION</color></b></i> is heightened by 40% but leaves you vulnerable.\n\n" + "Press SPACEBAR to continue fight.";

    }
    #endregion

    void ResetGameStats() //Set everything to its initial state
    {
        isPlayerDead = false;
        isPlayerTurn = false;
        isGameEnd = false;
        isEnemyTurn = false;
        isPlayerDodging = false;
        isPlayerWhacking = false;
        readyForNewFight = true;
        isStatIncrease = false;
        isGainingEXP = false;
        playerLVL = 1;
        playerCurrentHP = 20;
        playerMaxHP = 20;
        playerStrength = 2;
        playerEvasion = 30f;
        currentEXP = 0;
        maxEXP = 10;
        playerCharacter.text = " <color=#02c2ab>░░░░░</color>   \n <color=#02c2ab>░</color>█████  ░\n <color=#02c2ab>░</color>█-█-  ░ \n▒▒█████  ░\n▒▒<color=#02c2ab>░░░░░░</color>█▒▒\n▒▒<color=#02c2ab>░</color>  <color=#02c2ab>░░</color> ▒\n <color=#02c2ab>░░░░░</color>\n █  █";
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
        DefaultAnimation();
        isPlayerWhacking = false;

        //check to see if player chose to dodge because player evasion is different if so
        if (isPlayerDodging == false)
        {
            if (Random.Range(0, 100) > playerEvasion)
            {
                playerCurrentHP -= enemyStrength;
                gameText.text = enemyName + " lands a hit!!! You take " + enemyStrength + " damage.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x1.5 enemy damage)</color>";
                DebugEnemyAttack("hit", 1f);
                HitAnimation(enemyStrength);
                isPlayerTurn = true;
            }

            else
            {
                gameText.text = enemyName + " misses!! You <b><color=lightblue>EVADED</color></b> the attack.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x1.5 enemy damage)</color>";
                DebugEnemyAttack("missed", 0f);
                isPlayerTurn = true;
            }
        }

        else
        {
            if (Random.Range(0, 100) > playerEvasion + 40) // Add the +40% dodging benefit to the player
            {
                playerCurrentHP -= Mathf.RoundToInt(enemyStrength * 1.5f); // however, enemy deals 1.5 damage if they still hit
                DebugEnemyAttack("critical hit", 1.5f);

                //Player killed by critical hit
                if (playerCurrentHP < 1)
                {
                    gameText.text = enemyName + " lands a <b>CRITICAL</b> hit!!! You take " + Mathf.RoundToInt(enemyStrength * 1.5f) + " damage.\n\n" + "<color=red>You fall to the ground...</color>\n\nPress SPACEBAR to continue.";
                    HitAnimation(Mathf.RoundToInt(enemyStrength*1.5f));
                    isPlayerTurn = false;
                }

                //Player hit by critical hit but is still alive
                else
                {
                    gameText.text = enemyName + " lands a <b>CRITICAL</b> hit!!! You take " + Mathf.RoundToInt(enemyStrength * 1.5f) + " damage.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x1.5 enemy damage)</color>";
                    HitAnimation(Mathf.RoundToInt(enemyStrength * 1.5f));
                    isPlayerDodging = false;
                    isPlayerWhacking = false;
                    isPlayerTurn = true;
                }
                
            }

            else
            {
                gameText.text = enemyName + " misses!! You <b><color=lightblue>EVADED</color></b> the attack.\n\n" + "What will the WARRIOR do next?\n\n<color=green>Press A to Attack</color>\n\n<color=yellow>Press W to Whack (x2 damage, +20% enemy evasion)</color>\n\n<color=lightblue>Press D to Dodge (+40% player evasion, x1.5 enemy damage)</color>";
                DebugEnemyAttack("missed",0f);
                isPlayerDodging = false;
                isPlayerWhacking = false;
                isPlayerTurn = true;
            }
        }

        //Randomise Enemy EVASION for extra strategy
        enemyCurrentEvasion = Random.Range(5, enemyBaseEvasion + 30);

        //Player is killed by non-critical attack
        if (playerCurrentHP < 1 && isPlayerDodging == false)
        {
            gameText.text = enemyName + " lands a hit!!! You take " + enemyStrength + " damage.\n\n" + "<color=red>You fall to the ground...</color>\n\nPress SPACEBAR to continue.";
            HitAnimation(enemyStrength);
            DebugEnemyAttack("hit", 1f);
            isPlayerTurn = false;
        }
    }

    void EnemyDefeated()
    {
        //Player gains the potential EXP from the enemy once killed
        currentEXP += potentialEXP;
        Debug.Log("Enemy killed. Player gained " + potentialEXP + " EXP.");

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
        isStatIncrease = true;
        DefaultAnimation();
        playerLVL++;
        playerStrength = Mathf.RoundToInt(playerStrength * 1.75f + 1);
        playerEvasion += 5;
        currentEXP -= maxEXP;
        maxEXP += 10;
        playerMaxHP += 5;
        playerCurrentHP = playerMaxHP;

        enemyCharacter.text = " ";
        gameText.text = "\n<size=60><b><color=green>LEVEL UP  </color><color=#FF00FF>LEVEL UP </color><color=yellow>LEVEL UP  </color></size></b>\n\n" + "Your wounds have been healed. \n\nYou have increased in strength, evasion and max health.\n\n\n" + "Press SPACEBAR to continue";
        

        if(playerLVL == 5)
        {
            hasPlayerWon = true;
        }

        Debug.Log("Player Levelled up to LVL " + playerLVL + ". New player stats are...\nMax HP: " + playerMaxHP + "\nStrength: " + playerStrength + "\nEvasion: " + playerEvasion + "\nEXP cap: " + maxEXP + "\n\n");
    }

    void Victory()
    {
        playerCharacter.text = "\n\n\n\n\n\n                      <color=#02c2ab>██████</color>     <color=#FF69B4>♥       ♥</color>   \n                      ██████  <color=#FF69B4>♥    ♥       ♥</color>\n                      █;█;█   -I'M SO HAPPY!!\n                      ██████   <color=#FF69B4>♥   ♥    ♥   ♥</color>\n                    █<color=#02c2ab>-███████-</color>█   <color=#FF69B4>♥   ♥    ♥</color>\n                      <color=#02c2ab>██</color>  <color=#02c2ab>██</color> \n                      <color=#02c2ab>██████</color>\n                      █  █";
        enemyCharacter.text = string.Empty;
        gameText.text = "Congratulations!! You made it to Level 5. You are our new\n\n\n\n <size=200><color=red>C</color><color=#FFA500>H</color><color=yellow>A</color><color=green>M</color><color=#00FFFF>P</color><color=blue>I</color><color=#BF40BF>O</color><color=#FF00FF>N</color></size>\n\n\n\nPress ESCAPE to play again.";
        isGameEnd = true;
        isLevelingUp = false;
        hasPlayerWon = false;
    }

    //Fuctions for various player text sprites
    #region 
    void AttackAnimation(int hit, string hitormiss)
    {
        playerCharacter.text = "       <color=green>░░░░</color>   \n       <color=green>░</color>█████  \n       <color=green>░</color>█-█-     " + hitormiss + "\n      ▒▒█████  ▒                                          <color=red><b>-" + hit + "hp</color></b>\n      ▒▒<color=green>░░░░░░</color>█▒▒░░░░░░░\n      ▒▒<color=green>░  ░░</color> ▒\n       <color=green>░░░░░</color>\n       █  █";
    }

    void WhackAnimation(int whack, string whackormiss)
    {
        playerCharacter.text = "       <b> <color=yellow>░░░░</color>   \n       <color=yellow>░</color>█████  \n       <color=yellow>░</color>█-█-    <color=grey><b><i>" + whackormiss + "</b></i></color>\n      ▒▒█████  ▒                                 <color=red><size=32></size>-" + whack + "hp</color> \n      ▒▒<color=yellow>░░░░░░</color>█▒▒<color=red>░░</color><color=#FFA500>░░</color><color=yellow>░░</color><color=#00FFFF>░░</color>\n      ▒▒<color=yellow>░  ░░</color> ▒\n       <color=yellow>░░░░░</color>\n       █  █";
    }

    void DodgeAnimation()
    {
        playerCharacter.text = " <color=lightblue>░░░░</color>   ---\n <color=lightblue>░</color>█████  ---\n <color=lightblue>░</color>█-█-   ---\n▒▒█████   ----\n▒▒<color=lightblue>░░░░░░</color>█  ---\n▒▒<color=lightblue>░  ░░</color>  ---\n <color=lightblue>░░░░░░</color>  ---\n █  █  ---";
    }

    void DefaultAnimation()
    {
        playerCharacter.text = " <color=#02c2ab>░░░░░</color>   \n <color=#02c2ab>░</color>█████  ░\n <color=#02c2ab>░</color>█-█-  ░ \n▒▒█████  ░\n▒▒<color=#02c2ab>░░░░░░</color>█▒▒\n▒▒<color=#02c2ab>░</color>  <color=#02c2ab>░░</color> ▒\n <color=#02c2ab>░░░░░</color>\n █  █";
    }

    void HitAnimation(int damage)
    {
        playerCharacter.text = "   <color=#FFA500>░░░░</color>   \n  <color=#FFA500>░</color>█████  \n  <color=#FFA500>░</color>█x█x   <i><color=grey>oof!</color></i>\n ▒▒█████  \n ▒▒<color=#FFA500>░░░░░░</color>█  <color=red><b>-" + damage + "hp</color></b>\n ▒▒<color=#FFA500>░</color>  <color=#FFA500>░░</color> \n  <color=#FFA500>░░░░░</color>\n   █  █";
    }
    #endregion

    void DebugOutAttackStats(string attackType, int buffs, string hitormiss, int damage)
    {
        Debug.Log("Player choose to " + attackType + ".\n" + "Attack value is " + (playerStrength * buffs) + ". He " + hitormiss + " the enemy for " + (damage * buffs) + " damage.\n\n");
    }

    void DebugEnemyAttack(string hitormiss, float multiplyer)
    {
        Debug.Log("Enemy " + hitormiss + " player for " + Mathf.RoundToInt(enemyStrength * multiplyer) + " damage.\n\n");
    }
}
