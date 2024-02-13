using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Pokedex : MonoBehaviour
{
    public List<Pokemon> allPokemon = new List<Pokemon>();
    public Image pokemonSprite;
    public TextMeshProUGUI pokemonName;
    public TextMeshProUGUI pokemonDescription;
    public TextMeshProUGUI pokemonHeight;
    public TextMeshProUGUI pokemonWeight;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        // set the current index to 0
        // call the set pokemon function and pass in the current index
    }

    public void SetPokemon(int index)
    {
        // using the index, let's access that index of the pokemon list
        Pokemon currentPokemon = null;

        // we should probably check to make sure we have all the references for this, best practice would be to check for null
        // set the pokemon sprite to the current pokemon sprite
        // set the pokemon name to the current pokemon name
        // set the pokemon name to the current pokemon description
        // set the pokemon weight and height

    }

    // don't forget to have your button in your scene call this function
    public void NextPokemon()
    {
        // increment the current index by 1

        // we should probably check that we don't go outside the count of the list
        // if we do go past the count, let's loop back to 0.


        // we should then call out set pokemon so it updates the UI.

    }

    // don't forget to have your button in your scene call this function
    public void PreviousPokemon()
    {
        // decrement the current index by 1

        // so now we want to make sure we don't go into the negative.
        // if we do go into a negative, let's instead loop to the end of the list.
        // we probably want to get the count...don't forget that lists/arrays start at 0


        // we should then call out set pokemon so it updates the UI.

    }

    // don't forget to have your button in your scene call this function
    public void RandomPokemon()
    {
        // lets select a random pokemon from our list to display
        // the key to success here, is I should be still able to press next and previous and it still works.
        
    }
}