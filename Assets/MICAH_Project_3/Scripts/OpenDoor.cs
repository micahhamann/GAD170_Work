using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int coinsRequired = 1;
    public BoxCollider sceneTrigger;

    private int initialCoinCount;

    public bool isDoorOpen = false;
    public bool roomComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        initialCoinCount = GameManager3.instance.CoinCounter;
        sceneTrigger.enabled = false;

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

    // Update is called once per frame
    void Update()
    {
        //So I don't have to collect all the coins to test the door
        if(Input.GetKeyDown(KeyCode.O))
        {
            isDoorOpen = true;
            GetComponent<Animation>().PlayQueued("Open");
            sceneTrigger.enabled = true;
        }

        if(roomComplete && !isDoorOpen)
        {
            isDoorOpen = true;
            GetComponent<Animation>().PlayQueued("Open");
            sceneTrigger.enabled = true;
        }

        if(GameManager3.instance.CoinCounter >= initialCoinCount + coinsRequired && !isDoorOpen)
        {
            isDoorOpen = true;
            GetComponent<Animation>().PlayQueued("Open");
            sceneTrigger.enabled = true;
            GameManager3.instance.roomsCompleted.Add(coinsRequired);
        }

        if(GameManager3.instance.CoinCounter == 20 && !isDoorOpen)
        {
            isDoorOpen = true;
            GetComponent<Animation>().PlayQueued("Open");
            sceneTrigger.enabled = true;
            AudioManager3.instance.PlaySoundFX("victory");
            gameObject.GetComponentInChildren<ParticleSystem>()?.Play();
        }
    }
}
