using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingReferences : MonoBehaviour
{

    public Transform playerObject;
    public PlayerInput playerReference;

    // Start is called before the first frame update
    void Start()
    {
        //playerReference = playerObject.GetComponent<PlayerInput>();

        playerReference = FindObjectOfType<PlayerInput>(); //It will only find the first instance of PlayerInput.
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput.playerHealth = 10;
    }
}
