using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operands : MonoBehaviour
{
    public int numberOne = 3;
    public int numberTwo = 4;
    public int result = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * () is our order of operations
         * % is our modulous operation. Remainder of division
         */

        //result = numberOne / numberTwo;

        // () = parenthesis
        // {} = curely brackets define scope
        // [] = square brackets allow acces to elements of a collection

        result = (numberOne + numberTwo) * numberOne;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
