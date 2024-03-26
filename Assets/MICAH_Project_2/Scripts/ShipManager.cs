using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<Crewmate> shipList = new List<Crewmate>();
    
    public GameObject crewmatePrefab;
    public UIManager uIManager;
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
            uIManager.DisplayRecruitUI();
        }
    }



}
