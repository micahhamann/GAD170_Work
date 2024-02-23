using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayingText : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = Random.Range(0, 100);

        // access the reference to my piece of text, and access the text string and update it

        scoreText.text = "<color=black>My Score is: </color>" + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
