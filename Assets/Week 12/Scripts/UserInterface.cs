using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace SAE.GAD170.WeekTwelve
{
    public class UserInterface : MonoBehaviour
    {
        [Header("Main Menu Ui Elements")]
        [SerializeField] private GameObject mainMenuPannel;
        [SerializeField] private GameObject ControlsPannel;
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button controlsMenuButton;
        [SerializeField] private Button controlsBackMenuButton;
        [SerializeField] private Button QuitButton;

        [Header("Main Game Ui Elements")]
        // you'll notice that our for our main game our Ui texts move to here.
        [SerializeField] private TextMeshProUGUI playerCoinTotalUIText;
        [SerializeField] private TextMeshProUGUI doorCoinTotalUIText;

        [Header("Win Game Ui Elements")]
        [SerializeField] private Button goToMainMenuButton;

        [Header("Lose Game Ui Elements")]
        [SerializeField] private Button ReloadGameButton;

        private void OnEnable()
        {
            SubscribeButtonsForMainMenu();
            SubscribeForInGameEvents();
            SubscribeForWinGameEvents();
            SubscribeForLoseGameEvents();
        }

        private void OnDisable()
        {
            UnsubscribeForInGameEvents();
            UnsubscribeButtonsForMainMenu();
            UnsubscribeForWinGameEvents();
            UnsubscribeForLoseGameEvents();
        }

        private void Start()
        {
            // let's get fancy here and let's have the main menu be turned on in the start function.
            // and let's have the control pannel hidden, that way if we've made changes in the editor for what's being show this just auto fixes that when we play.
            Back();
        }

        private void SubscribeButtonsForMainMenu()
        {
            // let's add the load first elvel to our play game button.
            // fun thing, the ? after the playgame button can check for a reference before going further.
            playGameButton?.onClick.AddListener(LoadFirstLevel);
            // now for the controls menu button, let's add the show control function
            // your going to want to make sure you have a reference for the button before accessing it.
            
            // now let's set up the back button for when we are on the controls menu and add the back function
            // your going to want to make sure you have a reference for the button before accessing it.
       
            // finally let's set up the quit button to call the Quit function
            // your going to want to make sure you have a reference for the button before accessing it.
            
        }

        private void UnsubscribeButtonsForMainMenu()
        {
            // best practice is to remove the function from the button too.
            // fun thing, the ? after the playgame button can check for a reference before going further.
            playGameButton?.onClick.RemoveListener(LoadFirstLevel);
            // now for the controls menu button, let's remove the show control function
            // your going to want to make sure you have a reference for the button before accessing it.
          
            // now let's set up the back button for when we are on the controls menu and remove the back function
            // your going to want to make sure you have a reference for the button before accessing it.
           
            // finally let's set up the quit button to remove the Quit function
            // your going to want to make sure you have a reference for the button before accessing it.
            
        }

        private void SubscribeForInGameEvents()
        {
            // subscribe our update player Ui function to our update player coin value event
            CoinGameEvents.UpdatePlayerCoinValueEvent += UpdatePlayerUI;
            // subscribe our UpdateDoorUI function to our UpdateDoorCoinValueEvent 
            
            // here let's subscribe our LoadGameOver function to our GameOverEvent 
           
            // here let's subscribe our LoadWinScreen function to our GameCompletedEvent 
          
        }

        private void UnsubscribeForInGameEvents()
        {
            // unsubscribe our update player Ui function to our update player coin value event
            CoinGameEvents.UpdatePlayerCoinValueEvent -= UpdatePlayerUI;
            // unsubscribe our UpdateDoorUI function to our UpdateDoorCoinValueEvent 
     
            // here let's unsubscribe our LoadGameOver function to our GameOverEvent 
            
            // here let's unsubscribe our LoadWinScreen function to our GameCompletedEvent 
           
        }

        private void SubscribeForWinGameEvents()
        {
            // for our gotoMainMenu button we should have it call the loadMainMenu function
            // your going to want to make sure you have a reference for the button before accessing it.
            
        }

        private void UnsubscribeForWinGameEvents()
        {
            // for our gotoMainMenu button we should have it remove the call to loadMainMenu function
            // your going to want to make sure you have a reference for the button before accessing it.
          
        }

        private void SubscribeForLoseGameEvents()
        {
            // for our ReloadGameButton button we should have it call the loadfirstlevel function
            // your going to want to make sure you have a reference for the button before accessing it.
            
        }

        private void UnsubscribeForLoseGameEvents()
        {
            // for our ReloadGameButton button we should have it remove the call to loadfirstlevel function
            // your going to want to make sure you have a reference for the button before accessing it.
            
        }

        private void UpdatePlayerUI(int coinValue)
        {
            // check the text field for the player coin is not null before accessing.
            if(playerCoinTotalUIText != null)
            {
               
            }
        }

        private void UpdateDoorUI(int coinValue)
        {
            // check the text field for the door coin is not null before accessing.
            if (doorCoinTotalUIText != null)
            {
               
            }
        }

        private void LoadFirstLevel()
        {
            // here we want to load the next scene in the build list.
            // don't forget to add the scenes for this particular week and remember it is a collection i.e. a list.
            // you probably also want the main menu scene to be in the 0 position.
            
        }

        private void LoadGameOver()
        {
            // here we want to call the scene manager to load the scene that has our game over menu.
          
        }

        private void LoadWinScreen()
        {
            // here we want to call our scene manager to load the scene that has our win screen.
            
        }

        private void LoadMainMenu()
        {
            // here we want to call our scene manager to load the scene that has our main menu
           
        }

        private void ShowControls()
        {
            // here we want to show the controls pannel, but hide the main menu pannel.
            // as these are gameobjects we can turn them on/off through code.
            // we should check that we have references to them though, before we try switching them on/off.
            if (mainMenuPannel != null)
            {
               
            }
            if (ControlsPannel != null)
            {
                
            }
        }

        private void Back()
        {
            // here we want to hide the controls pannel, but show the main menu pannel.
            // as these are gameobjects we can turn them on/off through code.
            // we should check that we have references to them though, before we try switching them on/off.
            if (mainMenuPannel != null)
            {
                
            }
            if (ControlsPannel != null)
            {
           
            }
        }

        private void Quit()
        {
            // here we want to call the unity Quit Function. keep in mind this will only work in a build of the game, it doesn't work in editor.
            Application.Quit();
        }

    }
}
