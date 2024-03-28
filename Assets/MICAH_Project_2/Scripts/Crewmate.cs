using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    //Defining all the lists being drawn from. I populated them in the inspector

    public List<string> maleNamePool = new List<string>();
    public List<string> femaleNamePool = new List<string>();
    public List<string> lastNamePool = new List<string>();
    public List<string> hobbyPool = new List<string>();
    public List<Sprite> maleFacePool = new List<Sprite>();
    public List<Sprite> maleHairPool = new List<Sprite>();
    public List<Sprite> femaleFacePool = new List<Sprite>();
    public List<Sprite> femaleHairPool = new List<Sprite>();
    public List<string> quotePool = new List<string>();

    //Crewmate variables. Some are protected.

    private string myName;
    private string myHobby;
    private string myQuote;
    public bool isMale;
    public bool isParasite;
    public Sprite myFace;
    public Sprite myHair;


    //Encapsulating the private variables so they can be accessed publicly without danger of messing with them

    public string GetName()
    {
        return myName;
    }

    public string GetHobby()
    {
        return myHobby;
    }

    public string GetQuote()
    {
        return myQuote;
    }

    public string GetPronoun(bool male) //Gets and returns the correct pronoun to be used in text
    {
        if (male)
        {
            return "He";
        }

        else
        {
            return "She";
        }
    }

    //Sets the crewmate varibles without having to access them directly
    public void Setup()
    {
        Debug.Log("New instance of crewmate has been created");
        myHobby = hobbyPool[Random.Range(0, hobbyPool.Count)];
        myQuote = quotePool[Random.Range(0, quotePool.Count)];

        int randomNum = Random.Range(0, 2); //Sets the sex: 1 in 2 chance of being male

        if (randomNum == 0)
        {
            isMale = true;
            myFace = maleFacePool[Random.Range(0,maleFacePool.Count)];
            myHair = maleHairPool[Random.Range(0, maleHairPool.Count)];
            myName = maleNamePool[Random.Range(0, maleNamePool.Count)] + " " + lastNamePool[Random.Range(0, lastNamePool.Count)];
        }

        else
        {
            isMale = false;
            myFace = femaleFacePool[Random.Range(0, femaleFacePool.Count)];
            myHair = femaleHairPool[Random.Range(0, femaleHairPool.Count)];
            myName = femaleNamePool[Random.Range(0, maleNamePool.Count)] + " " + lastNamePool[Random.Range(0, lastNamePool.Count)];
        }

    }

    //Function for crewmate to destroy its own instance of itself

    public void DestroyCrewmate()
    {
        Destroy(this.gameObject);
    }


    public void SetParasiteCondition(int diff)
    {
        //The difficulty varible set when you click a difficulty button decides which case to use
        switch (diff)
        {
            case 1:
                //If their name starts with P, they are a parasite
                if (myName.StartsWith("P"))
                {
                    isParasite = true;
                }
                break;

            case 0:
                //If they mention "parasite" in their quote, they are a parasite
                if (myQuote.Contains("parasite") || myQuote.Contains("Parasite"))
                {
                    isParasite = true;
                }
                break;

            case 2:
                //If a male has a female name, they are a parasite
                int rand = Random.Range(0, 2);
                if (isMale && rand == 0)
                {
                    myName = femaleNamePool[Random.Range(0, maleNamePool.Count)] + " " + lastNamePool[Random.Range(0, lastNamePool.Count)];
                    isParasite = true;
                }

                break;

            case 3:
                //If the quote mentions a body part, they are a parasite
                if(myQuote.Contains("butt") || myQuote.Contains("lips") || myQuote.Contains("head") || myQuote.Contains("feet") || myQuote.Contains("brain") || myQuote.Contains("hand") || myQuote.Contains("mouth") || myQuote.Contains("eye"))
                {
                    isParasite = true;
                }
                break;

            default:
                break;
        }
    }
}
