using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager3 : MonoBehaviour
{
    #region
    public static AudioManager3 instance;

    public AudioClip doorOpen, doorSlam, death, slideUp, slideDown, coin, falling, horse, victory, success, click, cluck, lava;
    public AudioClip[] footStepClips;
    public AudioClip[] boingClips;

    public AudioSource audioSource;

    public float maxPitch = 0.9f, minPitch = 1.1f;
    #endregion

    //Ensure that this instance of AudioManager remains the only instance throughout the game
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

    //Get reference to audioSource
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Fuction used by other scripts to play SFX
    public void PlaySoundFX(string name)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);

        switch (name)//There is probably a more efficient way to do this but this method worked fine
        {
            case "doorOpen":
                audioSource.PlayOneShot(doorOpen, 0.8f);
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

            case "boing":
                audioSource.PlayOneShot(boingClips[Random.Range(0, boingClips.Length)]); //randomise boing sounds
                break;

            case "success":
                audioSource.PlayOneShot(success);
                break;

            case "click":
                audioSource.PlayOneShot(click);
                break;

            case "cluck":
                audioSource.PlayOneShot(cluck);
                break;

            case "lava":
                audioSource.PlayOneShot(lava);
                break;


            default:
                Debug.Log("UnrecognisedSound");
                break;
        }

    }


}
