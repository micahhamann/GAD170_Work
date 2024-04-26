using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public AudioSource music;
    public AudioClip finished;

    //Script used to change the music and set a bool when player reaches final part of the game

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            music.Stop();
            music.clip = finished;
            music.Play();
            GameManager3.instance.hasPlayerFinished = true;
        }
        
    }
}
