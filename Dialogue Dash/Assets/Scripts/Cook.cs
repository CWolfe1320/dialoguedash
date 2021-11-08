using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using recipes;


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
    
    //Currently active order
    private Order activeOrder;
    List<Recipe> activeRecipes = new List<Recipe>();

    private bool cooking = false;
    //The current instructions for orders in a queue
    Queue<string> activeOrderInstructions = new Queue<string>();
    //Timer for how long an ingredient takes to cook 
    private float cookingTimer = 2;

    //Order ready to be delivered 
    public Order cookedOrder;
    public bool orderReady = false;

    //Flags for entrees, sides, and drinks
    private bool entreeIncluded = false;
    private bool sideIncluded = false;
    private bool drinkIncluded = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }


    
    //What to do on interact
    public override void Interact(){
        if(!orderReady && cooking){
            Debug.Log("I'm busy, you dimwit");
            return;
        }
        if(orderReady){
            GameObject player = GameObject.Find("player");
            Player playerScript = player.GetComponent<Player>();
            playerScript.setOrder(cookedOrder);
            foreach(Recipe rec in playerScript.getOrder().getItems()){
                    Debug.Log(rec.GetRecipeName());
            }
            Debug.Log(orderReady);
            //Reset order after player retrieves order;
            orderReady = false;
            entreeIncluded = false;
            sideIncluded = false;
            drinkIncluded = false;
            activeOrder = new Order();
            activeRecipes.Clear();
            return; 
        }

        //Insert recipes into a list from the user utterance. 
        activeRecipes.Add(instRecipe("cluckin burger"));
        activeRecipes.Add(instRecipe("drink"));
        activeRecipes.Add(instRecipe("natural-cut fries"));

        //You have an entree, side, and drink and an order is not currently ready.
        Debug.Log("Entree: " + entreeIncluded);
        Debug.Log("Drink: " + drinkIncluded);
        Debug.Log("Side: " + sideIncluded);
        Debug.Log("Order Ready: " + orderReady);
    
        if(entreeIncluded && drinkIncluded && sideIncluded && !orderReady){
            activeOrder = new Order(activeRecipes);
            generateCookInstructions();
            cooking = true;
        }

    }
    
        
        


    //Adds order to the pending order queue
    private void addOrder(Order newOrder) {
        if(isOrderValid(newOrder))
            pendingOrders.Enqueue(newOrder);
    }


    private Order listenToPlayer() {
        string text = "[wit retrieved text]";
       
        Order newOrder = new Order();
        return newOrder;
    }


    private Recipe instRecipe(string recipeString){
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
        if(activeOrder == null){
            activeOrder = pendingOrders.Dequeue();
            cooking = true;
        }
        return;
    }

    private bool isOrderValid(Order order) {
        // TODO
        return false;
    }

    private void generateCookInstructions(){
    
        //For each recipe in order
        foreach (Recipe rec in activeOrder.getItems()){
            //For each Ingredient in recipe add the storage location and default instruction string. 
            if (rec.GetPrepInstructions().Count == 0)
                continue;
            foreach(var ing in rec.GetPrepInstructions()){
                List<string> prepInstructions = ing.Value;
                foreach(string prepInst in prepInstructions){
                    activeOrderInstructions.Enqueue(prepInst);                
                }
            }
        }
    }

    public void cookIngredient(){
        if(activeOrderInstructions.Count > 0)
            Debug.Log(activeOrderInstructions.Dequeue());
    }


    public bool isCooking(){
        return cooking;
    }

    public Queue<string> getCookInstructions(){
        return activeOrderInstructions;
    }

    public Order getReadyOrder(){
        return cookedOrder;
    }

    void FixedUpdate(){
        if (cookingTimer > 0 && cooking)
        {
            cookingTimer -= Time.deltaTime;
        }
        else{
            if(activeOrderInstructions.Count > 0){
                cookIngredient();
            }
            else if(activeOrderInstructions.Count == 0 && cooking){
                cookedOrder = activeOrder;
                orderReady = true;
                cooking = false;
            }
            cookingTimer = 2; 
        }
    }
   


}
