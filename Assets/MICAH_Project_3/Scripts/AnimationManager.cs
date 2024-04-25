using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public PlayerMovementNew player;

    public AudioClip falling;
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovementNew>();
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

    private void Step()
    {
        AudioClip randomFootstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(randomFootstep);
    }

    public void PlayFootSteps()
    {


        if(player.isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            Step();
        }
    }
}
