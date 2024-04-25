using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public GameObject player;

    public List<int> coinsCollected = new List<int>();
    private int coinCount = 0;
    public List<int> dialogueCompleted = new List<int>();
    public List<int> roomsCompleted = new List<int>();

    public CanvasGroup fadeSlider;
    public CanvasGroup blackScreen;

    public Slider slider;
    public ParticleSystem sliderMove;
    public ParticleSystem allCoinsCollected;
  

    public float fadeSpeed = 0.5f;

    public bool isDead = false;
    public bool hasCollectedAllCoins = false;
    public bool hasPlayerFinished = false;

    private Coroutine fadeToBlack;
    private Coroutine chickenDead;

    public int CoinCounter
    {
        get
        {
            return coinCount;
        }

        set
        {

            coinCount = value;

            AudioManager3.instance.PlaySoundFX("coin");
            slider.GetComponentInChildren<Animation>()?.Play("SliderGrow");

            if (coinCount == 20)
            {
                hasCollectedAllCoins = true;
            }
        }
    }

    public TextMeshProUGUI score;




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

    // Start is called before the first frame update
    void Start()
    {
        fadeSlider.alpha = 0;
        StartCoroutine(FadeIn());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + coinCount;
        slider.value = coinCount;


        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    public void NewTurn(Vector3 spawnPoint, string animationType)
    {
        if (chickenDead == null)
        {
            chickenDead = StartCoroutine(ChickenDead(spawnPoint, animationType));
        }
    }


    public void NewGame()
    {
        if (fadeToBlack == null)
        {
            fadeToBlack = StartCoroutine(SceneTransition(0));
            
        }
    }

    public void NewScene(int scene)
    {
        if (fadeToBlack == null)
        {
            fadeToBlack = StartCoroutine(SceneTransition(scene));
        }
    }

    private IEnumerator SceneTransition(int scene)
    {
        AudioManager3.instance.PlaySoundFX("doorOpen");
        Debug.Log("Coroutine has started");

        AudioManager3.instance.PlaySoundFX("slideDown");
        fadeSlider.alpha = 0;
        while (blackScreen.alpha < 1)
        {
            
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 1, Time.deltaTime * fadeSpeed);
            Debug.Log("moving up");
            yield return null;
        }

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);

        AudioManager3.instance.PlaySoundFX("slideUp");
        while (blackScreen.alpha > 0)
        {
            
            blackScreen.alpha = Mathf.MoveTowards(blackScreen.alpha, 0, Time.deltaTime * fadeSpeed);
            Debug.Log("moving down");
            yield return null;
        }
        fadeSlider.alpha = 1;

        fadeToBlack = null;

        yield return null;

    }

    private IEnumerator ChickenDead(Vector3 spawnPoint, string animationType)
    {
        player.GetComponent<PlayerMovementNew>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        Animator animation = player.GetComponent<Animator>();
        animation.SetBool("isDead", true);
        AudioManager3.instance.PlaySoundFX("death");

        yield return new WaitForSeconds(2.5f);
        
        animation.SetBool("isDead", false);
        player.transform.position = spawnPoint;

        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerMovementNew>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        GameObject.FindGameObjectWithTag("obstacle")?.GetComponent<Animation>().Play();




        isDead = true;

        chickenDead = null;

        yield return null;
    }

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
