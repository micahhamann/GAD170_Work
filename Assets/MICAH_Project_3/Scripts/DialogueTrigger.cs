using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogueHorse;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public bool hasTriggered = false;
    public int index;

    private void Start()
    {
        for (int i = 0; i < GameManager3.instance.dialogueCompleted.Count; i++)
        {
            if (GameManager3.instance.dialogueCompleted[i] == index)
            {
                hasTriggered = true;
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
                GameManager3.instance.dialogueCompleted.Add(index);
                AudioManager3.instance.PlaySoundFX("horse");
                DialogueManager.instance.StartDialogue(dialogueHorse);
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            else if(GameManager3.instance.hasCollectedAllCoins && thirdDialogue != null)
            {          
                AudioManager3.instance.PlaySoundFX("horse");
                DialogueManager.instance.StartDialogue(thirdDialogue);
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            else
            {
                AudioManager3.instance.PlaySoundFX("horse");
                DialogueManager.instance.StartDialogue(secondDialogue);
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
            
        }

        else if (other.CompareTag("Player"))
        {
            DialogueManager.instance.StartEndDialogue(dialogueHorse);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        
    }
}
