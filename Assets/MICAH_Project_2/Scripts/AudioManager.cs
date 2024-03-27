using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioListener listener;

    public AudioSource clipPlayer;
    public AudioSource musicPlayer;

    public AudioClip buttonGeneral;
    public AudioClip hireButton;
    public AudioClip gameOverSound;
    public AudioClip declineButton;
    public AudioClip gameMusic;
    public AudioClip newRecruitButton;
    public AudioClip parasiteFound;
    public AudioClip victoryMusic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSounds(int index)
    {
        switch (index)
        {
            case 0:
                clipPlayer.PlayOneShot(buttonGeneral);
                break;

            case 1:
                clipPlayer.PlayOneShot(hireButton);
                break;

            case 2:
                clipPlayer.PlayOneShot(declineButton);
                break;

            case 3:
                clipPlayer.PlayOneShot(newRecruitButton);
                break;

            default:
                break;
        }
    }

    public void PlayParasiteSounds()
    {
        clipPlayer.PlayOneShot(parasiteFound);
    }

    public void PlayVictoryMusic()
    {
        musicPlayer.Pause();
        clipPlayer.PlayOneShot(victoryMusic);
    }

    public void PlayGameOverMusic()
    {
        musicPlayer.Pause();
        clipPlayer.PlayOneShot(gameOverSound);
    }
}
