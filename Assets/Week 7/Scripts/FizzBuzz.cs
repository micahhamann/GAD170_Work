using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    /*
     *  Print out the numbers from 1-100
     *  For the number is divisible by 3 print out fizz
     *  For the number is divisible by 5 print out buzz
     *  For the numbers divisible by 3 and 5, print out fizz buzz.
     *  Example Output
        *  1
        *  2
        *  Fizz
        *  4
        *  Buzz
        *  Etc.
        *  14
        *  FizzBuzz
     * hint there are multiple ways to achieve this, if you get stuck, modulo operator (%) will be your friend.
     */

    public int min = 1;
    public int max = 100;
    private List<string> numberList = new List<string>();
    private string printList;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = min; i < max + 1; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
            {
                numberList.Add("Fizz");
            }

            else if (i % 5 == 0 && i % 3 != 0)
            {
                numberList.Add("Buzz");
            }

            else if (i % 3 == 0 && i % 5 == 0)
            {
                numberList.Add("Fizz Buzz");
            }

            else
            {
                numberList.Add(i.ToString());
            }
        }

        foreach (string str in numberList)
        {
            printList += str + "\n";
        }

        Debug.Log(printList);
    }

}
