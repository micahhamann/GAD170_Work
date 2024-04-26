using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //REference to UI elements
    public CanvasGroup blackScreen;
    public AudioSource audioSource;
    public AudioClip exit, start;
    public Animator horsePic;

    public float fadeSpeed = 0.5f;

    // VERY IMPORTANT - we destroy the GameManager to ensure the game is reset and you can start from the beginning
    void Start()
    {
        if(GameManager3.instance != null)
        {
            Destroy(GameManager3.instance.gameObject);
        }
    }


    public void NewGame()
    {
        //Load the hub world
        StartCoroutine(StartTransition());
    }

    //Calls the exit game function
    public void QuitGame()
    {
        StartCoroutine(EndGame());
    }

    //Fades out the screen and loads the hub world.
    public IEnumerator StartTransition()
    {
        audioSource.PlayOneShot(start);
        horsePic.SetBool("clickedStart", true); //triggers new horse animation

        while (blackScreen.alpha < 1)
        {
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 1, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(6);

        yield return null;

    }

    //Fades to black over time and quits the application when running
    public IEnumerator EndGame()
    {
        audioSource.PlayOneShot(exit);
        while (blackScreen.alpha < 1)
        {
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 1, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        yield return new WaitForSeconds(2);

        Application.Quit(); 

    }
}
