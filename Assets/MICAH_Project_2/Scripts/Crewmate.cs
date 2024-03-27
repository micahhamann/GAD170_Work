using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    public List<string> maleNamePool = new List<string>();
    public List<string> femaleNamePool = new List<string>();
    public List<string> lastNamePool = new List<string>();
    public List<string> hobbyPool = new List<string>();
    public List<Sprite> maleFacePool = new List<Sprite>();
    public List<Sprite> maleHairPool = new List<Sprite>();
    public List<Sprite> femaleFacePool = new List<Sprite>();
    public List<Sprite> femaleHairPool = new List<Sprite>();
    public List<string> quotePool = new List<string>();

    private string myName;
    private string myHobby;
    private string myQuote;
    public bool isMale;
    public bool isParasite;
    

    public Sprite myFace;
    public Sprite myHair;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public string GetPronoun(bool male)
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

    public void Setup()
    {
        
        myHobby = hobbyPool[Random.Range(0, hobbyPool.Count)];
        myQuote = quotePool[Random.Range(0, quotePool.Count)];

        int randomNum = Random.Range(0, 2);

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

    public void DestroyCrewmate()
    {
        Destroy(this.gameObject);
    }


    public void SetParasiteCondition(int diff)
    {
        switch (diff)
        {
            case 1:
                if (myName.StartsWith("P"))
                {
                    isParasite = true;
                }
                break;

            case 0:
                if (myQuote.Contains("parasite"))
                {
                    isParasite = true;
                }
                break;

            case 2:

                int rand = Random.Range(0, 2);
                if (isMale && rand == 0)
                {
                    myName = femaleNamePool[Random.Range(0, maleNamePool.Count)] + " " + lastNamePool[Random.Range(0, lastNamePool.Count)];
                    isParasite = true;
                }

                break;

            case 3:
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
