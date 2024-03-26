using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    public List<string> firstNamePool = new List<string>();
    public List<string> lastNamePool = new List<string>();
    public List<string> hobbyPool = new List<string>();
    public List<Sprite> maleFacePool = new List<Sprite>();
    public List<Sprite> maleHairPool = new List<Sprite>();
    public List<Sprite> femaleFacePool = new List<Sprite>();
    public List<Sprite> femaleHairPool = new List<Sprite>();

    private string myName;
    private string myHobby;
    private string myQuote;
    private bool isMale;
    private bool isParasite;

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
    public void Setup()
    {
        myName = firstNamePool[Random.Range(0, firstNamePool.Count)] + " " + lastNamePool[Random.Range(0, lastNamePool.Count)];
        myHobby = hobbyPool[Random.Range(0, hobbyPool.Count)];

        int randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            isMale = true;
            myFace = maleFacePool[Random.Range(0,maleFacePool.Count)];
            myHair = maleHairPool[Random.Range(0, maleHairPool.Count)];
        }

        else
        {
            isMale = false;
            myFace = femaleFacePool[Random.Range(0, femaleFacePool.Count)];
            myHair = femaleHairPool[Random.Range(0, femaleHairPool.Count)];
        }
    }
}
