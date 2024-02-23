using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Returns : MonoBehaviour
{

    public int numberOne;
    public int numberTwo;

    // Start is called before the first frame update
    void Start()
    {
        int resultOne = Multiply(numberOne, numberTwo);
        int resultTwo = Multiply(17, 6);
        int maxHealth = Random.Range(resultOne, resultTwo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Multiply(int firstNumber, int secondNumber)
    {
        Debug.Log(numberOne * numberTwo);
        return firstNumber * secondNumber;
    }
}

