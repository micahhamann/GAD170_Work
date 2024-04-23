using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;

    public List<int> coinsCollected = new List<int>();
    public int coinCount = 0;

    public TextMeshProUGUI score;
    

    

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + coinCount;
    }
}
