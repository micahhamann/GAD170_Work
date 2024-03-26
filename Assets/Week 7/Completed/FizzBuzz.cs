#region Used NameSpaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace SAE.GAD170.Completed
{
    /// <summary>
    /// A class used to solve the fizzbuzz problem
    /// Print out all numbers from 1-100
    /// If 3 print out fizz
    /// If 5 print out buzz
    /// if divisible by 3 and 5 print fizzbuzz.
    /// </summary>
    public class FizzBuzz : MonoBehaviour
    {
        #region Public Variables
        /// <summary>
        /// The minimum number that can be passed into our Fizz Buzz program.
        /// </summary>
        public int minNumber = 0;
        /// <summary>
        /// The maximum number that can be passed into our Fizz Buzz program
        /// </summary>
        public int maxNumber = 100;
        /// <summary>
        /// If Enabled, our debugs will be outputted as well.
        /// </summary>
        public bool enableDebugging;
        #endregion

        #region Private Variables
        #endregion

        #region Unity Related Functions
        /// <summary>
        /// Start called on the first frame of the scene loading, this function should be used to get references to other scripts.
        /// or functions that should only be called once.
        /// </summary>
        void Start()
        {
            // On the first frame run our Fizz Buzz program based on the min and max numbers input into the Unity Inspector.
            RunFizzBuzz(minNumber, maxNumber);
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// A function to run the fizz buzz program, takes in a min and a max, has the options to change the multiples and words for each part of the game.
        /// Finally RETURNS the output in case it is needed to be used elsewhere.
        /// </summary>
        /// <param name="minNumber"></param>
        /// <param name="maxNumber"></param>
        /// <param name="fizzWord"></param>
        /// <param name="fizzMultiple"></param>
        /// <param name="buzzWord"></param>
        /// <param name="buzzMultiple"></param>
        /// <param name="fizzBuzzWord"></param>
        /// <param name="fizzBuzzMultiple"></param>
        /// <returns></returns>
        public string RunFizzBuzz(int minNumber = 0, int maxNumber = 100, string fizzWord = "Fizz", int fizzMultiple = 3, string buzzWord = "Buzz", int buzzMultiple = 5, string fizzBuzzWord = "FizzBuzz", int fizzBuzzMultiple = 15)
        {
            // a string to hold our final output.
            string output = string.Empty;
            // loop through starting from the min and go all the way including the max number
            for (int i = minNumber; i <= maxNumber; i++)
            {
                // pass each number into the ReturnOuputString and get back the appropriate word.
                output += ReturnOutputString(i, fizzWord, fizzMultiple, buzzWord, buzzMultiple, fizzBuzzWord, fizzBuzzMultiple);
            }
            // Debug out the final result if Debugging is enabled.
            DebugMessage(output);
            return output;
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Returns the single fizzbuzz word that is appropriate for the number being passed into this function.
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="fizzWord"></param>
        /// <param name="fizzMultiple"></param>
        /// <param name="buzzWord"></param>
        /// <param name="buzzMultiple"></param>
        /// <param name="fizzBuzzWord"></param>
        /// <param name="fizzBuzzMultiple"></param>
        /// <returns></returns>
        private string ReturnOutputString(int inputNumber, string fizzWord = "Fizz", int fizzMultiple = 3, string buzzWord = "Buzz", int buzzMultiple = 5, string fizzBuzzWord = "FizzBuzz", int fizzBuzzMultiple = 15)
        {
            // create an empty string that we start our fizzbuzz from
            string returnedString = string.Empty;
            // if our input number divides evenly into our fizzbuzz multiple then return fizzbuzz word
            if (inputNumber % fizzBuzzMultiple == 0)
            {
                returnedString += fizzBuzzWord;
            }
            // if our input number divides evenly into just our fizz multiple then return fizz word
            else if (inputNumber % fizzMultiple == 0)
            {
                returnedString += fizzWord;
            }
            // if our input number divides evenly into just our buzz multiple then return buzz word
            else if (inputNumber % buzzMultiple == 0)
            {
                returnedString += buzzWord;
            }
            // else our input number does not divide evenly into any multiples so then return the number word
            else
            {
                returnedString += inputNumber;
            }
            // return the string based on the number inputted, and add to it a new line character as well for formatting.
            return returnedString + "\n";
        }

        /// <summary>
        /// Used to log out messages to our editor.
        /// </summary>
        private void DebugMessage(string message)
        {
            //if debugging is enabled then print out our message
            if (enableDebugging)
            {
                Debug.Log(message);
            }
        }
        #endregion
    }
}