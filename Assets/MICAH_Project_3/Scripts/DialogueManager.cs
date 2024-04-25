using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Queue<string> sentences = new Queue<string>();

    public TextMeshProUGUI horseText;
    public Animator animator;

    public Sprite chicken;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isHorseSpeaking", true);

        GameManager3.instance.PausePlayer();

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartEndDialogue(Dialogue dialogue)
    {
        animator.gameObject.GetComponent<Image>().sprite = chicken;
        animator.SetBool("isHorseSpeaking", true);

        GameManager3.instance.PausePlayer();

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (animator.GetBool("isHorseSpeaking"))
        {
            if (sentences.Count == 0)
            {
                if (!GameManager3.instance.hasPlayerFinished)
                {
                    EndDialogue();
                    return;
                }

                else
                {
                    EndDialogue();
                    GameManager3.instance.NewGame();
                    return;
                }
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        else
        {
            return;
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        horseText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            horseText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isHorseSpeaking", false);
        GameManager3.instance.UnpausePlayer();
    }
}
