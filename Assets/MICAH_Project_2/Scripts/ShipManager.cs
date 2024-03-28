using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    //Lists that get popluating during the game loop
    public List<Crewmate> shipList = new List<Crewmate>();
    public List<Crewmate> knownParasiteList = new List<Crewmate>();

    //References to other scripts and game objects
    public AudioManager audioManager;
    public GameObject crewmatePrefab;
    public UIManager uIManager;
    public Crewmate crewmate;

    //other variables
    public bool hasParasiteAttacked = false;
    public int difficulty;


    // Start is called before the first frame update
    void Start() //Clears all lists and sets the game up as new
    {
        shipList.Clear();
        knownParasiteList.Clear();
        uIManager.titleScreen.SetActive(true); //Displays the title screen so player can choose their difficulty
        hasParasiteAttacked = false;
        uIManager.ClearText();
        crewmate = null;
        uIManager.victoryPanel.SetActive(false);
        uIManager.gameOverPanel.SetActive(false);
        uIManager.UpdateCrewDisplay();
        uIManager.UpdateParasiteDisplay();

        uIManager.acceptButton.gameObject.SetActive(false);
        uIManager.rejectButton.gameObject.SetActive(false);
        uIManager.newRecruitButton.gameObject.SetActive(true);
        uIManager.AddText("Welcome Commander! The new recruits have arrived. \n\nThere have been rumours of <color=green>PARASITES</color> acting as humans. Make sure you don't hire any of those suckers.");
        uIManager.AddText("Click NEW RECRUIT to start.");
    }

    public void OnAcceptClick()
    {

        uIManager.ClearText();
        uIManager.newRecruitButton.gameObject.SetActive(true);
        uIManager.acceptButton.gameObject.SetActive(false);
        uIManager.rejectButton.gameObject.SetActive(false);
        
        if(crewmate.isParasite && knownParasiteList.Count < 4) //Checks to see if crewmate is a parasite
        {
            ParasiteHired(crewmate.GetHobby()); //If so, trigger parasite sequence

            if (knownParasiteList.Count == 4) //If the player has lost, call the gameOver sequence
            {
                GameOver();
            }
        }

        else
        {
            if (shipList.Count < 10) //Checks to see if player has won yet
            {
                shipList.Add(crewmate);

                if (shipList.Count == 10 && knownParasiteList.Count != 4) //If the player has won, call Victory function
                {
                    Victory();
                }

                uIManager.UpdateCrewDisplay();
                uIManager.AddText("Good choice. " + crewmate.GetPronoun(crewmate.isMale) + " is not a parasite.");
            }

            else
            {
                Debug.Log("Cannot add more than 10 crew to list");
            }
        }

        crewmate = null; //Empty crewmate slot for incoming recruit
    }

    //Called by clicking the new recruit button. This acts as a NEW TURN of the game
    public void OnNewRecruitClick()
    {

        RemoveTheDead(); //removes all players that have been killed by parasites, if any
        uIManager.UpdateCrewDisplay(); //Updates display to show alive crew, if any
        uIManager.ClearText();
        uIManager.AddText("Hmm... what do you think about this recruit, Commander? Accept or Reject?");
        uIManager.newRecruitButton.gameObject.SetActive(false);
        uIManager.acceptButton.gameObject.SetActive(true);
        uIManager.rejectButton.gameObject.SetActive(true);

        //CREWMATE INSTANTIATION - VERY IMPORTANT CODE!!!

        GameObject crewClone = Instantiate(crewmatePrefab); //assigns new instance to clone
        crewmate = crewClone.GetComponent<Crewmate>(); //places clone in crewmate slot
        crewmate.Setup(); //Sets the randomised crew variables
        crewmate.SetParasiteCondition(difficulty); //Sets the parasite condition depending on which difficulty the play chose
    }

    //Called by pressing the reject button
    public void OnRejectClick()
    {
        uIManager.ClearText();
        uIManager.newRecruitButton.gameObject.SetActive(true);
        uIManager.acceptButton.gameObject.SetActive(false);
        uIManager.rejectButton.gameObject.SetActive(false);
        crewmate.DestroyCrewmate(); //Remove instance of crewmember gameobject from game

        if(crewmate.isParasite)
        {
            uIManager.AddText("Yeah... " + crewmate.GetPronoun(crewmate.isMale) + " was a parasite I reckon. Can't be sure though.");
        }

        else
        {
            uIManager.AddText("I'm don't think that was a parasite. Just sayin'.");
            uIManager.AddText("Tip: Click on the recruit portraits to view their information again.");
        }

        crewmate = null;

    }

    // called when a parasite is hired
    public void ParasiteHired(string hobby)
    {
        audioManager.PlayParasiteSounds();
        hasParasiteAttacked = true;
        knownParasiteList.Add(crewmate); //Add to parasite list
        uIManager.AddText("Nooooo! That was a <color=green>PARASITE</color>!\n\n" + crewmate.GetPronoun(crewmate.isMale) + " has eaten everyone who likes " + hobby + ".");
        uIManager.UpdateParasiteDisplay(); //Display new parasite in UI

        for (int i = 0; i < shipList.Count; i++) //Loops through shipList and makes any crew with the same hobby with death sprite
        {
            if (shipList[i].GetHobby() == knownParasiteList[knownParasiteList.Count - 1].GetHobby())
            {
                uIManager.crewHairDisplay[i].sprite = uIManager.deathSprite;
                uIManager.crewFaceDisplay[i].sprite = uIManager.deathSprite;

            }

        }

    }

    // Removes all those marked for death from the ship list
    public void RemoveTheDead()
    {
        
        if (hasParasiteAttacked)
        {

            //Loop through backwards as it messes with the loop if you go forwards. Figured this out the hard way.
            for (int i = shipList.Count - 1; i >= 0; i--) 
            {
                if (uIManager.crewHairDisplay[i].sprite == uIManager.deathSprite)
                {
                    Debug.Log("Dead removed at " + i);
                    shipList[i].DestroyCrewmate();
                    shipList.RemoveAt(i);

                }

                else
                {
                    Debug.Log("Not dead at " + i);
                }
              
            }

            
        }

        hasParasiteAttacked = false;
        crewmate = null;
    }

        
    
    //Called when victory condition is met
    public void Victory()
    {
        audioManager.PlayVictoryMusic();
        uIManager.victoryPanel.SetActive(true);
        uIManager.PopulateEndGame(); // Shows your crew in a bigger display
        uIManager.AllButtonsOff();
    }

    //Called when lose condition is met
    public void GameOver()
    {
        audioManager.PlayGameOverMusic();
        uIManager.gameOverPanel.SetActive(true);
        uIManager.AllButtonsOff();
        uIManager.PopulateEndGame(); //Shows the parasites in a bigger display
    }

    //Called when player clicks New Game button
    public void OnNewGameClick()
    {
        audioManager.musicPlayer.UnPause();
        audioManager.clipPlayer.Stop();
        uIManager.victoryPanel.SetActive(false);
        CompletionIcons(); //Shows completed icon for chosen difficulty


        for (int i = shipList.Count - 1; i >= 0; i--) //Loops backwards through list and detroys all instances of crewmates
        {
            shipList[i].DestroyCrewmate();
        }

        for (int i = knownParasiteList.Count - 1; i >= 0; i--) //Loops backwards through list and detroys all instances of parasites
        {
            knownParasiteList[i].DestroyCrewmate();
        }

        //VERY IMPORTANT. Clicking the new game button calls the Start function that restarts the game

        Start();

    }

    //This function allows players to click on crew members and parasites in the list to view their information.
    //This is a very handy feature that I enjoyed implementing
    //The button click feeds an integer to the function which determines its use
    public void OnSlotClick(int buttonIndex)
    {

        if (shipList.Count != 0) //Out of range check
        {
            if (buttonIndex <= shipList.Count)
            {
                uIManager.ClearText();

                switch (buttonIndex)
                {
                    case 0:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 1:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 2:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 3:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 4:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 5:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 6:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 7:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 8:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;

                    case 9:

                        uIManager.AddText(CrewInfo(buttonIndex));
                        break;


                    default:
                        break;
                }
            }

            else
            {
                Debug.Log("No recruit found in this slot");
            }
        }

        else
        {
            Debug.Log("No recruit found in this slot");
        }
        
    }

    //Same function as above but with parasite slots
    public void OnParasiteSlotClick(int buttonIndex)
    {
        if (knownParasiteList.Count != 0)
        {
            if (buttonIndex <= knownParasiteList.Count)
            {
                uIManager.ClearText();

                switch (buttonIndex)
                {
                    case 0:

                        uIManager.AddText(ParasiteInfo(buttonIndex));
                        break;

                    case 1:

                        uIManager.AddText(ParasiteInfo(buttonIndex));
                        break;

                    case 2:

                        uIManager.AddText(ParasiteInfo(buttonIndex));
                        break;

                    case 3:

                        uIManager.AddText(ParasiteInfo(buttonIndex));
                        break;

                    default:

                        break;

                }
            }

            else
            {
                Debug.Log("No parasite found in this slot");
            }
        }

        else
        {
            Debug.Log("No parasite found in this slot");
        }
    }

    //Display info in text panel when player clicks on portrait
    public string CrewInfo(int index)
    {
        return "<color=#00FFFF>ALERT: CONFIRMED HUMAN</color>\nThis is " + shipList[index].GetName() + ". \n\n" + shipList[index].GetPronoun(shipList[index].isMale) + " likes " + shipList[index].GetHobby() + ".\n\nQuote: " + shipList[index].GetQuote();
    }

    public string ParasiteInfo(int index)
    {
        return "<color=red>WARNING: KNOWN PARASITE</color>\nThis is " + knownParasiteList[index].GetName() + ". \n\n" + knownParasiteList[index].GetPronoun(knownParasiteList[index].isMale) + " likes " + knownParasiteList[index].GetHobby() + ".\n\nQuote: " + knownParasiteList[index].GetQuote();
    }

    //Choses the difficulty depending on which button you press at the start
    public void PickDifficulty(int buttonIndex)
    {
        uIManager.titleScreen.SetActive(false);

        switch (buttonIndex)
        {
            case 0:
                difficulty = 0;
                break;

            case 1:
                difficulty = 1;
                break;

            case 2:
                difficulty = 2;
                break;

            case 3:
                difficulty = 3;
                break;

            default:
                difficulty = 0;
                break;

        }

       
    }

    //Shows a star next to difficulty button when completed
    public void CompletionIcons()
    {
        if (shipList.Count == 10 && difficulty == 0)
        {
            uIManager.easyComplete.gameObject.SetActive(true);
        }

        else if (shipList.Count == 10 && difficulty == 1)
        {
            uIManager.mediumComplete.gameObject.SetActive(true);
        }

        else if (shipList.Count == 10 && difficulty == 2)
        {
            uIManager.hardComplete.gameObject.SetActive(true);
        }

        else if (shipList.Count == 10 && difficulty == 3)
        {
            uIManager.veryHardComplete.gameObject.SetActive(true);
        }

        else
        {
            return;
        }
    }
}
