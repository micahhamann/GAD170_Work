using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogueHorse;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !GameManager3.instance.hasPlayerFinished)
        {
            AudioManager3.instance.PlaySoundFX("horse");
            DialogueManager.instance.StartDialogue(dialogueHorse);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }

        else if (other.CompareTag("Player"))
        {
            DialogueManager.instance.StartEndDialogue(dialogueHorse);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        
    }
}
