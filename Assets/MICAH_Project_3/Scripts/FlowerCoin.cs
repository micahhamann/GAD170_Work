using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCoin : MonoBehaviour
{

    public ParticleSystem coinGet;
    public int coinIndex;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;

            if (GameManager3.instance != null)
            {
                GameManager3.instance.CoinCounter += 1;
                GameManager3.instance.coinsCollected.Add(coinIndex);
            }

            Destroy(gameObject);
            ParticleSystem clone = Instantiate(coinGet, transform.position, Quaternion.identity);
            Destroy(clone, 2);
        }
                
    }


    private void Start()
    {

        if(GameManager3.instance != null)
        {
            for (int i = 0; i < GameManager3.instance.coinsCollected.Count; i++)
            {
                if (GameManager3.instance.coinsCollected[i] == coinIndex)
                {
                    Destroy(gameObject);
                    Debug.Log("Already collect coin number " + GameManager3.instance.coinsCollected[i]);
                }

                else
                {
                    Debug.Log("Have not collected coin number " + GameManager3.instance.coinsCollected[i]);
                }
            }
        }

        else
        {
            Debug.Log("No game manager");
        }
        
    }
}
