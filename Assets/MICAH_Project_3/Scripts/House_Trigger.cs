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
        moveBlock = movingBlock.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Ball"))
        {
            moveBlock.Play("MovingCube");
        }

        else
        {
            Debug.Log("Wrong Tag");
        }
    }
}
