using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc2 : MonoBehaviour
{

    public string myName = "Micah";
    public enum OrcTypes {Strong = 1, Smart = 2, Fast = 3}
    public OrcTypes currentOrcType;

    private int strength;
    private int intelligence;
    private int agility;


    // Start is called before the first frame update
    void Start()
    {
        switch (currentOrcType)
        {
            default:
                break;
        }

        //example of a switch

        int x = Random.Range(0, 4);

        switch(x)
        {
            case 0:
                {
                    //do some code
                    break;
                }

            case 1:
                {
                    //do some code
                    break;
                }

            default:
                {
                    //otherwise do this
                    break;
                }
        }

        switch(currentOrcType)
        {
            case OrcTypes.Fast:
                {
                    strength = 1;
                    agility = 8;
                    intelligence = 1;
                    break;
                }

            case OrcTypes.Smart:
                {
                    strength = 1;
                    agility = 1;
                    intelligence = 8;
                    break;
                }

            case OrcTypes.Strong:
                {
                    strength = 8;
                    agility = 1;
                    intelligence = 1;
                    break;
                }

        }

        if(currentOrcType == OrcTypes.Fast)
        {
            strength = 1;
            agility = 8;
            intelligence = 1;
        }

        else if (currentOrcType == OrcTypes.Smart)
        {
            strength = 1;
            agility = 1;
            intelligence = 8;
        }

        else if (currentOrcType == OrcTypes.Strong)
        {
            strength = 8;
            agility = 1;
            intelligence = 1;
        }
    }

    void ChangeEnum(int enumvalue)
    {
        currentOrcType = (OrcTypes)enumvalue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
