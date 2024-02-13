using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekTwelve
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private int numberOfCoins = 5;
        [SerializeField] private float coinPositionOffSetX = 1.5f;
        [SerializeField] private List<Coin> allCoinsSpawnedIn = new List<Coin>();

        private void OnEnable()
        {
            // here let's subscribe our add coin and remove coin functions to our spawn coin event and despawn coin event respectively.
            
        }

        private void OnDisable()
        {
            // here let's unsubscribe our add coin and remove coin functions to our spawn coin event and despawn coin event respectively.
            
        }

        // Start is called before the first frame update
        void Start()
        {
            SpawnCoins();
        }

        void SpawnCoins()
        {
            // lets spawn in a number of coins based on our variable above
            // we should loop to do this.
            for (int i = 0; i < 1; i++)
            {
                // here lets for our offset, for the x float, let's have it be our coin position offset, multiplied by i
                // if we want to get fancy here, we could also have an offset for the y.
                Vector3 offset = new Vector3(i,0, 0);
                Instantiate(coinPrefab, transform.position + offset, coinPrefab.transform.rotation);
            }
        }

        private void AddCoin(Coin coinToAdd)
        {
            // add the coin coming in to our list of coins.
        
        }

        private void RemoveCoin(Coin coinToRemove)
        {
            // remove the coin coming in from out list of coins.
            
        }

        private void OnDrawGizmos()
        {
            // can ignore this, this just creates a viewable sphere in the scene
            // that way you can see where the pos of the coin spawner is.
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1);
        }
    }
}
