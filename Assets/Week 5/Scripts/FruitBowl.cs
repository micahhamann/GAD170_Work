using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBowl : MonoBehaviour
{

    public Fruit[] allFruit = new Fruit[] { };
    public char[] myName = new char[] { 'M', 'I', 'C', 'A', 'H' };
    public List<Fruit> allFruitList = new List<Fruit>();
    public List<char> myListName = new List<char>() { 'M', 'I', 'C', 'A', 'H' };


    // Start is called before the first frame update
    void Start()
    {




        Debug.Log("The first fruit is: " + allFruit[allFruit.Length - 1].fruitName);
        Debug.Log("The first fruit is: " + allFruitList[0].fruitName);

        //accessing a random fruit
        Debug.Log("A random fruit is: " + allFruit[Random.Range(0, allFruit.Length)].fruitName);
        Debug.Log("A random fruit is: " + allFruitList[Random.Range(0, allFruitList.Count)]);

        Debug.Log(allFruitList.Count);

        Debug.Log("The last fruit is: " + allFruitList[allFruitList.Count - 1].fruitName);

        //remove M from Name

        myListName.Remove('M'); // this removes the first M in the list
        //myListName.Add('M'); // this will add a M to the last element of the list ICAHM
        myListName.Insert(0, 'M'); // this will at an M to the start of the list
        myListName.Clear(); //this will clear out the list
        
        // for each loop does the same as for int i except it only works on colle
        // actions of objects

        foreach(Fruit fruit in allFruit)
        {
            Debug.Log("The fruit name is: " + fruit.name);
        }

        //print out all names of fruit

        for (int i = 0; i < allFruit.Length; i++)
        {
            Debug.Log("the fruit name is: " + allFruit[i].fruitName);
        }

        for (int i = 0; i < allFruitList.Count; i++)
        {
            Debug.Log("The fruit name is: " + allFruit[i].fruitName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
