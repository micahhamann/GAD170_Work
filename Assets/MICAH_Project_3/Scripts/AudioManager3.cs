using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager3 : MonoBehaviour
{
    public static AudioManager3 instance;

    public AudioClip doorOpen, doorSlam, death, slideUp, slideDown, coin, falling, horse, victory;
    public AudioClip[] footStepClips;

    public AudioSource audioSource;



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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundFX(string name)
    {
        switch (name)
        {
            case "doorOpen":
                audioSource.PlayOneShot(doorOpen, 0.5f);
                break;

            case "doorSlam":
                audioSource.PlayOneShot(doorSlam);
                break;

            case "slideUp":
                audioSource.PlayOneShot(slideUp);
                break;

            case "slideDown":
                audioSource.PlayOneShot(slideDown);
                break;

            case "death":
                audioSource.PlayOneShot(death);
                break;

            case "coin":
                audioSource.PlayOneShot(coin);
                break;

            case "horse":
                audioSource.PlayOneShot(horse);
                break;

            case "victory":
                audioSource.PlayOneShot(victory);
                break;


            default:
                Debug.Log("UnrecognisedSound");
                break;
        }

    }


}
