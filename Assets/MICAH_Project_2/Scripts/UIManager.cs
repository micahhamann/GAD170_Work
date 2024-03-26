using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public ShipManager shipManager;
    public Image facePortrait;
    public Image hairPortrait;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayHobby;
    public TextMeshProUGUI displayQuote;
    public TextMeshProUGUI mainText;

    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayRecruitUI()
    {
        facePortrait.sprite = shipManager.crewmate.myFace;
        hairPortrait.sprite = shipManager.crewmate.myHair;
        displayName.text = shipManager.crewmate.GetName();
        displayHobby.text = shipManager.crewmate.GetHobby();
    }
}
