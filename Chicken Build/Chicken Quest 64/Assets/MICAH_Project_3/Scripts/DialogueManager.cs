using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    /// <summary>
    /// Brackeys tutorial on dialogue management helped a lot for this script and other dialogue scripts used in this game
    /// I don't understand the Queue system but it works. I also added original code specific to this game so it wasn't all copied from Brackey.
    /// </summary>

    public static DialogueManager instance; //Singleton: so I can access this script without a local reference
    public Queue<string> sentences = new Queue<string>();

    public TextMeshProUGUI horseText;
    public Animator animator;
    public Sprite chickenTextbox;

    //To ensure there is only on instance of the Dialogue Manager
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

    //Use the SPACEBAR to go to next sentence of dialogue
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

        GameManager3.instance.PausePlayer(); //Diable player controller so player doesn't move or jump when reading text

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //This function is similar to the one above but it uses a different sprite (because the chicken is speaking) and SFX.
    //Also it sends the player to the endgame
    public void StartEndDialogue(Dialogue dialogue)
    {
        animator.gameObject.GetComponent<Image>().sprite = chickenTextbox;
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

                else //If the player has finished, start a new game
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

    //Brackeys function that types out text letter by letter
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
