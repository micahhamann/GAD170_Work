using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup blackScreen;
    public AudioSource audioSource;
    public AudioClip exit, start;
    public Animator horsePic;

    public float fadeSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager3.instance != null)
        {
            Destroy(GameManager3.instance.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        if (GameManager3.instance != null)
        {
            GameManager3.instance.CoinCounter = 0;
            GameManager3.instance.coinsCollected.Clear();
            GameManager3.instance.hasPlayerFinished = false;


        }

        StartCoroutine(StartTransition());
    }

    public void QuitGame()
    {
        StartCoroutine(EndGame());
    }

    public IEnumerator StartTransition()
    {
        audioSource.PlayOneShot(start);
        horsePic.SetBool("clickedStart", true);

        while (blackScreen.alpha < 1)
        {
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 1, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(6);

        yield return null;

    }

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
