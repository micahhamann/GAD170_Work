using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    static public int playerHealth = 50;
    public string playerName;

    // Start is called before the first frame update
    public void Attack()
    {
        Debug.Log(playerName + " attacked!");
    }

    public void Defend()
    {
        Debug.Log(playerName + " defended.");
    }
}
