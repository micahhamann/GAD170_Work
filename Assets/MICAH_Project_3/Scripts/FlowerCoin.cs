using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCoin : MonoBehaviour
{

    public GameManager3 gameManager;
    public int coinIndex;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gameManager.coinCount++;
        gameManager.coinsCollected.Add(coinIndex);
        Destroy(gameObject);
    }

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager3>();
    }

    private void Start()
    {
        

        if(gameManager != null)
        {
            for (int i = 0; i < gameManager.coinsCollected.Count; i++)
            {
                if (gameManager.coinsCollected[i] == coinIndex)
                {
                    Destroy(gameObject);
                    Debug.Log("Already collect coin number " + gameManager.coinsCollected[i]);
                }

                else
                {
                    Debug.Log("Have not collected coin number " + gameManager.coinsCollected[i]);
                }
            }
        }

        else
        {
            Debug.Log("No game manager");
        }
        
    }
}
