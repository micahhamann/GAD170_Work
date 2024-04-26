using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int coinsRequired = 1; //As all scenes require different amounts of coins, I also used this as a unique identifier
    public BoxCollider sceneTrigger;

    private int initialCoinCount;

    public bool isDoorOpen = false;
    public bool roomComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        initialCoinCount = GameManager3.instance.CoinCounter;
        sceneTrigger.enabled = false;


        //Loop through list of completed rooms and if already completed, set bool
        for (int i = 0; i < GameManager3.instance.roomsCompleted.Count; i++)
        {
            if (GameManager3.instance.roomsCompleted[i] == coinsRequired)
            {
                roomComplete = true;
            }

            else
            {
                Debug.Log("Room is not complete");
            }
        }
    }

    void Update()
    {
        //So I don't have to collect all the coins to test the door, I can just press the "o" key to open doors
        if (Input.GetKeyDown(KeyCode.O))
        {
            DoorOpen();
        }

        //Open door if room has already been completed
        if (roomComplete && !isDoorOpen)
        {
            DoorOpen();
        }

        //Open the door once all coins in room have been collected
        if (GameManager3.instance.CoinCounter >= initialCoinCount + coinsRequired && !isDoorOpen)
        {
            DoorOpen();
            GameManager3.instance.roomsCompleted.Add(coinsRequired); //Add ID to static list of completed rooms
        }

        //Open all doors and play special SFX if player reaches 20 coins
        if (GameManager3.instance.CoinCounter == 20 && !isDoorOpen)
        {
            DoorOpen();
            AudioManager3.instance.PlaySoundFX("victory");
            gameObject.GetComponentInChildren<ParticleSystem>()?.Play();
        }
    }

    public void DoorOpen()
    {
        isDoorOpen = true;
        GetComponent<Animation>().PlayQueued("Open"); //Play open animation
        AudioManager3.instance.PlaySoundFX("doorSlam"); //Play SFX
        sceneTrigger.enabled = true; //turn on scene trigger
    }
}
