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
    GameObject dialogueBox, interactBubble;

    [SerializeField]
    private Wit wit;

    [SerializeField]
    GameObject tray;

    [SerializeField]
    GameObject playerTray;

    //Chef checkpoints
    private GameObject df;
    private GameObject cb;
    private GameObject ko;
    private GameObject f;
    private GameObject o;
    private GameObject p;
    private GameObject ds;
    private GameObject s;

    //Cook movement variables
    public float moveSpeed = 5f; 
    public Rigidbody2D rb;
    private Vector2 movement;
    public float moveDuration = 4.0f;
    private GameObject chefSprite;

    private string dialogueText = "Listening...";


    private Order order;
    private RecipeDictionary recipeDict;
    private Queue<Order> pendingOrders = new Queue<Order>();

    //Possible locations to move for Chef
    private static string[] tempLocations = {"deep fryer", "stove", "cutting board", "drink station", "fridge", "pantry", "oven", "deep fryer"};
    private List<string> cookingLocations = new List<string>(tempLocations);
    private Vector2 targetVector; 
    
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

    
    private void Start(){
        chefSprite = GameObject.Find("chef");

        //Chef checkpoints
        df = GameObject.Find("dfCheckpoint");
        cb = GameObject.Find("cbCheckpoint");
        ko = GameObject.Find("koCheckpoint");
        f = GameObject.Find("fCheckpoint");
        o = GameObject.Find("oCheckpoint");
        p = GameObject.Find("pCheckpoint");
        ds = GameObject.Find("dsCheckpoint");
        s = GameObject.Find("sCheckpoint");

        targetVector = ko.transform.position;
    
    }
    
    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.text = "Chef: What ya need?";
        dialogueBox.SetActive(true);
        interactBubble.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
        interactBubble.SetActive(false);
    }

    public void addOrder(WitResponseNode resp)
    {   
        if (resp["intents"][0]["name"].Value == "order_food"){
            witOrder.Clear();
            var arr = resp["entities"]["menu_item:menu_item"];
            for(int i = 0; i < arr.Count; i++) {
                Debug.Log(arr[i]["value"].Value);
                witOrder.Add(arr[i]["value"].Value);
            }
            foreach(string wOrder in witOrder){
                activeRecipes.Add(instRecipe(wOrder));
            }
            Interact();
        }
    }

    public bool initialVocal = false;
    
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
            initialVocal = false;
            return; 
        }
        if(!initialVocal)
        {
            if(!entreeIncluded || !sideIncluded || !drinkIncluded)
                wit.Activate();
            initialVocal = true;
        }
            

            

    
        if(entreeIncluded && drinkIncluded && sideIncluded && !orderReady){
            dialogue.text = "Comin' right up!";
            activeOrder = new Order(activeRecipes);
            generateCookInstructions();
            cooking = true;
            initialVocal = true;
        }
        else{
            if(!entreeIncluded && !sideIncluded && !drinkIncluded){
                dialogue.text = "Listening...";
                initialVocal = false;
            }
            else if(!entreeIncluded){
                dialogue.text = "Did they want an entree with that?";
                initialVocal = false;
            }
            else if(!drinkIncluded){
                dialogue.text = "Did they want a drink with that?";
                initialVocal = false;
            }
            else if(!sideIncluded){
                dialogue.text = "Did they want a side with that?";
                initialVocal = false;
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
            // if (rec.GetPrepInstructions() == null)
            //     continue;
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

    public void findTargetLocation(){
        if(activeOrderInstructions.Count > 0){
            string inst = activeOrderInstructions.Peek();
            string target = "";
            foreach(string location in cookingLocations){
                if(inst.Contains(location)){
                    target = location;
                }
            }
            switch(target){
                case "deep fryer":
                    targetVector = df.transform.position;
                    return;
                    break;
                case "cutting board":
                    targetVector = cb.transform.position;
                    return;
                    break;
                case "fridge":
                    targetVector = f.transform.position;
                    return;
                    break;
                case "oven":
                    targetVector = o.transform.position;
                    return;
                    break;
                case "pantry":
                    targetVector = p.transform.position;
                    return;
                    break;
                case "stove":       
                    targetVector = s.transform.position;
                    return;
                    break;
                case "drink station": 
                    targetVector = ds.transform.position;
                    return;
                    break;
            }
        }
        else{
            targetVector = ko.transform.position;
            return;
        }
        return;
    }

    public Queue<string> getCookInstructions(){
        return activeOrderInstructions;
    }

    public Order getReadyOrder(){
        return cookedOrder;
    }

    

    float t = 0;

    void FixedUpdate(){
        findTargetLocation();
        if (cookingTimer > 0 && cooking)
        {   
             t += Time.deltaTime;  
            cookingTimer -= Time.deltaTime;   
        }
        else{
            if(activeOrderInstructions.Count > 0){
                t =  0;
                cookIngredient();
            }
            else if(activeOrderInstructions.Count == 0 && cooking){
                List<Recipe> tempRec = new List<Recipe>();
                tempRec.AddRange(activeRecipes);
                cookedOrder = new Order(tempRec);
                orderReady = true;
                tray.SetActive(true);
                cooking = false;
                t = 0;
            }
            
            cookingTimer = 4; 
        }
        
       
        float percentageComplete = t/moveDuration;
        chefSprite.transform.position = Vector2.Lerp(chefSprite.transform.position, targetVector, Mathf.SmoothStep(0,1, percentageComplete));
    }
    
   


}
