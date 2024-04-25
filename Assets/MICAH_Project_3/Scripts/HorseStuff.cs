using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseStuff : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("hasCompletedLevel1", true);
            animator.SetBool("hasCompletedLevel2", true);
            animator.SetBool("hasCompletedLevel3", true);
        }
        
    }
}
