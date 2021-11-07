using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cook : Interactable
{   
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    // [SerializeField]
    // Wit wit;

    private string dialogueText = "Listening...";


    private Order order;
    private RecipeDictionary recipeDict;
    private Queue<Order> pendingOrders = new Queue<Order>();
    private Order activeOrder;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }


    

    public override void Interact(){
        
        dialogue.text = dialogueText;
        
    }

    //Adds order to the pending order queue
    private void addOrder(Order newOrder) {
        if(isOrderValid(newOrder))
            pendingOrders.Enqueue(newOrder);
    }

    private Order listenToPlayer() {
        // TODO
        /*
        var response = wit.activate(); 
        */
        Order newOrder = new Order();
        return newOrder;
    }

    private void setActiveOrder() {
        if(activeOrder == null)
            activeOrder = pendingOrders.Dequeue();
        return;
    }

    private bool isOrderValid(Order order) {
        // TODO
        return false;
    }

    //Invoke repeating for cooking tasks (ingredients)
}
