using Facebook.WitAi;
using Facebook.WitAi.Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using recipes;
using ingredients;


public class Cook : Interactable
{   
    [SerializeField]
    TextMeshProUGUI dialogue;

    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    private Wit wit;

    [SerializeField]
    GameObject tray;

    [SerializeField]
    GameObject playerTray;

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
    Queue<Recipe> acriveOrderRecipes = new Queue<Recipe>();
    List<string> witOrder = new List<string>();

    //Timer for how long an ingredient takes to cook 
    private float cookingTimer = 4;

    //Order ready to be delivered 
    public Order cookedOrder;
    public bool orderReady = false;

    //Flags for entrees, sides, and drinks
    public bool entreeIncluded = false;
    public bool sideIncluded = false;
    public bool drinkIncluded = false;


    
    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.text = "Chef: What ya need?";
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }

    public void addOrder(WitResponseNode resp)
    {   
        witOrder.Clear();
        var arr = resp["entities"]["menu_item:menu_item"];
        for(int i = 0; i < arr.Count; i++) {
            witOrder.Add(arr[i]["value"].Value);
        }
    }


    
    //What to do on interact
    public override void Interact(){
        if(!orderReady && cooking){
            dialogue.text = "I'm busy you dimwit";
            return;
        }
        if(orderReady){
            GameObject player = GameObject.Find("player");
            Player playerScript = player.GetComponent<Player>();
            
            playerScript.setOrder(cookedOrder);
            string orderString = "Order of ";
            foreach(Recipe rec in playerScript.getOrder().getItems()){
                    orderString += rec.GetRecipeName() + " ";
            }
            orderString +=  " ready.";
            dialogue.text = orderString;
            tray.SetActive(false);
            playerTray.SetActive(true);
            //Reset order after player retrieves order;
            orderReady = false;
            entreeIncluded = false;
            sideIncluded = false;
            drinkIncluded = false;
            activeOrder = new Order();
            activeRecipes.Clear();
            return; 
        }
        //Supposed to work but doesn't 
        wit.Activate();

        //Insert recipes into a list from the user utterance. 
        foreach(string wOrder in witOrder){
            activeRecipes.Add(instRecipe(wOrder));
        }

    
        if(entreeIncluded && drinkIncluded && sideIncluded && !orderReady){
            dialogue.text = "Comin' right up!";
            activeOrder = new Order(activeRecipes);
            generateCookInstructions();
            cooking = true;

        }
        else{
            if(!entreeIncluded && !sideIncluded && !drinkIncluded){
                dialogue.text = "Just standin' here twiddlin' ma' thumbs";
            }
            else if(!entreeIncluded){
                dialogue.text = "Did they want an entree with that?";
            }
            else if(!drinkIncluded){
                dialogue.text = "Did they want a drink with that?";
            }
            else if(!sideIncluded){
                dialogue.text = "Did they want a side with that?";
            }
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
            case "the dasher":
                if (!entreeIncluded)
                {
                    entreeIncluded = true;
                    return new Dasher();
                }
                break;
            case "eggers can be cheesers":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new EggersBurger();
                }
                break;
            case "burgeroisie":
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
            case "i cant believe it's not burger":
                if(!entreeIncluded){
                    entreeIncluded = true;
                    return new BelieveBurger();
                }
                break;
            case "mozzarella sticks":
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
            case "fries":
                if(!sideIncluded){
                    sideIncluded = true;
                    return new Fries();
                }
                break;
            case "water": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new Water());
                }
                break;
            case "coke": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new Coke());
                }
                break;
            case "sprite": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new ingredients.Sprite());
                }
                break;
            case "dr. pepper": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new DrPepper());
                }
                break;
            case "coffee": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new Coffee());
                }
                break;
            case "tea": 
                if(!drinkIncluded){
                    drinkIncluded = true;
                    return new recipes.Drink(new Tea());
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
            if (rec.GetPrepInstructions() == null)
                continue;
            foreach(var ing in rec.GetPrepInstructions()){
                List<string> prepInstructions = ing.Value;
                foreach(string prepInst in prepInstructions){
                    activeOrderInstructions.Enqueue("*Chef is currently prepping " + ing.Key.GetIngredientName() + " at the " + prepInst + " for the " + rec.GetRecipeName() + "*");               
                }
            }
        }
    }

    public void cookIngredient(){
        if(activeOrderInstructions.Count > 0)
            dialogue.text = activeOrderInstructions.Dequeue(); 
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
                List<Recipe> tempRec = new List<Recipe>();
                tempRec.AddRange(activeRecipes);
                cookedOrder = new Order(tempRec);
                orderReady = true;
                tray.SetActive(true);
                cooking = false;
            }
            cookingTimer = 4; 
        }
    }
   


}
