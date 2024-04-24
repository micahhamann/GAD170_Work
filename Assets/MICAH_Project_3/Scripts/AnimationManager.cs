using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    public AudioClip falling;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerMovementNew>().isGrounded && audioSource.clip == falling)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }

    public void PlayFallingSound()
    {
        if (!GetComponent<PlayerMovementNew>().isGrounded)
        {
            audioSource.clip = falling;
            audioSource.Play();
        }
            

    }
}
