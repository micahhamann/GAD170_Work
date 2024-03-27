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
    public TextMeshProUGUI displaySex;

    public TextMeshProUGUI mainText;
    public int maxText = 2;
    public List<string> textList = new List<string>();

    public List<Image> crewFaceDisplay = new List<Image>();
    public List<Image> crewHairDisplay = new List<Image>();
    public List<Image> parasiteFaceDisplay = new List<Image>();
    public List<Image> parasiteHairDisplay = new List<Image>();

    public Sprite emptyPortrait;
    public Sprite deathSprite;
    public Button acceptButton;
    public Button rejectButton;
    public Button newRecruitButton;

    public GameObject victoryPanel;
    public List<Image> victoryTeamFace = new List<Image>();
    public List<Image> victoryTeamHair = new List<Image>();
    public List<Image> gameOverTeamFace = new List<Image>();
    public List<Image> gameOverTeamHair = new List<Image>();
    public GameObject gameOverPanel;
    public GameObject titleScreen;


    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //Alway show current crewmember in display
        if(shipManager.crewmate != null)
        {
            facePortrait.sprite = shipManager.crewmate.myFace;
            hairPortrait.sprite = shipManager.crewmate.myHair;
            displayName.text = shipManager.crewmate.GetName();
            displayHobby.text = shipManager.crewmate.GetHobby();
            displayQuote.text = shipManager.crewmate.GetQuote();
            

            if(shipManager.crewmate.isMale)
            {
                displaySex.text = "Male";
            }

            else
            {
                displaySex.text = "Female";
            }
        }

        //If no current crewmember, show blank
        else
        {
            displayName.text = null;
            displayHobby.text = null;
            displayQuote.text = null;
            displaySex.text = null;
            hairPortrait.sprite = emptyPortrait;
            Debug.Log("There is no current crewmate");
        }


    }

    public void DisplayRecruitUI()
    {
        facePortrait.sprite = shipManager.crewmate.myFace;
        hairPortrait.sprite = shipManager.crewmate.myHair;
        displayName.text = shipManager.crewmate.GetName();
        displayHobby.text = shipManager.crewmate.GetHobby();
    }

    public void UpdateCrewDisplay()
    {
        //Wiping all slots before updating
        foreach (Image image in crewFaceDisplay)
        {
            image.sprite = emptyPortrait;
        }

        foreach (Image image in crewHairDisplay)
        {
            image.sprite = emptyPortrait;
        }


        //Populate slots with sprites from current ship list
        for (int i = 0; i < shipManager.shipList.Count; i++)
        {
            if (shipManager.shipList[i].myFace != null)
            {
                
                crewFaceDisplay[i].sprite = shipManager.shipList[i].myFace;
                crewHairDisplay[i].sprite = shipManager.shipList[i].myHair;

            }

            else
            {
                crewFaceDisplay[i].sprite = emptyPortrait;
                crewHairDisplay[i].sprite = emptyPortrait;
                return;
            }
        }


    }

    public void UpdateParasiteDisplay()
    {
        foreach (Image image in parasiteFaceDisplay)
        {
            image.sprite = emptyPortrait;
            image.color = Color.green;
        }

        foreach (Image image in parasiteHairDisplay)
        {
            image.sprite = emptyPortrait;
            image.color = Color.green;
        }

        Debug.Log("Updating Display");

        for (int i = 0; i < shipManager.knownParasiteList.Count; i++)
        {
            if(shipManager.knownParasiteList[i].myFace != null)

                if(parasiteFaceDisplay.Count >= shipManager.knownParasiteList.Count)
                {
                    Debug.Log("Adding Face");
                    parasiteFaceDisplay[i].sprite = shipManager.knownParasiteList[i].myFace;
                    parasiteFaceDisplay[i].color = Color.green;
                    Debug.Log("Adding Hair");
                    parasiteHairDisplay[i].sprite = shipManager.knownParasiteList[i].myHair;

                }

                else
                {
                    Debug.Log("Too many parasites! You lose.");
                    return;
                }

            else
            {
                Debug.Log("Parasite Empty?");
                parasiteHairDisplay[i].sprite = emptyPortrait;
                parasiteHairDisplay[i].color = Color.green;

            }

        }
    }

    public void AddText(string newText)
    {
        textList.Add(newText);

        if (textList.Count > maxText)
        {
            //Remove the top item of text to keep text box clean
            textList.RemoveAt(0);
        }

        UpdateTextBox();
    }

    private void UpdateTextBox()
    {
        //turn list of text into a single string to print
        string newText = string.Join("\n\n", textList.ToArray());

        //print text in text box
        mainText.text = newText;
    }

    public void ClearText()
    {
        textList.Clear();
    }

    public void AllButtonsOff()
    {
        newRecruitButton.gameObject.SetActive(false);
        acceptButton.gameObject.SetActive(false);
        rejectButton.gameObject.SetActive(false);
    }

    public void PopulateEndGame()
    {
        for (int i = 0; i < shipManager.shipList.Count; i++)
        {
            victoryTeamFace[i].sprite = shipManager.shipList[i].myFace;
            victoryTeamHair[i].sprite = shipManager.shipList[i].myHair;
        }

        for (int i = 0; i < shipManager.knownParasiteList.Count; i++)
        {
            gameOverTeamFace[i].sprite = shipManager.knownParasiteList[i].myFace;
            gameOverTeamFace[i].color = Color.green;
            gameOverTeamHair[i].sprite = shipManager.knownParasiteList[i].myHair;

        }
    }
}
