using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Not sure if I need this but reference to audio listener
    public AudioListener listener;

    //Reference to audio sources
    public AudioSource clipPlayer;
    public AudioSource musicPlayer;

    //Reference to audio clips
    public AudioClip buttonGeneral;
    public AudioClip hireButton;
    public AudioClip gameOverSound;
    public AudioClip declineButton;
    public AudioClip newRecruitButton;
    public AudioClip parasiteFound;
    public AudioClip victoryMusic;

    //Called when buttons are pressed. The index of the button determines the sound that is played
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

    //Called when parasite is hired
    public void PlayParasiteSounds()
    {
        clipPlayer.PlayOneShot(parasiteFound);
    }

    //Called when player has won
    public void PlayVictoryMusic()
    {
        musicPlayer.Pause();
        clipPlayer.PlayOneShot(victoryMusic);
    }

    //Called when player has lost
    public void PlayGameOverMusic()
    {
        musicPlayer.Pause();
        clipPlayer.PlayOneShot(gameOverSound);
    }
}
