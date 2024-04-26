using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Trigger : MonoBehaviour
{

    public GameObject movingBlock;
    public Animation moveBlock;

    // Start is called before the first frame update
    void Start()
    {
        moveBlock = movingBlock.GetComponent<Animation>(); //Get reference to ball animator
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Ball"))
        {
            //If ball enters trigger, make block move up and down and play SFX
            moveBlock.Play("MovingCube");
            AudioManager3.instance.PlaySoundFX("click");
            AudioManager3.instance.PlaySoundFX("success");
        }

        else
        {
            Debug.Log("Wrong Tag");
        }
    }
}
