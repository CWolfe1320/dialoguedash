using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using recipes;


public class Customer : Interactable
{
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    private string dialogueText;


    private Recipe entree;
    private Recipe side;
    private Recipe drink;


    private RecipeDictionary recipeDict = new RecipeDictionary();



    public override void Interact(){

        RandomizeOrder();



        dialogue.text = "Entree: " + entree.GetRecipeName() + " Side: " + side.GetRecipeName() + " Drink: " + drink.GetRecipeName();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }


    public void RandomizeOrder()
    {

        List<Recipe> entrees = recipeDict.GetEntrees();//5
        List<Recipe> drinks = recipeDict.GetDrinks();//6
        List<Recipe> sides = recipeDict.GetSides();//4

        entree = entrees[UnityEngine.Random.Range(1,5)];
        drink = drinks[UnityEngine.Random.Range(1, 6)];
        side = sides[UnityEngine.Random.Range(1, 4)];

    }

    public void LoadRandomOrderDialogue()
    {

    }

}