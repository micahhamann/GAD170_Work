using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
    public GameObject mainMenuPannel;
    public GameObject ControlsPannel;

    private void Start()
    {
        // let's get fancy here and let's have the main menu be turned on in the start function.
        // and let's have the control pannel hidden, that way if we've made changes in the editor for what's being show this just auto fixes that when we play.
        Back();
    }

    public void LoadFirstLevel()
    {
        // here we want to load the next scene in the build list.
        // don't forget to add the scenes for this particular week and remember it is a collection i.e. a list.
        // you probably also want the main menu scene to be in the 0 position.
        
    }

    public void LoadGameOver()
    {
        // here we want to call the scene manager to load the scene that has our game over menu.
      
    }

    public void LoadWinScreen()
    {
        // here we want to call our scene manager to load the scene that has our win screen.
        
    }
    
    public void LoadMainMenu()
    {
        // here we want to call our scene manager to load the scene that has our main menu
        
    }

    public void ShowControls()
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

    public void Back()
    {
        // here we want to hide the controls pannel, but show the main menu pannel.
        // as these are gameobjects we can turn them on/off through code.
        // we should check that we have references to them though, before we try switching them on/off.
        
    }


    public void Quit()
    {
        // here we want to call the unity Quit Function. keep in mind this will only work in a build of the game, it doesn't work in editor.
        Application.Quit();
    }

}
