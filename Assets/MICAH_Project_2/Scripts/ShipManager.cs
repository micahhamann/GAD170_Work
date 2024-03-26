using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<string> firstNamePool = new List<string>();
    public List<string> lastNamePool = new List<string>();
    public List<string> hobbyPool = new List<string>();
    public List<Sprite> maleFacePool = new List<Sprite>();
    public List<Sprite> maleHairPool = new List<Sprite>();
    public List<Sprite> femaleFacePool = new List<Sprite>();
    public List<Sprite> femaleHairPool = new List<Sprite>();

    public GameObject crewmatePrefab;
    public Crewmate crewmate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject crewClone = Instantiate(crewmatePrefab);
            crewmate = crewClone.GetComponent<Crewmate>();
            crewmate.Setup();
        }
    }



}
