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

    //Flags for entrees, sides, and drinks
    private bool entreeIncluded = false;
    private bool sideIncluded = false;
    private bool drinks = false;

    private Order listenToPlayer() {
        List<Recipe> understoodItems = new List<Recipe>();

        string text = "[wit retrieved text]";



       
        Order newOrder = new Order();
        return newOrder;
    }


    private Recipes instRecipe(string recipeString){
        Recipe addedRecipe;
        switch (recipeString){
            case "cluckin burger":
                if(!entreeIncluded){
                    entreeIncluded = true; 
                    return new CluckinBurger();
                }
                break;
            case "eggers can be cheesers":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new EggersBurger();
                }
                break;
            case "burgeroise":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new Burgeroisie();
                }
                break;
            case "hamburger":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new Hamburger();
                }
                break;
            case "i cant believe its not burger":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new BelieveBurger();
                }
                break;
            case "mozarrella sticks":
                if(!sideIncluded){
                    sideIncluded = true;
                    return new MozzarellaSticks();
                }
                break;
            case "onion rings":
                if(!sideIncluded){
                    sideIncluded = true;
                    return new OnionRings();
                }
                break;
            case "side salad":
                if(!sideIncluded){
                    sideIncluded = true;
                    return new SideSalad();
                }
                break;
            case "natural-cut fries":
                if(!sideIncluded){
                    sideIncluded = true;
                    return new Fries();
                }
                break;
            case "drink": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new Drink();
                }
                break;
        }
        return null;
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
