using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInput playerOne;
    public PlayerInput playerTwo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (playerOne != null)
            {
                playerOne.Attack();
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            playerOne.Defend();
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            playerTwo.Attack();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            playerTwo.Defend();
        }
    }
}
