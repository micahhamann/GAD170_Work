using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    //I could have used an array of strings instead of custom class, but this is what Brackey did in the tutorial
    public Dialogue dialogueHorse;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;

    //Other variables
    public bool hasTriggered = false;
    public int index; //Unique identifyer of each dialogue trigger

    private void Start()
    {

        //Loop through list of already triggered dialogue
        for (int i = 0; i < GameManager3.instance.dialogueCompleted.Count; i++)
        {
            if (GameManager3.instance.dialogueCompleted[i] == index)
            {
                hasTriggered = true; //if find matching index, set bool to true
                gameObject.GetComponentInChildren<ParticleSystem>()?.Stop();
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !GameManager3.instance.hasPlayerFinished)
        {
            if(!hasTriggered)
            {
                //Play first set of dialogue if this is first time triggering
                GameManager3.instance.dialogueCompleted.Add(index);
                AudioManager3.instance.PlaySoundFX("horse");
                DialogueManager.instance.StartDialogue(dialogueHorse);
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            else if(GameManager3.instance.hasCollectedAllCoins && thirdDialogue != null)
            {          

                //Play third set of dialogue if there is any
                AudioManager3.instance.PlaySoundFX("horse");
                DialogueManager.instance.StartDialogue(thirdDialogue);
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            else
            {
                if(secondDialogue != null)
                {
                    //Play second set of dialogue if trigger has been triggered before
                    AudioManager3.instance.PlaySoundFX("horse");
                    DialogueManager.instance.StartDialogue(secondDialogue);
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                
            }

        }

        else if (other.CompareTag("Player") && GameManager3.instance.hasPlayerFinished)
        {

            //Play end game dialogue (chicken is speaking)
            AudioManager3.instance.PlaySoundFX("cluck");
            DialogueManager.instance.StartEndDialogue(dialogueHorse);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        
    }
}
