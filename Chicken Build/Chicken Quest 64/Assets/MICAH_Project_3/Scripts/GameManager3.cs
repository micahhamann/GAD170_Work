using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    //REFERENCES
    #region
    public static GameManager3 instance;
    public GameObject player;

    public List<int> coinsCollected = new List<int>();
    private int coinCount = 0; 
    public List<int> dialogueCompleted = new List<int>();
    public List<int> roomsCompleted = new List<int>();

    //reference to black screen used to make scene transitions more appealing
    public CanvasGroup fadeSlider; //Used to alter the transparency of the black screen
    public CanvasGroup blackScreen;
    public Slider slider;  
    public float fadeSpeed = 0.5f;
    public TextMeshProUGUI score;

    public bool isDead = false;
    public bool hasCollectedAllCoins = false;
    public bool hasPlayerFinished = false;

    private Coroutine fadeToBlack;
    private Coroutine chickenDead;
    #endregion

    //Getter and setter used for encapsulation
    public int CoinCounter
    {
        get
        {
            return coinCount;
        }

        set
        {

            coinCount = value;

            //Everytime the coin count is changed, play audio and animation
            AudioManager3.instance.PlaySoundFX("coin"); 
            slider.GetComponentInChildren<Animation>()?.Play("SliderGrow");

            if (coinCount == 20)
            {
                hasCollectedAllCoins = true;
            }
        }
    }

    //To ensure the same GameManager is used throughout the game and not destroyed upon scene change
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        fadeSlider.alpha = 0;
        StartCoroutine(FadeIn()); //Black screen fades away
        player = GameObject.FindGameObjectWithTag("Player"); //Find reference to player
    }

    void Update()
    {
        score.text = "" + coinCount; //Displays correct coin count on UI
        slider.value = coinCount; //Slider in correct location


        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); //Ensuring there is always a reference to the player
        }


    }

    //A new turn is declared everytime the chicken is killed by a deadly obstacle
    public void NewTurn(Vector3 spawnPoint)
    {
        if (chickenDead == null) //Checking if the coroutine isn't already playing to avoid them playing on top of each other
        {
            chickenDead = StartCoroutine(ChickenDead(spawnPoint)); //Pass in spawn point to tell where to respawn the player
        }
    }

    //New game is called upon game completion - sends player back to main menu
    public void NewGame()
    {
        if (fadeToBlack == null) //Check to see if coroutine isn't already running
        {
            fadeToBlack = StartCoroutine(SceneTransition(0));
            
        }
    }

    //Pass in scene index to choose which scene to transition to
    public void NewScene(int scene)
    {
        if (fadeToBlack == null)
        {
            fadeToBlack = StartCoroutine(SceneTransition(scene));
        }
    }

    //Use Coroutine to do time-based commands
    private IEnumerator SceneTransition(int scene)
    {
        AudioManager3.instance.PlaySoundFX("doorOpen");
        Debug.Log("Coroutine has started");

        AudioManager3.instance.PlaySoundFX("slideDown");
        fadeSlider.alpha = 0;
        while (blackScreen.alpha < 1) //Fade in black screen - Same way Nathan did it in tutorial
        {
            
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 1, Time.deltaTime * fadeSpeed);
            Debug.Log("moving up");
            yield return null;
        }

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);

        AudioManager3.instance.PlaySoundFX("slideUp");
        while (blackScreen.alpha > 0) //Fade out black screen
        {
            
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 0, Time.deltaTime * fadeSpeed);
            Debug.Log("moving down");
            yield return null;
        }
        fadeSlider.alpha = 1;

        fadeToBlack = null;

        yield return null;

    }

    private IEnumerator ChickenDead(Vector3 spawnPoint)
    {

        //Diable player movement while death animation is in affect
        player.GetComponent<PlayerMovementNew>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        //Play death animation and SFX
        Animator animation = player.GetComponent<Animator>();
        animation.SetBool("isDead", true);
        Debug.Log("is dead");
        AudioManager3.instance.PlaySoundFX("death");

        yield return new WaitForSeconds(2.5f);
        
        animation.SetBool("isDead", false);
        player.transform.position = spawnPoint; //Send player to respawn position

        yield return new WaitForSeconds(0.5f);

        //Enable player movement
        player.GetComponent<PlayerMovementNew>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;

        //If obstacle that killed chicken has an animation that has stopped, play it upon respawn
        GameObject.FindGameObjectWithTag("obstacle")?.GetComponent<Animation>().Play();

        isDead = true;

        chickenDead = null;

        yield return null;
    }

    //Functions to disable/enable player movement
    public void PausePlayer()
    {

        player.GetComponent<PlayerMovementNew>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().Play("Listen");
        
    }

    public void UnpausePlayer()
    {
        player.GetComponent<PlayerMovementNew>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Animator>().Play("Idle");
    }

    //Coroutine to fade to black used for scene transitions
    public IEnumerator FadeIn()
    {
        blackScreen.alpha = 1;
        while (blackScreen.alpha > 0)
        {
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 0, Time.deltaTime * 2);
            yield return null;
        }

        fadeSlider.alpha = 1;
    }
}
