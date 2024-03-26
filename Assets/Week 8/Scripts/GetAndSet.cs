using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAndSet : MonoBehaviour
{

    private float health = 0f;
    public string myName;

    public float HealthChanger
    {
        get
        {
            Debug.Log(health);
            return health;
        }

        private set
        {
            health = value;
            Debug.Log(health);

            //blood effect
            //oof effect
            //animation code

            if(value > 0)
            {
                //Play healing effect
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthChanger = Random.Range(0, 100);

        //Health -= 20;
        //float tempHealth = Health;
        Debug.Log(HealthChanger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
