using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Customer : Interactable
{
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    private string dialogueText = "Listening...";


    private Order order;
    private RecipeDictionary recipeDict;

    public override void Interact(){

        dialogue.text = dialogueText;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }

    
}