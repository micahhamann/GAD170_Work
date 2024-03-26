using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    public string myName;
    public string myHobby;
    public string myQuote;
    public bool isMale;
    public bool isParasite;
    public ShipManager shipManager;
    public Sprite myFace;
    public Sprite myHair;
    public UIManager uIManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        myName = shipManager.firstNamePool[Random.Range(0, shipManager.firstNamePool.Count)] + " " + shipManager.lastNamePool[Random.Range(0, shipManager.lastNamePool.Count)];
        myHobby = shipManager.hobbyPool[Random.Range(0, shipManager.hobbyPool.Count)];

        int randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            isMale = true;
            myFace = shipManager.maleFacePool[Random.Range(0, shipManager.maleFacePool.Count)];
            myHair = shipManager.maleHairPool[Random.Range(0, shipManager.maleHairPool.Count)];
        }

        else
        {
            isMale = false;
            myFace = shipManager.femaleFacePool[Random.Range(0, shipManager.femaleFacePool.Count)];
            myHair = shipManager.femaleHairPool[Random.Range(0, shipManager.femaleHairPool.Count)];
        }
    }
}
