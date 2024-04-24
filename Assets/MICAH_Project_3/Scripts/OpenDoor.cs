using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int coinsRequired = 1;
    public BoxCollider sceneTrigger;

    private int initialCoinCount;

    public bool isDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        initialCoinCount = GameManager3.instance.CoinCounter;
        sceneTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<Animation>().PlayQueued("Open");
        }

        if(GameManager3.instance.CoinCounter >= initialCoinCount + coinsRequired && !isDoorOpen)
        {
            isDoorOpen = true;
            GetComponent<Animation>().PlayQueued("Open");
            sceneTrigger.enabled = true;
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
