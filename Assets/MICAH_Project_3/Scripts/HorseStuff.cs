using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseStuff : MonoBehaviour
{

    public Animator animator;
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("hasCompletedLevel1", true);
            animator.SetBool("hasCompletedLevel2", true);
            animator.SetBool("hasCompletedLevel3", true);
            boxCollider.enabled = true;
        }
    }
}
