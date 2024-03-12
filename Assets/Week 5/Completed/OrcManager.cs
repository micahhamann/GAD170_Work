using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.Completed
{
    public class OrcManager : MonoBehaviour
    {

        /*
         * so in this script, what we want to do is to have 3 orcs in our scene, and
         * have this script be able to tell them what to do, i.e. setting up some starting stats.
         * Then we want to do a kind of battle, until there is only one orc left alive.
         * we are basically re-creating the first brief, but using multiple scripts :).
         * This is good practice to improve on what you did in brief one, making it more organised.
         * Bonus, determine an overall winner i.e. when 1 orc is left alive tell me which one.
         */

        public GameObject orcPrefab;
        public Orc firstOrc;
        public Orc secondOrc;
        public Orc thirdOrc;

        // Start is called before the first frame update
        void Start()
        {
            // I've done the first orc, we need two more.
            // we can re-use same prefab, but we need a new orc reference for each one.
            GameObject orcClone = Instantiate(orcPrefab);
            firstOrc = orcClone.GetComponent<Orc>();

            orcClone = Instantiate(orcPrefab);
            secondOrc = orcClone.GetComponent<Orc>();

            orcClone = Instantiate(orcPrefab);
            thirdOrc = orcClone.GetComponent<Orc>();

            // we've got one orc set up...but there are 2 more, we might need more references.
            firstOrc.Setup();
            secondOrc.Setup();
            thirdOrc.Setup();
        }

        private void Update()
        {
            
            // when we press space bar, if you remove this, this becomes an autobattler
            if(Input.GetKeyDown(KeyCode.Space))
            {
                // here let's pseudo randomly pick 2 orcs out of 3.
                int randomNumber = Random.Range(0, 3);

                if(randomNumber == 0)
                {
                    // you probably should check to see if we have references to the orcs i.e. if(firstOrc !=null && other orc), if this is false, debug out to press again.
                    // first orc and second orc fight.
                    FirstOrcAndSecondFight();
                }
                else if(randomNumber == 1)
                {
                    // second and third orc fight
                    SecondOrcAndThirdFight();
                }
                else if(randomNumber == 2)
                {
                    // third and first orc fight.
                    ThirdOrcandFirstFight();
                }
                
                // essentially we are checking if 2 of the 3 are null.
                if((firstOrc == null && secondOrc == null) || (secondOrc == null && thirdOrc == null) || (firstOrc == null && thirdOrc == null))
                { 
                    // as we are destroying them, we lose a reference i.e. value will be null, so if we check that it's not null we can see who's left
                    // and we can determine an overall winner if we want.
                    DetermineWinner();
                }
            }
        }
        void FirstOrcAndSecondFight()
        {
            if (firstOrc != null && secondOrc != null)
            {
                firstOrc.TakeDamage(secondOrc.attackDamge);
                secondOrc.TakeDamage(firstOrc.attackDamge);
            }
            else
            {
                Debug.Log("re-roll");
            }
        }

        void SecondOrcAndThirdFight()
        {
            
            if (secondOrc != null && thirdOrc != null)
            {
                secondOrc.TakeDamage(thirdOrc.attackDamge);
                thirdOrc.TakeDamage(secondOrc.attackDamge);
            }
            else
            {
                Debug.Log("re-roll");
            }
        }

        void ThirdOrcandFirstFight()
        {
            if (thirdOrc != null && firstOrc != null)
            {
                thirdOrc.TakeDamage(firstOrc.attackDamge);
                firstOrc.TakeDamage(thirdOrc.attackDamge);
            }
            else
            {
                Debug.Log("re-roll");
            }
        }

        void DetermineWinner()
        {
            if (firstOrc != null)
            {
                Debug.Log(firstOrc.orcName + " is winner");
            }
            if (secondOrc != null)
            {
                Debug.Log(secondOrc.orcName + " is winner");
            }
            if (thirdOrc != null)
            {
                Debug.Log(thirdOrc.orcName + " is winner");
            }
        }
    }   
}