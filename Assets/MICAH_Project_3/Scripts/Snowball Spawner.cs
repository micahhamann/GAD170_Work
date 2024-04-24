using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    public GameObject snowballPrefab;
    public int numberOfSnowballs = 2;

    public Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(BallSpawner());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSnowball(Vector3 spawnPoint)
    {
        Instantiate(snowballPrefab, spawnPoint, snowballPrefab.transform.rotation);
    }

    private IEnumerator BallSpawner()
    {
        for (int i = 0; i < numberOfSnowballs; i++)
        {
            float x = transform.position.x + Random.Range(-10, 10);
            float y = transform.position.y + Random.Range(-10, 10);
            float z = transform.position.z + Random.Range(-10, 10);

            SpawnSnowball(new Vector3(x, y, z));

            yield return new WaitForSeconds(5);
        }

        coroutine = null;

        yield return null;
    }

}
